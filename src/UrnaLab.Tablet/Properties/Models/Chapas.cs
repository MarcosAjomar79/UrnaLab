using SQLite;

namespace UrnaLab.Tablet.Models;

public class Chapa
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [Unique]
    public int Numero { get; set; }

    public string Nome { get; set; } = "";

    public string Status { get; set; } = "Ativo";
}