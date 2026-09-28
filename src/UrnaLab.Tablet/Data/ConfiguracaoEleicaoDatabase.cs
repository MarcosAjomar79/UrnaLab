using SQLite;
using UrnaLab.Tablet.Models;

namespace UrnaLab.Tablet.Data
{
    public class ConfiguracaoEleicaoDatabase
    {
        private SQLiteAsyncConnection? database;

        private async Task InicializarAsync()
        {
            if (database is not null)
                return;

            string caminhoBanco = Path.Combine(FileSystem.AppDataDirectory, "urnalab.db");
            database = new SQLiteAsyncConnection(caminhoBanco);

            await database.CreateTableAsync<ConfiguracaoEleicao>();
        }

        public async Task<ConfiguracaoEleicao> ObterConfiguracaoAsync()
        {
            await InicializarAsync();
            var configuracao = await database!.Table<ConfiguracaoEleicao>().FirstOrDefaultAsync();

            if (configuracao is null)
            {
                configuracao = new ConfiguracaoEleicao
                {
                    ModoVotacao = "Identificada",
                    Status = "Aberta"
                };
                await database.InsertAsync(configuracao);
            }
            return configuracao;
        }
        public async Task<int> AtualizarAsync(ConfiguracaoEleicao configuracao)
        {
            await InicializarAsync();
            return await database!.UpdateAsync(configuracao);
        }
    }
}
