using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio1
{
    internal class Piramide
    {
        private int N;

        public int PublicN
        {
            get { return N; }
            set {
                if (value >= 1){
                    N = value;
                    return;
                }
                throw new Exception("N deve ser maior ou igual a 1");
            }

        }

        public void Desenha()
        {
            for(int i = 0; i < N; i++) { 
                Console.Write(i.ToString());
            }
            for(int i = 0; i < N; i--) { 
                Console.Write(i.ToString());
            }
        }
    }
    }



    }
}
