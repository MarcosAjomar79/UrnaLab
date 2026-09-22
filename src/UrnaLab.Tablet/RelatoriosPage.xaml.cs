using UrnaLab.Tablet.Data;
using UrnaLab.Tablet.Models;
using UrnaLab.Tablet.Properties.Models;
using UrnaLab.Tablet.Services;
using System.Text;

namespace UrnaLab.Tablet;

public partial class RelatoriosPage : ContentPage
{
    private readonly VotoDatabase votoDatabase = new();
    private bool exibindoResumo = false;

    public RelatoriosPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await CarregarRelatoriosAsync();
    }

    private async Task CarregarRelatoriosAsync()
    {
        List<RelatorioVoto> votos =
            await votoDatabase.ObterRelatorioNominalAsync();

        List<ResumoChapa> resumo =
            await votoDatabase.ObterResumoPorChapaAsync();

        listaVotos.ItemsSource = votos;

        listaResumo.ItemsSource = resumo;

        lblTotalVotos.Text =
            $"Total de votos: {votos.Count}";
    }

    private void btnVotos_Click(object? sender, EventArgs e)
    {
        exibindoResumo = false;
        listaVotos.IsVisible = true;
        listaResumo.IsVisible = false;
    }

    private void btnResumo_Click(object? sender, EventArgs e)
    {
        listaVotos.IsVisible = false;
        listaResumo.IsVisible = true;
    }

    private async void btnImprimir_Click(object? sender, EventArgs e)
    {
        try
        {
            if (exibindoResumo)
            {
                List<ResumoChapa> resumo = await votoDatabase.ObterResumoPorChapaAsync();

                await RelatorioImpressaoService.ImprimirResumoAsync(resumo);
            }
            else
            {
                List<RelatorioVoto> votos = await votoDatabase.ObterRelatorioNominalAsync();
                await RelatorioImpressaoService.ImprimirVotosAsync(votos);
            }
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync(
                "Erro",
                $"Não foi possível abrir a impressão.\n{ex.Message}",
                "OK"
            );
        }
    }
    private async void btnExportar_Click(object? sender,EventArgs e)
    {
        try
        {
            if (exibindoResumo)
            {
                await ExportarResumoAsync();
            }
            else
            {
                await ExportarVotosAsync();
            }
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync(
                "Erro",
                $"Não foi possível exportar o relatório.\n{ex.Message}",
                "OK"
            );
        }
    }
    private async Task ExportarVotosAsync()
    {
        List<RelatorioVoto> votos =
            await votoDatabase.ObterRelatorioNominalAsync();

        var csv = new StringBuilder();

        csv.AppendLine(
            "RA;Aluno;Turma;NumeroChapa;Chapa;DataHora"
        );

        foreach (RelatorioVoto voto in votos)
        {
            csv.AppendLine(
                $"{voto.Ra};" +
                $"{voto.AlunoNome};" +
                $"{voto.Turma};" +
                $"{voto.NumeroChapa};" +
                $"{voto.ChapaNome};" +
                $"{voto.DataHora:dd/MM/yyyy HH:mm:ss}"
            );
        }

        string nomeArquivo =
            $"votos_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

        await CompartilharCsvAsync(
            nomeArquivo,
            csv.ToString()
        );
    }

    private async Task ExportarResumoAsync()
    {
        List<ResumoChapa> resumo =
            await votoDatabase.ObterResumoPorChapaAsync();

        var csv = new StringBuilder();

        csv.AppendLine(
            "Numero;Chapa;TotalVotos"
        );

        foreach (ResumoChapa chapa in resumo)
        {
            csv.AppendLine(
                $"{chapa.Numero};" +
                $"{chapa.Nome};" +
                $"{chapa.TotalVotos}"
            );
        }

        string nomeArquivo =
            $"resumo_chapas_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

        await CompartilharCsvAsync(
            nomeArquivo,
            csv.ToString()
        );
    }
    private async Task CompartilharCsvAsync(string nomeArquivo, string conteudo)
    {
        string caminhoArquivo = Path.Combine(FileSystem.CacheDirectory, nomeArquivo);

        await File.WriteAllTextAsync(caminhoArquivo, conteudo, new UTF8Encoding(true));
        
        if (!File.Exists(caminhoArquivo))
        {
            throw new Exception("Não foi possível criar o arquivo CSV.");
        }

        await Share.RequestAsync(new ShareFileRequest
            {
                Title = "Exportar relatório UrnaLab",

                File = new ShareFile(
                    caminhoArquivo,
                    "text/csv"
                )
            }
        );
    }
}