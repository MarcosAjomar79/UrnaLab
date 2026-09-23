using SQLite;
using UrnaLab.Tablet.Models;

namespace UrnaLab.Tablet.Data;

public class ChapaDatabase
{
    private SQLiteAsyncConnection? database;

    private async Task InicializarAsync()
    {
        if (database is not null)
            return;

        string caminhoBanco = Path.Combine(
            FileSystem.AppDataDirectory,
            "urnalab.db"
        );

        database = new SQLiteAsyncConnection(caminhoBanco);

        await database.CreateTableAsync<Chapa>();
    }

    public async Task<List<Chapa>> ObterChapasAsync()
    {
        await InicializarAsync();

        return await database!
            .Table<Chapa>()
            .OrderBy(c => c.Numero)
            .ToListAsync();
    }

    public async Task<Chapa?> ObterPorNumeroAsync(int numero)
    {
        await InicializarAsync();

        return await database!
            .Table<Chapa>()
            .Where(c => c.Numero == numero)
            .FirstOrDefaultAsync();
    }

    public async Task<Chapa?> ObterPorIdAsync(int id)
    {
        await InicializarAsync();

        return await database!
            .Table<Chapa>()
            .Where(a => a.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<int> CadastrarAsync(Chapa chapa)
    {
        await InicializarAsync();

        return await database!.InsertAsync(chapa);
    }

    public async Task<int> AtualizarAsync(Chapa chapa)
    {
        await InicializarAsync();
        return await database!.UpdateAsync(chapa);
    }

    public async Task<int> ExcluirAsync(Chapa chapa)
    {
        await InicializarAsync();
        return await database!.DeleteAsync(chapa);
    }
}