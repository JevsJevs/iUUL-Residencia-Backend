using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercicio5;

namespace Exercicio6 {
    class ListaIntervalo {

        private List<Intervalo> _intervaloLista = new List<Intervalo>();
        public List<Intervalo> IntervaloLista { 
            get { return _intervaloLista; } 
            
            // readonly na prática
            private set {
                bool entradaValida = true;

                for(int i = 0; i < value.Count - 1; i++) {
                    for(int j = i + 1; j < value.Count; j++) {
                        if(value[i].TemIntersecao(value[j])) {
                            entradaValida = false; break;
                        }
                    }
                }

                if(entradaValida) {
                    _intervaloLista = value;
                }
                else throw new ArgumentException("A lista tem dados conflitantes");
            } 
        }
        public ListaIntervalo(List<Intervalo> lista) {
            IntervaloLista = lista;
        }

        public bool Add(Intervalo intervalo) {
            bool sucesso = true;
            for(int i = 0; i < IntervaloLista.Count; i++) {
                if(IntervaloLista[i].TemIntersecao(intervalo)) sucesso = false;
            }

            if(sucesso) { 
                IntervaloLista.Add(intervalo); 
            }
            else {
               throw new ArgumentException("O evento inserido está em conflito com a lista");
            }

            return sucesso;
        }

        public void Imprime() {
            List<Intervalo> ordenada = IntervaloLista.OrderBy(item => item.DataTempoIni).ToList();

            foreach(Intervalo intervalo in ordenada) {
                Console.WriteLine("==============\n"+intervalo.ToString()+"\n");
            }
        }
    }
}
