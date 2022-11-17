// See https://aka.ms/new-console-template for more information
using Exercicio5;

Console.WriteLine("Hello, World!");

DateTime dt1 = DateTime.Now;
DateTime dt2 = dt1.AddDays(5);
DateTime dt3 = dt1.AddDays(2);
DateTime dt4 = dt3.AddDays(4);

Intervalo t1 = new Intervalo(dt1, dt2);
Intervalo t2 = new Intervalo(dt3, dt4);

Console.WriteLine(t1.ToString() + "\n\n");
Console.WriteLine(t2.ToString() + "\n\n");

if(t1.TemIntersecao(t2))
    Console.WriteLine("t1 e t2 tem intersecção!\n\n");
else
    Console.WriteLine("Sem intersecçao\n\n");

Intervalo t3= new Intervalo(dt1.AddDays(10), dt2.AddDays(10));

if(t1.TemIntersecao(t3))
    Console.WriteLine("t1 e t3 tem intersecção!\n\n");
else
    Console.WriteLine("Sem intersecçao\n\n");

// Data com entrada invalida
try {
    Intervalo t4 = new Intervalo(dt1.AddDays(10), dt2);
}
catch(Exception e) {
    Console.WriteLine(e.Message + e.ToString());
}

//Duracao periodo 1
Console.WriteLine("\n\nDuração do periodo 1: " + t1.Duracao().ToString());



