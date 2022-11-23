// See https://aka.ms/new-console-template for more information
using Progressao;

ProgressaoAritmetica pa = new ProgressaoAritmetica(1, 1);


Console.WriteLine("10 primeiros termos da PA:");
for(int i = 0; i < 10; i++) {
    Console.Write($" {pa.ProximoValor.ToString()} ");
}

Console.WriteLine($"\nTermo na posicao 100 da PA: {pa.TermoAt(100).ToString()} ");

ProgressaoGeometrica pg = new ProgressaoGeometrica(2,2);

Console.WriteLine("\n10 primeiros termos da PG:");
for(int i = 0; i < 5; i++) {
    Console.Write($" {pg.ProximoValor.ToString()} ");
}

Console.WriteLine($"\nTermo na posicao 8 da PG: {pg.TermoAt(8).ToString()} ");
