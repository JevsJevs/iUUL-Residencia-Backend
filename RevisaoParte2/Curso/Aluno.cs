using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso {
    internal class Aluno : Turma.Aluno {

        private static int MatriculaGenerator;
        public int TurmaMatriculado { get; set; }
        public Aluno(string nome) : base(MatriculaGenerator, nome) {
            MatriculaGenerator += 1;
        }
    }
}
