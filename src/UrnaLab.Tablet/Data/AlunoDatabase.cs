using SQLite;
using UrnaLab.Tablet.Models;

namespace UrnaLab.Tablet.Data
{
    public class AlunoDatabase
    {
        private SQLiteAsyncConnection? database;

        private async Task InicializarAsync()
        {
            if (database is not null)
                return;

            string caminhoBanco = Path.Combine(FileSystem.AppDataDirectory, "urnalab.db");
            database = new SQLiteAsyncConnection(caminhoBanco);

            await database.CreateTableAsync<Aluno>();
        }

        public async Task<List<Aluno>> ObterAlunosAsync()
        {
            await InicializarAsync();
            return await database!
                .Table<Aluno>()
                .OrderBy(a => a.Nome)
                .ToListAsync();
        }

        public async Task<Aluno?> ObterPorIdAsync(int id)
        {
            await InicializarAsync();

            return await database!
                .Table<Aluno>()
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<Chapa?> ObterPorNumeroAsync(int numero)
        {
            await InicializarAsync();

            return await database!
                .Table<Chapa>()
                .Where(c => c.Numero == numero)
                .FirstOrDefaultAsync();
        }

        public async Task<int> CadastrarAsync(Aluno aluno)
        {
            await InicializarAsync();
            return await database!.InsertAsync(aluno);
        }

        public async Task<int> AtualizarAsync(Aluno aluno)
        {
            await InicializarAsync();
            return await database!.UpdateAsync(aluno);
        }

        public async Task<int> ExcluirAsync(Aluno aluno)
        {
            await InicializarAsync();
            return await database!.DeleteAsync(aluno);
        }
    }
}
