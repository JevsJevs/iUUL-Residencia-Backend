using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turma{
    public class Aluno {
        public int Matricula { get; private set; }
        public string Nome { get; private set; }
        public float P1 { get; private set; }
        public float P2 { get; private set; }
        public float NF { get; private set; }

        public Aluno(int matricula, string nome) {
            Nome = nome;
            Matricula = matricula;

            //Diferenciar nota não inserida
            P1 = -1;
            P2 = -1;
            NF = -1;
        }

        //Assim que tiverem as duas notas lançadas já se calcula o valor de NF
        public void LancaNota(float nota, int tipoProva) {
            if(tipoProva != 1 && tipoProva != 2) {
                throw new ArgumentException("Só existe P1 e P2!");
            }

            if(tipoProva == 1) {
                P1 = nota;
                NF = P2 != -1 ? (nota + P2) / 2 : -1;
            }
            else {
                P2 = nota;
                NF = P1 != -1 ? (nota + P1) / 2 : -1;
            }
        }

        // Criar atributo que é calculado quando se insere a p1 e p2 ambas, antes disso NF é -1
        public float NotaFinal() {
            if(NF != -1) {
                return NF;
            }
            float p1 = P1 == -1 ? 0: P1;
            float p2 = P2 == -1 ? 0: P2;

            return (p1 + p2) / 2;
        }
    }
}