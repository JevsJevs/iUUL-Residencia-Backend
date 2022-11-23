using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progressao {
    internal abstract class Progressao {

        public int Primeiro { get; set; }
        public int Razao { get; set; }
        public abstract int UltimoChamado { get; set; }
        public abstract int ProximoValor { get; }


        public Progressao(int primeiro, int razao) {
            Primeiro = primeiro;
            Razao = razao;
        }

        public void Reinicializar() { }

        public abstract int TermoAt(int posicao);
    }
}
