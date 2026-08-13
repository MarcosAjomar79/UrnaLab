using Microsoft.Data.Sqlite;
using System.Data;
using UrnaLab.App.Models;
using UrnaLab.App.Services;
namespace UrnaLab.App.Data;

public static class Database
{
    private static readonly string PastaBanco = Path.Combine(AppContext.BaseDirectory, "data");
    private static readonly string CaminhoBanco = Path.Combine(PastaBanco, "urnalab.db");

    public static SqliteConnection CriarConexao()
    {
        Directory.CreateDirectory(PastaBanco);

        return new SqliteConnection($"Data Source={CaminhoBanco}");
    }

    public static void CriarTabelas()
    {
        using SqliteConnection conexao = CriarConexao();

        conexao.Open();

        string sql = @"
            CREATE TABLE IF NOT EXISTS Alunos (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Ra TEXT NOT NULL UNIQUE,
                Nome TEXT NOT NULL,
                Turma TEXT NOT NULL,
                Status TEXT NOT NULL,
                JaVotou INTEGER NOT NULL DEFAULT 0
            );

           CREATE TABLE IF NOT EXISTS Chapas (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Numero TEXT NOT NULL UNIQUE,
                Nome TEXT NOT NULL,
                Status TEXT NOT NULL
            );

            CREATE TABLE IF NOT EXISTS Votos (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                AlunoId INTEGER NOT NULL UNIQUE,
                ChapaId INTEGER NOT NULL,
                DataHora TEXT NOT NULL,
                FOREIGN KEY (AlunoId) REFERENCES Alunos(Id),
                FOREIGN KEY (ChapaId) REFERENCES Chapas(Id)
            );

            CREATE TABLE IF NOT EXISTS Usuarios (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Usuario TEXT NOT NULL UNIQUE,
                Senha TEXT NOT NULL,
                Perfil TEXT NOT NULL,
                Ativo INTEGER NOT NULL DEFAULT 1
            );
        ";

        using SqliteCommand comando = conexao.CreateCommand();

        comando.CommandText = sql;

        comando.ExecuteNonQuery();

        bool colunaAlunoIdExiste = false;

        using (SqliteCommand verificarVotos = conexao.CreateCommand())
        {
            verificarVotos.CommandText = "PRAGMA table_info (Votos);";

            using SqliteDataReader leitorVotos = verificarVotos.ExecuteReader();

            while (leitorVotos.Read())
            {

                string nomeColuna = leitorVotos.GetString(1);

                if (nomeColuna == "AlunoId")
                {
                    colunaAlunoIdExiste = true;
                    break;
                }
            }
        }

        if (!colunaAlunoIdExiste)
        {
            using SqliteCommand corrigirVotos = conexao.CreateCommand();
            {
                corrigirVotos.CommandText = @"
                        DROP TABLE IF EXISTS Votos;

                        CREATE TABLE Votos (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            AlunoId INTEGER NOT NULL UNIQUE,
                            ChapaId INTEGER NOT NULL,
                            DataHora TEXT NOT NULL
                            FOREIGN KEY (AlunoId) REFERENCES Alunos(Id),
                            FOREIGN KEY (ChapaId) REFERENCES Chapas(Id)
                        );
                    ";

                corrigirVotos.ExecuteNonQuery();
            }
        }
        
        bool colunaJaVotouExiste = false;

        using (SqliteCommand verificarcoluna = conexao.CreateCommand())
        {
            verificarcoluna.CommandText = "PRAGMA table_info (Alunos);";

            using SqliteDataReader leitor = verificarcoluna.ExecuteReader();

            while (leitor.Read())
            {
                string NomeColuna = leitor.GetString(1);

                if (NomeColuna == "JaVotou")
                {
                    colunaJaVotouExiste = true;
                    break;
                }
            }
        }

        if (!colunaJaVotouExiste)
        {
            using SqliteCommand adicionarColuna = conexao.CreateCommand();

            adicionarColuna.CommandText =
                "ALTER TABLE Alunos ADD COLUMN JaVotou INTEGER NOT NULL DEFAULT 0;";

            adicionarColuna.ExecuteNonQuery();
        }
    }

