using SQLite;

namespace UrnaLab.Tablet.Models
{
    public class Aluno
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Ra { get; set; } = "";
        public string Nome { get; set; } = "";

        public string Turma { get; set; } = "";
        public string Status { get; set; } = "Ativo";
        public bool JaVotou { get; set; } = false;
    }
}
