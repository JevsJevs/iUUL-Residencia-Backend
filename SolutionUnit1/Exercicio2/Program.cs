// See https://aka.ms/new-console-template for more information
//using static Exercicio2.Vertice;
using Exercicio2;

Console.WriteLine("Hello, World!");

Vertice vtxUm = new Vertice(1.0,2.0);
Vertice vtxDois = new Vertice(2.0, 4.0);

Console.WriteLine(vtxUm.ToString());
Console.WriteLine(vtxDois.ToString());
Console.WriteLine($"A distancia dos dois vertices é {vtxUm.Distancia(vtxDois).ToString(".00")}");
vtxUm.Move(5.0, 5.0);
Console.WriteLine($"A nova posição do vertice 1 é {vtxUm.ToString()}");

Vertice vtxTres = new Vertice(2.0, 4.0);

if(vtxUm.IsEqual(vtxTres)) {
    Console.WriteLine("O vertice 1 é igual ao vertice 3");
}
else {
    Console.WriteLine("O vertice 1 e 3 sao diferentes");
}



