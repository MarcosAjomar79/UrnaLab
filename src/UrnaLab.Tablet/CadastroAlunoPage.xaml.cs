using UrnaLab.Tablet.Models;
using UrnaLab.Tablet.Data;

namespace UrnaLab.Tablet;


public partial class CadastroAlunoPage : ContentPage, IQueryAttributable
{

    private readonly AlunoDatabase alunoDatabase = new();
    private int? alunoIdEdicao;
    private Aluno? alunoEmEdicao;
    public CadastroAlunoPage()
    {
        InitializeComponent();

        pickerStatus.Items.Add("Ativo");
        pickerStatus.Items.Add("Inativo");
        pickerStatus.SelectedIndex = 0; // Define o índice selecionado como 0 (Ativo)

    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("alunoId", out object? valor))
        {
            if (int.TryParse(valor?.ToString(), out int id))
            {
                alunoIdEdicao = id;
            }
        }
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await CarregarAlunoParaEdicao();
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

        try
        {
            if (alunoEmEdicao is null)
            {
                var aluno = new Aluno
                {
                    Nome = nome,
                    Ra = ra,
                    Turma = turma,
                    Status = status
                };

                await alunoDatabase.CadastrarAsync(aluno);

                await DisplayAlert(
                    "Cadastro realizado",
                    "Aluno cadastrado com sucesso.",
                    "OK");

                
            }

            else
            {
                alunoEmEdicao.Nome = nome;
                alunoEmEdicao.Ra = ra;
                alunoEmEdicao.Turma = turma;
                alunoEmEdicao.Status = status;
                await alunoDatabase.AtualizarAsync(alunoEmEdicao);
                await DisplayAlert(
                    "Edição realizada",
                    "Aluno atualizado com sucesso.",
                    "OK");
                await Shell.Current.GoToAsync("..");
            }
        }

        catch (SQLite.SQLiteException)
        {
            await DisplayAlert(
                "Erro de cadastro",
                "Ocorreu um erro ao cadastrar o aluno. Verifique se o RA já está cadastrado.",
                "OK");
        }

    }

    public async Task CarregarAlunoParaEdicao()
    {
        if (alunoIdEdicao.HasValue)
        {
            alunoEmEdicao = await alunoDatabase.ObterPorIdAsync(alunoIdEdicao.Value);
            if (alunoEmEdicao != null)
            {
                txtNome.Text = alunoEmEdicao.Nome;
                txtRa.Text = alunoEmEdicao.Ra;
                txtTurma.Text = alunoEmEdicao.Turma;
                pickerStatus.SelectedItem = alunoEmEdicao.Status;

                Title = "Editar Aluno";
            }
        }
    }

    private async void btnCancelar_Click(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}
