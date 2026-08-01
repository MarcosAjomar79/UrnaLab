using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace UrnaLab.App.Services
{
    public static class ExportadorRelatorio
    {
        public static void ExportarVotosNominais(
            DataTable votos,
            string caminhoarquivo)
        {
            StringBuilder conteudo = new StringBuilder();

            conteudo.AppendLine("URNA LAB - RELATÓRIO DE VOTOS NOMINAIS");
            conteudo.AppendLine($"Gerado em: {DateTime.Now:dd/MM/yyyy | HH:mm:ss}");
            conteudo.AppendLine($"Total de Votos: {votos.Rows.Count}");
            conteudo.AppendLine();

            foreach (DataRow linha in votos.Rows)
            {
                string ra = linha["RaAluno"]?.ToString() ?? "";
                string aluno = linha["Aluno"]?.ToString() ?? "";
                string turma = linha["Turma"]?.ToString() ?? "";
                string numeroChapa = linha["NumeroChapa"]?.ToString() ?? "";
                string chapa = linha["Chapa"]?.ToString() ?? "";
                string dataHora = linha["DataHora"]?.ToString() ?? "";

                conteudo.AppendLine(
                    $"RA: {ra} | " +
                    $"Aluno: {aluno} | " +
                    $"Turma: {turma} | " +
                    $"Chapa: {numeroChapa} - {chapa} | " +
                    $"Data e Hora: {dataHora}"
                );

            }

            File.WriteAllText(
                caminhoarquivo,
                conteudo.ToString(),
                Encoding.UTF8
            );
        }    
    }   
}
