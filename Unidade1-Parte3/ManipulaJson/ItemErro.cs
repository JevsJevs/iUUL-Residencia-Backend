using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManipulaJson {
    internal class ItemErro {
        public StringedCliente dados { get; private set; }
        public List<Erro> erros { get; private set; }

        public ItemErro(StringedCliente dados, List<Erro> erros) {
            this.dados = dados;
            this.erros = erros;
        }
    }
}
