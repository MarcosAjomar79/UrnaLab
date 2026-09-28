using SQLite;

namespace UrnaLab.Tablet.Models
{
    public class ConfiguracaoEleicao
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string ModoVotacao { get; set; } = "Identificada";
        public string Status { get; set; } = "Aberta";
    }
}
