// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string pathArquivo = "E:\\Projetos\\iUUL\\BackEnd\\iUUL-Residencia-Backend\\Unidade1-Parte3\\IndiceRemissivo\\texto.txt";

//IndiceRemissivo.IndiceRemissivo ind = new IndiceRemissivo.IndiceRemissivo(pathArquivo, null);

//ind.Imprime();

Console.WriteLine("=================================================================\n\t\tSEM AS PALAVRAS IGNORADAS AGORA");

string pathIgnore = "E:\\Projetos\\iUUL\\BackEnd\\iUUL-Residencia-Backend\\Unidade1-Parte3\\IndiceRemissivo\\ignore.txt";
IndiceRemissivo.IndiceRemissivo ind2 = new IndiceRemissivo.IndiceRemissivo(pathArquivo, pathIgnore);

ind2.Imprime();
