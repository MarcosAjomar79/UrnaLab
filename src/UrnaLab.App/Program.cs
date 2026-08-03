using UrnaLab.App.Data;

namespace UrnaLab.App;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Database.CriarTabelas();
        Database.CriarUsuariosPadrao();
        Application.Run(new TelaLogin());
    }    
}