    public static void InserirAluno(string ra, string nome, string turma, string status)
    {
        using SqliteConnection conexao = CriarConexao();

        conexao.Open();

        string sql = @"
            INSERT INTO Alunos (Ra, Nome, Turma, Status)
            VALUES (@ra, @nome, @turma, @status);
        ";

        using SqliteCommand comando = conexao.CreateCommand();

        comando.CommandText = sql;
        comando.Parameters.AddWithValue("@ra", ra);
        comando.Parameters.AddWithValue("@nome", nome);
        comando.Parameters.AddWithValue("@turma", turma);
        comando.Parameters.AddWithValue("@status", status);

        comando.ExecuteNonQuery();
    }

    public static DataTable ListarAlunos()
    {
        using SqliteConnection conexao = CriarConexao();

        conexao.Open();

        string sql = @"
            SELECT
            Id,
            Ra,
            Nome,
            Turma,
            Status,
            JaVotou
        FROM Alunos
        ORDER BY Nome;
";

        using SqliteCommand comando = conexao.CreateCommand();

        comando.CommandText = sql;

        using SqliteDataReader leitor = comando.ExecuteReader();

        DataTable tabela = new DataTable();
        tabela.Load(leitor);

        return tabela;
    }

    public static void InserirChapa(string numero, string nome, string status)
    {
        using SqliteConnection conexao = CriarConexao();

        conexao.Open();

        string sql = @"
            INSERT INTO Chapas (Numero, Nome, Status)
            VALUES (@numero, @nome, @status);
        ";

        using SqliteCommand comando = conexao.CreateCommand();

        comando.CommandText = sql;
        comando.Parameters.AddWithValue("numero", numero);
        comando.Parameters.AddWithValue("nome", nome);
        comando.Parameters.AddWithValue("status", status);

        comando.ExecuteNonQuery();

    }

    public static DataTable BuscarAlunoPorRa(string ra)
    {
        using SqliteConnection conexao = CriarConexao();

        conexao.Open();

        string sql = @"
            SELECT Id, Nome, Turma, Status, JaVotou
            FROM Alunos
            WHERE Ra = @ra
            LIMIT 1
        ";

        using SqliteCommand comando = conexao.CreateCommand();

        comando.CommandText = sql;
        comando.Parameters.AddWithValue("@ra", ra);

        using SqliteDataReader leitor = comando.ExecuteReader();

        DataTable tabela = new DataTable();
        tabela.Load(leitor);

        return tabela;
    }

    public static DataTable ListarChapas()
    {
        using SqliteConnection conexao = CriarConexao();
        conexao.Open();

        string sql = @"
            SELECT Id, Numero, Nome, Status
            FROM Chapas
            ORDER BY Nome
        ";

        using SqliteCommand comando = conexao.CreateCommand();

        comando.CommandText = sql;

        using SqliteDataReader leitor = comando.ExecuteReader();

        DataTable tabela = new DataTable();
        tabela.Load(leitor);

        return tabela;

    }

    public static DataTable ListarChapasAtivas()
    {
        using SqliteConnection conexao = CriarConexao();

        conexao.Open();

        string sql = @"
            SELECT Id, Numero, Nome
            FROM Chapas
            WHERE LOWER(TRIM(Status)) IN ('ativo', 'ativa')
            ORDER BY Numero
        ";

        using SqliteCommand comando = conexao.CreateCommand();
        comando.CommandText = sql;
        

        using SqliteDataReader leitor = comando.ExecuteReader();

        DataTable tabela = new DataTable();
        tabela.Load(leitor);

        return tabela;
    }

