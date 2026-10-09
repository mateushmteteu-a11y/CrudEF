using CrudEF.Data;
using CrudEF.Models;
using Microsoft.EntityFrameworkCore;

var produto = await Produto.CreateProduto("Omega", 20222.99m, 100);

Console.WriteLine($"Produto ID: {produto.Id} - Nome do Produto: {produto.Nome} adicionado com sucesso");

foreach (var p in await Produto.ListarProdutos())
{
    Console.WriteLine($"ID: {produto.Id}, Nome: {produto.Nome}, Preco {produto.Preco}, Estoque: {produto.Estoque}");
}


// MENU DO SISTEMA
do
{
    Console.WriteLine("--- MENU ---");
    Console.WriteLine("1- Cadastrar Produto");
    Console.WriteLine("2- Listar Produtos");
    Console.WriteLine("3- Buscar Produto");
    Console.WriteLine("4- Atualizar Produto");
    Console.WriteLine("5- Excluir Produto");
    Console.WriteLine("0- SAIR");

    var opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
        Console.WriteLine("Digite o produto: ");
        string nome = Console.ReadLine() ?? string.Empty;

        Console.WriteLine("Digite o preco do produto: ");
        if(!decimal.TryParse(Console.ReadLine(), out decimal preco))
        {
            
            Console.WriteLine("Preco invalido");
            break;
        }
        decimal preco = decimal.Parse(Console.ReadLine() ?? "0");

        Console.WriteLine("Digite a quantidade em estoque: ");
        int estoque = int.Parse(Console.ReadLine() ?? "0");

    }
}while (true);