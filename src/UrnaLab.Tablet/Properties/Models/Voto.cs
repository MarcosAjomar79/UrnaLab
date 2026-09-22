using SQLite;

namespace UrnaLab.Tablet.Models;

public class Voto
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [Unique]
    public int AlunoId { get; set; }

    public int ChapaId { get; set; }

    public DateTime DataHora { get; set; }
}