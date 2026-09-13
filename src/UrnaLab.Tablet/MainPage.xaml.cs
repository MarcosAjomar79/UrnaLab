namespace UrnaLab.Tablet
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnIniciar_Click(object? sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(PainelPage));
        }
    }
}
