namespace UrnaLab.Tablet
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            imgLogo.Opacity = 0;
            imgLogo.Scale = 0.85;

            lblTitulo.Opacity = 0;
            lblTitulo.TranslationY = 20;

            lblSubTitulo.Opacity = 0;
            lblSubTitulo.TranslationY = 20;

            btnIniciar.Opacity = 0;
            btnIniciar.TranslationY = 20;

            await Task.Delay(300);
            await Task.WhenAll(imgLogo.FadeToAsync(1, 700),
                imgLogo.ScaleToAsync(1, 500),

                lblTitulo.FadeToAsync(1, 400),
                lblTitulo.TranslateToAsync(0, 0, 400),

                lblSubTitulo.FadeToAsync(1, 350),
                lblSubTitulo.TranslateToAsync(0, 0, 450),

                btnIniciar.FadeToAsync(1, 350),
                btnIniciar.TranslateToAsync(0, 0, 450));
        }

        private async void btnIniciar_Click(object? sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(PainelPage));
        }
    }
}
