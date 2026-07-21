using Microsoft.Data.Sqlite;

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
                Status TEXT NOT NULL
            );
        ";

        using SqliteCommand comando = conexao.CreateCommand();

        comando.CommandText = sql;
        comando.ExecuteNonQuery();
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
}