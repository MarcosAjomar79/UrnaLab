using System;
using System.Collections.Generic;
using System.Text;

namespace UrnaLab.App.Models
{
    public class ComprovanteVoto
    {
        public int VotoId { get; set; }

        public string RaAluno { get; set; } = "";

        public string NomeAluno { get; set; } = "";

        public string TurmaAluno { get; set; } = "";

        public string NumeroChapa { get; set; } = "";

        public string NomeChapa { get; set; } = "";

        public DateTime DataHora { get; set; }
    }
}
