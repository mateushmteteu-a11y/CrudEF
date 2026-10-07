using CrudEF.Data;
using CrudEF.Models;
using Microsoft.EntityFrameworkCore;

var produto = await Produto.CreateProduto("Omega", 20222.99m, 100);

Console.WriteLine($"Produto ID: {produto.Id} - Nome do Produto: {produto.Nome} adicionado com sucesso");

foreach (var p in await Produto.ListarProdutos())
{
    Console.WriteLine($"ID: {produto.Id}, Nome: {produto.Nome}, Preco {produto.Preco}, Estoque: {produto.Estoque}");
}


static void Main(string[] args)
{

    while (true)
    {
    Console.WriteLine("--- MENU ---");
    Console.WriteLine("1- Cadastrar Produto");
    Console.WriteLine("2- Listar Produtos");
    Console.WriteLine("3- Buscar Produto");
    Console.WriteLine("4- Atualizar Produto");
    Console.WriteLine("5- Excluir Produto");
    Console.WriteLine("0- SAIR");
    }
}