    public static ComprovanteVoto RegistrarVoto(
    int alunoId,
    int chapaId)
    {
        using SqliteConnection conexao = CriarConexao();
        conexao.Open();

        using SqliteTransaction transacao = conexao.BeginTransaction();

        try
        {
            string raAluno;
            string nomeAluno;
            string turmaAluno;

            using (SqliteCommand verificarAluno = conexao.CreateCommand())
            {
                verificarAluno.Transaction = transacao;

                verificarAluno.CommandText = @"
                SELECT Ra, Nome, Turma, Status, JaVotou
                FROM Alunos
                WHERE Id = @AlunoId
                LIMIT 1;
            ";

                verificarAluno.Parameters.AddWithValue(
                    "@AlunoId",
                    alunoId
                );

                using SqliteDataReader leitor =
                    verificarAluno.ExecuteReader();

                if (!leitor.Read())
                {
                    throw new InvalidOperationException(
                        "Aluno não encontrado."
                    );
                }

                raAluno = leitor.GetString(0);
                nomeAluno = leitor.GetString(1);
                turmaAluno = leitor.GetString(2);

                string statusAluno = leitor.GetString(3);
                long jaVotou = leitor.GetInt64(4);

                if (!string.Equals(
                    statusAluno.Trim(),
                    "Ativo",
                    StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidOperationException(
                        "O aluno está inativo."
                    );
                }

                if (jaVotou == 1)
                {
                    throw new InvalidOperationException(
                        "O aluno já votou uma vez."
                    );
                }
            }

            string numeroChapa;
            string nomeChapa;

            using (SqliteCommand verificarChapa = conexao.CreateCommand())
            {
                verificarChapa.Transaction = transacao;

                verificarChapa.CommandText = @"
                SELECT Numero, Nome
                FROM Chapas
                WHERE Id = @ChapaId
                AND LOWER(TRIM(Status)) IN ('ativo', 'ativa')
                LIMIT 1;
            ";

                verificarChapa.Parameters.AddWithValue(
                    "@ChapaId",
                    chapaId
                );

                using SqliteDataReader leitor =
                    verificarChapa.ExecuteReader();

                if (!leitor.Read())
                {
                    throw new InvalidOperationException(
                        "A chapa selecionada não está ativa."
                    );
                }

                numeroChapa = leitor.GetString(0);
                nomeChapa = leitor.GetString(1);
            }

            DateTime dataHora = DateTime.Now;
            long votoId;

            using (SqliteCommand inserirVoto = conexao.CreateCommand())
            {
                inserirVoto.Transaction = transacao;

                inserirVoto.CommandText = @"
                INSERT INTO Votos (
                    AlunoId,
                    ChapaId,
                    DataHora
                )
                VALUES (
                    @AlunoId,
                    @ChapaId,
                    @DataHora
                );
            ";

                inserirVoto.Parameters.AddWithValue(
                    "@AlunoId",
                    alunoId
                );

                inserirVoto.Parameters.AddWithValue(
                    "@ChapaId",
                    chapaId
                );

                inserirVoto.Parameters.AddWithValue(
                    "@DataHora",
                    dataHora.ToString("yyyy-MM-dd HH:mm:ss")
                );

                inserirVoto.ExecuteNonQuery();

                using SqliteCommand obterVotoId =
                    conexao.CreateCommand();

                obterVotoId.Transaction = transacao;

                obterVotoId.CommandText =
                    "SELECT last_insert_rowid();";

                votoId = Convert.ToInt64(
                    obterVotoId.ExecuteScalar()
                );
            }

            using (SqliteCommand atualizarAluno = conexao.CreateCommand())
            {
                atualizarAluno.Transaction = transacao;

                atualizarAluno.CommandText = @"
                UPDATE Alunos
                SET JaVotou = 1
                WHERE Id = @AlunoId
                AND JaVotou = 0;
            ";

                atualizarAluno.Parameters.AddWithValue(
                    "@AlunoId",
                    alunoId
                );

                atualizarAluno.ExecuteNonQuery();
            }

            transacao.Commit();

            return new ComprovanteVoto
            {
                VotoId = (int)votoId,
                RaAluno = raAluno,
                NomeAluno = nomeAluno,
                TurmaAluno = turmaAluno,
                NumeroChapa = numeroChapa,
                NomeChapa = nomeChapa,
                DataHora = dataHora
            };
        }
        catch
        {
            transacao.Rollback();
            throw;
        }
    }

    public static DataTable ListarVotosNominais()
    {
        using SqliteConnection conexao = CriarConexao();

        conexao.Open();

        string sql = @"
            SELECT
                V.Id AS VotoId,
                A.Ra AS RaAluno,
                A.Nome AS Aluno,
                A.Turma AS Turma,
                C.Numero AS NumeroChapa,
                C.Nome AS Chapa,
                V.DataHora As DataHora
            FROM Votos V
            INNER JOIN Alunos a
                ON a.Id = v.AlunoId
            INNER JOIN Chapas c
                ON c.Id = v.ChapaId
            ORDER BY V.DataHora;
        ";

        using SqliteCommand comando = conexao.CreateCommand();

        comando.CommandText = sql;

        using SqliteDataReader leitor = comando.ExecuteReader();

        DataTable tabela = new DataTable();
        tabela.Load(leitor);

        return tabela;
    }

    public static DataTable ListarResultadoPorChapa()
    {
        using SqliteConnection conexao = CriarConexao();

        conexao.Open();

        string sql = @"
        SELECT
            Chapas.Numero AS NumeroChapa,
            Chapas.Nome AS NomeChapa,
            COUNT(Votos.Id) AS TotalVotos
        FROM Chapas
        LEFT JOIN Votos ON Votos.ChapaId = Chapas.Id
        GROUP BY Chapas.Id, Chapas.Numero, Chapas.Nome
        ORDER BY TotalVotos DESC, Chapas.Numero;
    ";

        using SqliteCommand comando = conexao.CreateCommand();

        comando.CommandText = sql;

        using SqliteDataReader leitor = comando.ExecuteReader();

        DataTable tabela = new DataTable();

        tabela.Load(leitor);

        return tabela;
    }
    public static void CriarUsuariosPadrao()
    {
        using SqliteConnection conexao = CriarConexao();
        conexao.Open();

        using SqliteCommand comando = conexao.CreateCommand();

        comando.CommandText = @"
            INSERT OR IGNORE INTO Usuarios
                (Usuario, Senha, Perfil)
            VALUES
                (@Usuario, @Senha, @Perfil)
        ";

        comando.Parameters.AddWithValue("@Usuario", "admin");
        comando.Parameters.AddWithValue("@Senha", SenhaService.CriarHash("123"));
        comando.Parameters.AddWithValue("@Perfil", "Administrador");
        
        comando.ExecuteNonQuery();

        comando.Parameters.Clear();

        comando.Parameters.AddWithValue("@Usuario", "mesario");
        comando.Parameters.AddWithValue("@Senha", SenhaService.CriarHash("123"));
        comando.Parameters.AddWithValue("@Perfil", "Mesário");

        comando.ExecuteNonQuery();
    }

    public static string? ValidarUsuario(string usuario, string senhaDigitada)
    {
        using SqliteConnection conexao = CriarConexao();
        conexao.Open();

        using SqliteCommand comando = conexao.CreateCommand();

        comando.CommandText = @"
            SELECT Senha, Perfil
            FROM Usuarios
            WHERE Usuario = @Usuario
                AND Ativo = 1
            LIMIT 1
        ";

        comando.Parameters.AddWithValue("@Usuario", usuario);
        using SqliteDataReader leitor =
            comando.ExecuteReader();

        if (!leitor.Read())
        {
            return null;
        }

        string senhaArmazenada =
            leitor.GetString(0);

        string perfil =
            leitor.GetString(1);

        bool senhaValida =
            SenhaService.VerificarSenha(
                senhaDigitada,
                senhaArmazenada
            );

        if (!senhaValida)
        {
            return null;
        }

        return perfil;
    }

    public static DataTable BuscarChapaAtivaPorNumero(string numero)
    {
        DataTable tabela = new DataTable();

        using var conexao = CriarConexao();
        conexao.Open();

        using var comando = conexao.CreateCommand();

        comando.CommandText = @"
        SELECT Id, Numero, Nome, Status
        FROM Chapas
        WHERE Numero = $numero
          AND LOWER(TRIM(Status)) IN ('ativo', 'ativa')
        LIMIT 1;
    ";

        comando.Parameters.AddWithValue("$numero", numero);

        using var leitor = comando.ExecuteReader();

        tabela.Load(leitor);

        return tabela;
    }

}
