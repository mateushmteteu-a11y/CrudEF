using CrudEF.Data;
using Microsoft.EntityFrameworkCore;
namespace CrudEF.Models;

public class Produto
{
    public int Id { get; set; }
    public string? Nome { get; set; } =string.Empty;
    public decimal? Preco { get; set; }
    public int? Estoque { get; set; }


    public static async Task<Produto> CreateProduto(string nome, decimal preco, int estoque)
    {
        await using var db = new AppDbContext();
        var produto = new Produto
        {
            Nome = nome,
            Preco = preco,
            Estoque = estoque
        };
        db.Produtos.Add(produto);
        await db.SaveChangesAsync();
        return produto;
    }

    public static async Task<List<Produto>> ListarProdutos()
    {
        await using var db = new AppDbContext();
        return await db.Produtos.ToListAsync();
    }

    public static async Task<List<Produto>> ProdutosValorMaiorQue(decimal quantidade)
    {
        await using var db = new AppDbContext();
        return await db.Produtos
        .Where(p =>p.Preco > quantidade)
        .ToListAsync();
    }

    public static async Task<List<Produto>> ProdutosEmOrdemAlfabetica()
    {
        await using var db = new AppDbContext();
        return await db.Produtos
        .OrderBy(p => p.Nome)
        .ToListAsync();
    }


    public static async Task<Produto?> BuscaPorNome(string nome)
    {
        await using var db = new AppDbContext();
        return await db.Produtos.FirstOrDefaultAsync(p => p.Nome == nome);
    }

    public static async Task<Produto?> BuscaPorId(int Id)
    {
        await using var db = new AppDbContext();
        return await db.Produtos.FindAsync(Id);
    }

    public static async Task AtualizarProduto(int id, Produto novoProduto)
    {
        await using var db = new AppDbContext();
        var produto = await db.Produtos.FindAsync(id);
        if(produto == null)
        {
            Console.WriteLine("Produto não encontrado");
            return;
        }
        produto.Nome = novoProduto.Nome ?? produto.Nome;
        produto.Preco = novoProduto.Preco ?? produto.Preco;
        produto.Estoque = novoProduto.Estoque ?? produto.Estoque;

        await db.SaveChangesAsync();
    }
    public static async Task DeletarProduto(int id)
    {
        await using var db = new AppDbContext();
        var produto = await db.Produtos.FindAsync(id);
        if(produto == null)
        {
            Console.WriteLine("Produto não encontrado");
            return;
        }

        db.Produtos.Remove(produto);
        await db.SaveChangesAsync();
    }
}
