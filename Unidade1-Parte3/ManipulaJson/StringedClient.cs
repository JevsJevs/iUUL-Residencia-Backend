using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManipulaJson {
    //Essa classe tem o propósito de auxiliar na Deserialização
    internal class StringedCliente {
        public string nome { get; set; }
        public string cpf { get; set; }
        public string dt_nascimento { get; set; }
        public string renda_mensal { get; set; }
        public string estado_civil { get; set; }
        public string dependentes { get; set; }

    }
}
