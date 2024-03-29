﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progressao {
    internal class ProgressaoGeometrica : Progressao {


        public override int UltimoChamado { get; set; }
        public override int ProximoValor {
            get {
                int retorno = UltimoChamado * Razao;
                
                //if(UltimoChamado == 0) {
                //    retorno = Primeiro;
                //}
                    
                UltimoChamado = retorno;
                return UltimoChamado;
            }
        }


        public ProgressaoGeometrica(int primeiro, int razao) : base(primeiro, razao) {
            //UltimoChamado = 0;
            UltimoChamado = Convert.ToInt32(primeiro/razao);

        }

        public override int TermoAt(int posicao) {
            // Como só estamos aceitando inteiros (primeiro e razao) esse código permanece ok
            double res = Math.Pow(Razao, posicao - 1);
            return Convert.ToInt32(res * Primeiro);
        }
    }
}
