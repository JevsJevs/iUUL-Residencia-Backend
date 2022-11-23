using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertidaoNascimento {
    internal class Certidao {

        public DateTime DataEmissao { get; private set; }

        public Pessoa DonoCertidao { get; private set; }

        public Certidao(Pessoa portador, DateTime dataEmissao) {
            if(portador == null || portador.Nome == "") throw new ArgumentNullException();

            DonoCertidao = portador;
            DataEmissao = dataEmissao;
        }

        public override string ToString() {
            string resposta = $"A certidão é da pessoa {this.DonoCertidao.Nome}" +
                $" na data de {DataEmissao.Day}/{DataEmissao.Month}/{DataEmissao.Year}";

            return resposta;
        }
    }
}
