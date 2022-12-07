using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndiceRemissivo {
    internal class OcorrenciaPalavra {
        public string Palavra { get; private set; }
        public List<int> AparicoesLinhas { get; private set; }
        public int QtdAparicoes { get; private set; }

        public OcorrenciaPalavra(string palavra) {
            Palavra = palavra;
            AparicoesLinhas= new List<int>();
            QtdAparicoes= 1;
        }

        public void IncrementaAparicao(int linha) {
            QtdAparicoes++;

            if(!AparicoesLinhas.Contains(linha))
                AparicoesLinhas.Add(linha);
        }

        public override string ToString() {
            string retorno = $"{Palavra} ({QtdAparicoes})";
            foreach(int num in AparicoesLinhas)
                retorno += num.ToString()+", ";  

            return retorno;
        }
    }
}
