using UrnaLab.Tablet.Models;
using UrnaLab.Tablet.Data;

namespace UrnaLab.Tablet;

public partial class CadastroAlunoPage : ContentPage
{
    private readonly AlunoDatabase alunoDatabase = new();
    public CadastroAlunoPage()
    {
        InitializeComponent();

        pickerStatus.SelectedIndex = 0; // Define o índice selecionado como 0 (Ativo)

        pickerStatus.Items.Add("Ativo");
        pickerStatus.Items.Add("Inativo");
    }

    private async void btnSalvar_Click(object? sender, EventArgs e)
    {
        string nome = txtNome.Text?.Trim() ?? "";
        string ra = txtRa.Text?.Trim() ?? "";
        string turma = txtTurma.Text?.Trim() ?? "";
        string status = pickerStatus.SelectedItem?.ToString() ?? "Ativo";

        if (string.IsNullOrWhiteSpace(nome) ||
            string.IsNullOrWhiteSpace(ra) ||
            string.IsNullOrWhiteSpace(turma))
        {
            await DisplayAlert(
                "Campos obrigatórios",
                "Preencha nome, RA e turma.",
                "OK");

            return;
        }

        var aluno = new Aluno
        {
            Nome = nome,
            Ra = ra,
            Turma = turma,
            Status = status
        };

        try
        {
            await alunoDatabase.CadastrarAsync(aluno);

            await DisplayAlert(
                "Cadastro realizado",
                "Aluno cadastrado com sucesso.",
                "OK");

            await Shell.Current.GoToAsync("..");
        }

        catch (SQLite.SQLiteException)
        {
            await DisplayAlert(
                "Erro de cadastro",
                "Ocorreu um erro ao cadastrar o aluno. Verifique se o RA já está cadastrado.",
                "OK");
        }
    }

    private async void btnCancelar_Click(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}
