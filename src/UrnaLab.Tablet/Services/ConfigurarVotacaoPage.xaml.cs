using SQLite;
using UrnaLab.Tablet.Models;
using UrnaLab.Tablet.Data;

namespace UrnaLab.Tablet;

public partial class ConfigurarVotacaoPage : ContentPage
{
    private readonly ConfiguracaoEleicaoDatabase configuracaoDatabase = new();
    public ConfigurarVotacaoPage()
	{
		InitializeComponent();
	}

	private async void btnIdentificada_Click(object? sender, EventArgs e)
	{
        var configuracao = await configuracaoDatabase.ObterConfiguracaoAsync();

		configuracao.Status = "Aberta";
        configuracao.ModoVotacao = "Identificada";

        await configuracaoDatabase.AtualizarAsync(configuracao);
        await Shell.Current.GoToAsync(nameof(VotacaoPage));
    }
	private async void btnAnonima_Click(object? sender, EventArgs e)
	{
		var configuracao = await configuracaoDatabase.ObterConfiguracaoAsync();

        configuracao.Status = "Aberta";
        configuracao.ModoVotacao = "Anonima";

		await configuracaoDatabase.AtualizarAsync(configuracao);
        await Shell.Current.GoToAsync(nameof(VotacaoPage));
    }
}