// See https://aka.ms/new-console-template for more information
using Exercicio4;
using Exercicio2;

Vertice V1 = new Vertice(0.0,3.0);
Vertice V2 = new Vertice(0.0,0.0);
Vertice V3 = new Vertice(4.0,0.0);

Vertice[] lista = {V1, V2,V3};

Poligono pol = new Poligono(lista);

Console.WriteLine(pol.ToString());

//Removendo Vertices
try {
    pol.RemoveVertice(V1);
}catch(Exception ex) {
    Console.WriteLine(ex.ToString() + "\n\n");
}

//Adiciona vertices -> retangulo
Vertice V4 = new Vertice(3.0,4.0);

string adicao = pol.AddVertice(V4) ? "Sucesso" : "Fracasso";
Console.WriteLine("Adicionou? " + adicao); 

Console.WriteLine(pol.ToString());

//Qtd Vertices
Console.WriteLine("QtdVert: " + pol.QtdVert.ToString());