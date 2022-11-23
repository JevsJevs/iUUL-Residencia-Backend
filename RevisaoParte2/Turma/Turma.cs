using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turma {
    internal class Turma {

        public Dictionary<int, Aluno> BaseAlunos { get; private set; }

        public Turma() {
            BaseAlunos = new Dictionary<int, Aluno>();
        }

        public Turma(Dictionary<int, Aluno> baseAlunos) {
            BaseAlunos = baseAlunos;
        }

        public void InserirAluno(Aluno aluno) {
            int id = aluno.Matricula;

            this.BaseAlunos.Add(id, aluno);
        }

        public void Imprimir() {
            List<Aluno> alunos= new List<Aluno>();


        }
    }
}
