using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDentista {
    internal class Pacient {



        public long CPF { get; private set; }
        public string Nome { get; private set; }

        public DateTime DataNascimento { get; private set; }

        public Pacient(string cpf, string nome, string dataNascimento) {
            //Assume-se dados já passados na validação, para não pesar muito agora na execução
            // Para incrementar a seguranca validar aqui também
            CPF = Convert.ToInt64(cpf);
            Nome = nome;
            DataNascimento = Convert.ToDateTime(dataNascimento);
        }


        public override string ToString() {
            
            string fitToSizeName = Nome.Length > 40 ? Nome.Substring(0,37) + "..." : Nome + new string(' ', 40 - Nome.Length);

            //Por limitações das funcionalidades de time-span(Anos nem sempre tem o mesmo n de dias) esse valor é uma aproximação ~ +/-3dias
            int idade = DateTime.Now.Subtract(DataNascimento).Days / 365;

            return $"{CPF} {fitToSizeName} {DataNascimento.ToString("dd/MM/yyyy")} {idade}";
        }
    }
}
