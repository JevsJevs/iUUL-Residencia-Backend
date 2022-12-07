// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string pathArquivo = "E:\\Projetos\\iUUL\\BackEnd\\iUUL-Residencia-Backend\\Unidade1-Parte3\\IndiceRemissivo\\texto.txt";

IndiceRemissivo.IndiceRemissivo ind = new IndiceRemissivo.IndiceRemissivo(pathArquivo, null);

ind.Imprime();
