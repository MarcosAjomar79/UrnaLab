using SQLite;
using UrnaLab.Tablet.Models;
using UrnaLab.Tablet.Services;
namespace UrnaLab.Tablet.Data
{
    public class ConfiguracaoEleicaoDatabase
    {
        private SQLiteAsyncConnection? database;
        private async Task InicializarAsync()
        {
            if (database is not null)
                return;

            string caminhoBanco = Path.Combine(FileSystem.AppDataDirectory, "urnalab.db");
            database = new SQLiteAsyncConnection(caminhoBanco);

            await database.CreateTableAsync<ConfiguracaoEleicao>();
            await database.CreateTableAsync<Voto>();
            await database.CreateTableAsync<Aluno>();
        }

        public async Task<ConfiguracaoEleicao> ObterConfiguracaoAsync()
        {
            await InicializarAsync();
            var configuracao = await database!.Table<ConfiguracaoEleicao>().FirstOrDefaultAsync();

            if (configuracao is null)
            {
                configuracao = new ConfiguracaoEleicao
                {
                    ModoVotacao = "Identificada",
                    
                };
                await database.InsertAsync(configuracao);
            }
            return configuracao;
        }
        public async Task<int> AtualizarAsync(ConfiguracaoEleicao configuracao)
        {
            await InicializarAsync();
            return await database!.UpdateAsync(configuracao);
        }

        public async Task ResetarEleicaoAsync()
        {
            await InicializarAsync();

            await database!.RunInTransactionAsync(conexao =>
            {
                conexao.DeleteAll<Voto>();
                conexao.Execute("UPDATE Aluno SET JaVotou = 0");
                var configuracao = conexao.Table<ConfiguracaoEleicao>().FirstOrDefault();

               
                if (configuracao is not null)
                {
                    configuracao.Status = "Aberta";
                    conexao.Update(configuracao);
                }
            });

        }
    }
}
