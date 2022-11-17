using Exercicio7;
using System.Text.RegularExpressions;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


//Candidato a novas melhorias:

string ValidaNome(string nome) {
    if (nome.Length < 5) {
        throw new ArgumentException("Por favor, preencha pelo menos 5 caracteres");
    }

    return nome;
}

long ValidaCpf(string cpf) {
    long retorno;
    if(cpf.Length != 11) {
        throw new ArgumentException("Por favor, preencha os 11 digitos apenas");
    }
    else {
        try { retorno = long.Parse(cpf); }
        catch(Exception e) { throw new FormatException("Favor usar apenas numeros"); }
    }

    return retorno;
}

DateTime ValidaData(string data) {
    Regex regex = new Regex(@"(([0-3])\d\/([0-1])\d\/([1-2])9?0\d{2})");
    if(!regex.IsMatch(data)) {
        throw new ArgumentException("Favor preencher valor válido: DD/MM/AAAA");
    }



    // dd/mm/aaaa
    int ano = int.Parse(data[6].ToString()) * 1000 + int.Parse(data[7].ToString()) * 100  + int.Parse(data[8].ToString()) * 10 + int.Parse(data[9].ToString());
    int mes = int.Parse(data[3].ToString())  * 10 + int.Parse(data[4].ToString()) ;
    int dia = int.Parse(data[0].ToString())  * 10 + int.Parse(data[1].ToString()) ;

DateTime nascimento = new DateTime(ano, mes, dia);

    TimeSpan idade = DateTime.Now - nascimento;

    if(idade.TotalDays < 6570) {
        throw new ArgumentException("Você precisa ser maior de idade");
    }

    return nascimento;
}

float ValidaRenda(string renda) {
    renda.Replace(",", ".");

    float retorno;
    try {
        retorno = float.Parse(renda);
    }
    catch(Exception e) {
        throw new FormatException("Favor preencher corretamente REAIS,CENTAVOS");
    }

    return retorno;
}

char ValidaEstadoCivil(string eCiv) {
    if(eCiv.Length > 1) {
        throw new ArgumentException("Favor preencher corretamente");
    }

    return eCiv[0];
}

int ValidaDependentes(string dep) {
    int retorno = 0;
    if(dep.Length > 3) {
        throw new ArgumentException("Favor preencher corretamente");
    }
    try {
        retorno = int.Parse(dep);
    }
    catch(Exception e) {
        throw new FormatException("Favor colocar dados válidos");
    }

    return retorno;
}

string nome, cpf, nasc, renda, estCiv, dep;

long okCpf;
DateTime okNasc;
float okRenda;
char okEstCiv;
int okDep;


bool ok = false;

do {

    Console.WriteLine("Digite seu nome (Min 5 letras)");
    nome = Console.ReadLine();
    try {
        nome = ValidaNome(nome);
        ok = true;
    }catch( Exception e) {
        Console.WriteLine("Error: " + e.Message);
    }

} while(!ok) ;

do {
    ok = false;
    Console.WriteLine("Digite seu cpf (Apenas digitos)");
    cpf = Console.ReadLine();
    try {
        okCpf = ValidaCpf(cpf);
        ok = true;
    }
    catch(Exception e) {
        Console.WriteLine("Error: " + e.Message);
    }

} while(!ok);

do {
    ok = false;

    Console.WriteLine("Digite sua data de nascimento (dd/MM/AAAA)");
    nasc = Console.ReadLine();
    try {
        okNasc = ValidaData(nasc);
        ok = true;
    }
    catch(Exception e) {
        Console.WriteLine("Error: " + e.Message);
    }

} while(!ok);

do {
    ok = false;
    Console.WriteLine("Digite sua renda mensal (0000,00) ");
    renda = Console.ReadLine();
    try {
        okRenda= ValidaRenda(renda);
        ok = true;
    }
    catch(Exception e) {
        Console.WriteLine("Error: " + e.Message);
    }

} while(!ok);

do {

    Console.WriteLine("Digite seu estado civil \n[C - Casadx]\n[S - Solteirx]\n[V - Viuvx]\n[D - Divorciadx]");
    estCiv = Console.ReadLine();
    try {
        okEstCiv = ValidaEstadoCivil(nasc);
        ok = true;
    }
    catch(Exception e) {
        Console.WriteLine("Error: " + e.Message);
    }

} while(!ok);

do {
    ok = false;
    Console.WriteLine("Dependentes (Quantidade - apenas digitos)");
    dep = Console.ReadLine();
    try {
        okDep = ValidaDependentes(dep);
        ok = true;
    }
    catch(Exception e) {
        Console.WriteLine("Error: " + e.Message);
    }

} while(!ok);

//Cliente cli = new Cliente(nome, okCpf, okNasc, okRenda, okEstCiv, okDep);