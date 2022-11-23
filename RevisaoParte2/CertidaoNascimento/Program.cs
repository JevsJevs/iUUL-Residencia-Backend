// See https://aka.ms/new-console-template for more information

using CertidaoNascimento;

Pessoa p = new Pessoa("Jorge");

Console.WriteLine(p.ToString());

DateTime dataEmissaoQualquer = new DateTime(2000, 01, 24);

try {
    Certidao c = new Certidao(null, dataEmissaoQualquer);
}
catch(Exception e) {
    Console.WriteLine("Tentei criar Certificado sem uma pessoa\n");
    Console.Write(e.ToString() + "\n\n");
}

Certidao cert = new Certidao(p, dataEmissaoQualquer);

Console.WriteLine(cert.ToString());

Console.WriteLine(p.ToString());


