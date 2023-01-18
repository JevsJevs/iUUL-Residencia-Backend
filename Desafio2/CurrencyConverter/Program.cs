using CurrencyConverter;

class ProgramDriver {
    static void Main(string[] args) {
        /**
         *Bom dia professor. Status report
         *Nessa atividade tive grande dificuldade na chamada de API por conta da natureza assincrona dos métodos
         *do HttpClient. Toda vez que uso um await é natural que o método seja async, no entanto, quando invoco esse método
         *dentro da do método main o código não compila por ser necessário ser estático e o async desrespeita isso. Estarei 
         *consumindo mais o conteúdo da alura para tentar resolver esse problema.
         *
         *Quanto a questão do recebimento e validação dos inputs. Estou ciente da minha falha de modelagem no paradigma de OOP
         *do desafio anterior. Desta vez estou tentando deixar a separação de funcionalidades clara para realizar isso na classe
         *"FormManager", estou usando classes internas por não conseguir ver um contexto que seja necessário um input, ou validação 
         *de input fora de um formulário. Ainda não consegui terminar essa etapa por conta de não ter conseguido modelar a regra de
         *validação de campos dependentes de respostas anterioes. Até então tenho consultado extensivamente as apresentações de reuniões
         *passadas para me auxiliar nesse processo
        **/ 
        ApiManager man = new ApiManager();

        await man.ExchangeCurrencyAPIAsync("BRL", "USD", "500.0");

        Console.WriteLine("APOS");
    }
}

