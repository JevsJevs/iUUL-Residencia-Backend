using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace Curso {
    class NewTurma : Turma.Turma {

        public int Codigo { get; private set; }
        public Dictionary<int, Aluno> BaseAlunos { get; private set; }


        public NewTurma(int codigo) { 
            Codigo = codigo;
        }

        public NewTurma(int codigo, Dictionary<int, Aluno> alunos) { 
            Codigo = codigo;
            BaseAlunos = alunos;
        }  

        public void ListarAlunos() {
            // https://www.c-sharpcorner.com/UploadFile/mahesh/sort-a-dictionary-by-value-in-C-Sharp/

            foreach(KeyValuePair<int, Aluno> aluno in BaseAlunos.OrderBy(key => key.Value.Nome) {
                Console.WriteLine($"Aluno: {aluno.Value.Nome}\t Matricula: {aluno.Key}");
            }
        }
    }
}
