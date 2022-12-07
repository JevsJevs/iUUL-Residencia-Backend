using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidacaoCliente {
    internal class Erro {

        public string Campo { get; private set; }
        public string Mensagem { get; private set; }

        public Erro(string campo, string mensagem) {
            Campo = campo;
            Mensagem = mensagem;
        }
    }
}
