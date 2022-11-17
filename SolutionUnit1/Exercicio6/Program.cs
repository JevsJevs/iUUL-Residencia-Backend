// See https://aka.ms/new-console-template for more information
using Exercicio5;
using Exercicio6;

DateTime dt1 = DateTime.Now;
DateTime dt2 = dt1.AddDays(2);

DateTime dt3 = dt1.AddDays(3);
DateTime dt4 = dt1.AddDays(4);

Intervalo t1 = new Intervalo(dt1, dt2);
Intervalo t2 = new Intervalo(dt3, dt4);


List<Intervalo> lista = new List<Intervalo>{ t2, t1 };

ListaIntervalo myLista = new ListaIntervalo(lista);

myLista.Imprime();

//Data sem sobreposicao
DateTime dt5 = dt1.AddDays(6);
DateTime dt6 = dt1.AddDays(8);
Intervalo t3 = new Intervalo(dt5, dt6);

try {
    myLista.Add(t3);
}
catch(Exception ex) {
    Console.WriteLine("Erro inesperado: "+ex.ToString()+"\n\n");
}

Console.WriteLine("Adicionado valor valido: ");
myLista.Imprime();

//Data com sobreposicao
DateTime dt7 = dt1.AddDays(2);
DateTime dt8 = dt1.AddDays(10);
Intervalo t4 = new Intervalo(dt7,dt8);

Console.WriteLine("Tentado adicionar valor invalido: ");
try {
    myLista.Add(t4);
}
catch(Exception e) {
    Console.WriteLine("Erro: "+e.Message+"\n\n");
}

Console.WriteLine("Forma final");
myLista.Imprime();
