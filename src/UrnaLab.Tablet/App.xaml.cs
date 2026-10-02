using Microsoft.Extensions.DependencyInjection;

namespace UrnaLab.Tablet
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            string temaSalvo = Preferences.Get("TemaSelecionado", "Sistema");

            if (temaSalvo is null)
                return;

            if (temaSalvo == "Escuro")
            {
                UserAppTheme = AppTheme.Dark;
            }
            else if (temaSalvo == "Claro")
            {
                UserAppTheme = AppTheme.Light;
            }
            else if (temaSalvo == "Sistema")
            {
                UserAppTheme = AppTheme.Unspecified;
            }

            else
            {
                UserAppTheme = AppTheme.Unspecified;
            }
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}