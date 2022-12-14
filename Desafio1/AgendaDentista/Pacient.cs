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
    }
}
