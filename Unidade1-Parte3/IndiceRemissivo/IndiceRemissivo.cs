using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace IndiceRemissivo {
    internal class IndiceRemissivo {

        public SortedDictionary<string, OcorrenciaPalavra> Ocorrencias { get; set; }

        public IndiceRemissivo(string pathTxt, string pathIgnore) {
            Ocorrencias = new SortedDictionary<string, OcorrenciaPalavra>();

            if(!File.Exists(pathTxt)) throw new ArgumentException($"{pathTxt} não existe");
            if(pathIgnore != null && !File.Exists(pathIgnore)) throw new ArgumentException($"{pathIgnore} não existe");

            List<string> removeList = new List<string>();
            if(pathIgnore != null) {
                foreach(string linha in File.ReadLines(pathIgnore)) {
                    removeList.AddRange(linha.ToUpper().Split(" "));
                }
            }

            int counterLinha = 1;
            foreach(string linha in File.ReadLines(pathTxt)) {
                string[] palavras = SepararPalavras(linha, removeList);

                foreach(string palavra in palavras) {
                    if(Ocorrencias.ContainsKey(palavra))
                        Ocorrencias[palavra].IncrementaAparicao(counterLinha);
                    else
                        Ocorrencias.Add(palavra, new OcorrenciaPalavra(palavra));
                }

                counterLinha++;
            }
        }

        private string[] SepararPalavras(string linha, List<string> removeList) {
            
            string[] palavras = linha.Split(' ','.', ',', ';', '<', '>', ':', '\\', '/', '|', '~', '^', '´', '`', '[', ']', '}', '{', '}', '‘', '“', '!', '@', '#', '$','%', '&', '*', '(', ')', '_', '+', '=');

            List<string> palavrasListadas = new List<string>(palavras);
            palavrasListadas.RemoveAll(p => p.Length == 0);
            //Deixa todas as palavras maiusculas
            List<string> maiusculas = new List<string>();
            palavrasListadas.ForEach(palavra => maiusculas.Add(palavra.ToUpper()));

            //Acha todas as "palavras" que começam por numeros
            maiusculas.RemoveAll(palavra => (palavra[0] < 41 || palavra[0] > 90));
            
            //Remove palavras proibidas
            // TODO: Verificar se fazer essa verificação aqui é a forma ótima de resolver o problema
            if(removeList.Count() > 0)
                maiusculas.RemoveAll(palavra => removeList.Contains(palavra));

            return maiusculas.ToArray();
        }

        public void Imprime() {
            foreach(KeyValuePair<string, OcorrenciaPalavra> par in this.Ocorrencias){
                Console.WriteLine(par.Value.ToString());
                Console.WriteLine();
            }
        }
    }
}
