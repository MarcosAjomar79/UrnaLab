using SQLite;
using UrnaLab.Tablet.Models;
using UrnaLab.Tablet.Properties.Models;

namespace UrnaLab.Tablet.Data
{
    public class VotoDatabase
    {
        private SQLiteAsyncConnection? database;

        private async Task InicializarAsync()
        {
            if (database is not null)
                return;

            string caminhoBanco = Path.Combine(
                FileSystem.AppDataDirectory,
                "urnalab.db"
            );

            database = new SQLiteAsyncConnection(caminhoBanco);

            await database.CreateTableAsync<Voto>();
        }

        public async Task RegistrarVotoAsync(int? alunoId, int chapaId)
        {
            await InicializarAsync();

            await database!.RunInTransactionAsync(conexao =>
            {
                var chapa = conexao.Find<Chapa>(chapaId);

                if (chapa is null)
                    throw new InvalidOperationException(
                        "Chapa não encontrada."
                    );

                if (chapa.Status != "Ativo")
                    throw new InvalidOperationException(
                        "Esta chapa está inativa."
                    );
                
                Aluno? aluno = null;

                if (alunoId.HasValue)
                {
                    aluno = conexao.Find<Aluno>(alunoId.Value);

                    if (aluno is null)
                        throw new InvalidOperationException(
                            "Aluno não encontrado."
                        );

                    if (aluno.Status != "Ativo")
                        throw new InvalidOperationException(
                            "Este aluno não está ativo."
                        );
                    if (aluno.JaVotou)
                    {
                        throw new InvalidOperationException("Este aluno já votou.");
                    }
                }

                var voto = new Voto
                {
                    AlunoId = alunoId,
                    ChapaId = chapaId,
                    DataHora = DateTime.Now
                };

                conexao.Insert(voto);

                if (aluno is not null)
                {
                    aluno.JaVotou = true;
                    conexao.Update(aluno);
                }
            });
        }

        public async Task<List<Voto>> ObterVotosAsync()
        {
            await InicializarAsync();

            return await database!
                .Table<Voto>()
                .OrderByDescending(v => v.DataHora)
                .ToListAsync();
        }

        public async Task<List<RelatorioVoto>> ObterRelatorioNominalAsync()
        {
            await InicializarAsync();

            string sql = """
                SELECT
                    v.Id AS VotoId,
                    a.Ra AS Ra,
                    COALESCE(a.Nome, 'Sem identificação'),
                    a.Turma AS Turma,
                    c.Numero AS NumeroChapa,
                    c.Nome AS ChapaNome,
                    v.DataHora AS DataHora
                FROM Voto v
                LEFT JOIN Aluno a 
                    ON v.AlunoId = a.Id
                INNER JOIN Chapa c
                    ON v.ChapaId = c.Id
                ORDER BY v.DataHora DESC
                """;

            return await database!.QueryAsync<RelatorioVoto>(sql);
        }

        public async Task<List<ResumoChapa>> ObterResumoPorChapaAsync()
        {
            await InicializarAsync();

            string sql = """
                SELECT
                    c.Numero AS Numero,
                    c.Nome AS Nome,
                    COUNT(v.Id) AS TotalVotos
                FROM Chapa c
                LEFT JOIN Voto v
                    ON v.ChapaId = c.Id
                GROUP BY
                    c.Id,
                    c.Numero,
                    c.Nome
                ORDER BY TotalVotos DESC, c.Numero ASC
            """;

            return await database!
                .QueryAsync<ResumoChapa>(sql);
        }
    }
}