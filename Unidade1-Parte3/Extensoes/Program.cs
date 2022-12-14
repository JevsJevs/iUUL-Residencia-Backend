// See https://aka.ms/new-console-template for more information
using Extensoes;
using ManipulaJson;

Console.WriteLine("Hello, World!");

int a = 1640;

Console.WriteLine(MetodosExtensao.IsArmstrong(a));

Console.WriteLine("Extensao RemoveRepeticao: \n");

List<int> b = new List<int>{ 1, 2, 3, 1, 4, 5, 4, 6, 7, 7};
List<string> c = new List<string> {"My", "Name", "is", "is", "is", "Jeff"};

Cliente cli = new Cliente("Jon", 11111111111, new DateTime(2000, 10, 01), 1000, 'C', 0);
Cliente cli2 = new Cliente("Hugh", 11111111111, new DateTime(2000, 10, 01), 1000, 'C', 0);
Cliente cli3 = new Cliente("Mathias", 22222222222, new DateTime(2000, 10, 01), 1000, 'C', 0);


List<Cliente> lClientes = new List<Cliente>{ cli, cli2, cli3 };

MetodosExtensao.RemoveRepetidos(b);
MetodosExtensao.RemoveRepetidos(c);
MetodosExtensao.RemoveRepetidos(lClientes);

foreach(int i in b) Console.Write($"{i}\t");
Console.WriteLine();
foreach(string i in c) Console.Write($"{i}\t");
Console.WriteLine();
foreach(Cliente i in lClientes) Console.Write($"{i.CPF}\t");

