using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio1 {
    internal class Piramide {
        private int _n;

        public int N {
            get { return _n; }
            set {
                if(value >= 1) {
                    _n = value;
                    return;
                }
                throw new Exception("N deve ser maior ou igual a 1");
            }

        }

        public Piramide(int n) {
            N = n;
        }

        public void Desenha() {
            int degrau = 0;
            int limite = 1;
            for(int i = 0; i < N; i++) {
                for(int j = 0; j < N - 1 - degrau; j++) {
                    Console.Write(" ");
                }
                for(int j = 1; j < limite; j++) {
                    Console.Write(j.ToString());
                }
                for(int j = limite; j > 0; j--) {
                    Console.Write(j.ToString());
                }
                degrau++;
                limite++;
                Console.WriteLine();
            }
        }
    }
}
