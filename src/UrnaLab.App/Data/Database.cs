using Microsoft.Data.Sqlite;
using System.Data;

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
}