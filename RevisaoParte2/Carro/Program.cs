// See https://aka.ms/new-console-template for more information

using Carro;

Motor m = new Motor(1.7f);

Console.WriteLine(m.ToString());

Carro car = new Carro("abc124", "monza", m);

Console.WriteLine(car.ToString());

