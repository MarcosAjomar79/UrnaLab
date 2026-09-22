namespace UrnaLab.Tablet
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(PainelPage), typeof(PainelPage));

            Routing.RegisterRoute(nameof(AlunosPage), typeof(AlunosPage));
            Routing.RegisterRoute(nameof(CadastroAlunoPage), typeof(CadastroAlunoPage));

            Routing.RegisterRoute(nameof(ChapasPage), typeof(ChapasPage));
            Routing.RegisterRoute(nameof(CadastroChapaPage), typeof(CadastroChapaPage));

            Routing.RegisterRoute(nameof(LiberarVotacaoPage), typeof(LiberarVotacaoPage));

            Routing.RegisterRoute(nameof(VotacaoPage), typeof(VotacaoPage));

            Routing.RegisterRoute(nameof(RelatoriosPage), typeof(RelatoriosPage));
        }
    }
}
