using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progressao {
    internal class ProgressaoAritmetica : Progressao {

        public override int UltimoChamado { get; set; }

        public override int ProximoValor {
            get {
                int retorno = this.UltimoChamado + this.Razao;
                this.UltimoChamado = retorno;
                return retorno;
            }
        }


        public ProgressaoAritmetica(int primeiro, int razao) : base(primeiro, razao) {
            UltimoChamado = primeiro - razao;
        }


        public override int TermoAt(int posicao) {
            return this.Primeiro + (posicao - 1) * this.Razao;
        }

    }
}
