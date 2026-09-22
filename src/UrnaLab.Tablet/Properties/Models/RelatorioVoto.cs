using System;
using System.Collections.Generic;
using System.Text;

namespace UrnaLab.Tablet.Properties.Models
{
    public class RelatorioVoto
    {
        public int VotoId { get; set; }
        public string Ra { get; set; } = "";
        public string AlunoNome { get; set; } = "";
        public string Turma { get; set; } = "";
        public int NumeroChapa { get; set; }
        public string ChapaNome { get; set; } = "";
        public DateTime DataHora { get; set; }
    }
}
