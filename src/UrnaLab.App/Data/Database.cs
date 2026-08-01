using Microsoft.Data.Sqlite;
using System.Data;
using UrnaLab.App.Models;
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
            SELECT Id, Ra, Nome, Turma, Status
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
            INNER JOIN Alunos A
                ON A.Id = AlunoId
            INNER JOIN Chapas C
                ON C.Id = ChapaId
            ORDER BY V.DataHora DESC;
        ";

        using SqliteCommand comando = conexao.CreateCommand();

        comando.CommandText = sql;

        using SqliteDataReader leitor = comando.ExecuteReader();

        DataTable tabela = new DataTable();
        tabela.Load(leitor);

        return tabela;
    }
}