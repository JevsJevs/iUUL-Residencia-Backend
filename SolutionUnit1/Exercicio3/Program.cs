// See https://aka.ms/new-console-template for more information
using Exercicio2;
using Exercicio3;

Console.WriteLine("Hello, World!");

Vertice V1 = new Vertice(0.0,3.0);
Vertice V2 = new Vertice(0.0,0.0);
Vertice V3 = new Vertice(4.0,0.0);

Triangulo Triangulo = new Triangulo(V1,V2,V3);

Console.WriteLine(Triangulo.ToString());

//Verificar igualdade dos triangulos

// Triangulo congruente
Vertice V4 = new Vertice(5.0,8.0);
Vertice V5 = new Vertice(5.0,5.0);
Vertice V6 = new Vertice(9.0,5.0);

Triangulo T2 = new Triangulo(V4,V5,V6);

Console.WriteLine("\n\n" + T2.ToString() + "\n");

if(T2.IsEqual(Triangulo)) {
    Console.WriteLine("Os triangulos sao iguais");
}
else {
    Console.WriteLine("Os triangulos sao diferentes");
}

//Triangulo isosceles
Vertice V7 = new Vertice(0.0,4.0);
Vertice V8 = new Vertice(-3.0,0.0);
Vertice V9 = new Vertice(3.0,0.0);

Triangulo T3 = new Triangulo(V7,V8,V9);

Console.WriteLine("\n\n" + T3.ToString());

//Triangulo equilatero
Vertice V10 = new Vertice(0.0,3*Math.Sqrt(3));
Vertice V11 = new Vertice(-3.0,0.0);
Vertice V12 = new Vertice(3.0,0.0);

Triangulo T4 = new Triangulo(V10,V11,V12);

Console.WriteLine("\n\n" + T4.ToString());
