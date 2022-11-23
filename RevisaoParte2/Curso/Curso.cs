using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso {
    internal class Curso {

        public string Nome { get; private set; }
        public Dictionary<int, Aluno> Alunos { get; set; }
        public Dictionary<int, NewTurma> Turmas { get; set; }

        public Curso(string nome) {
            if(nome == null || nome.Length == 0) throw new ArgumentNullException("Um curso deve ter um nome!");
            Nome = nome;
            Alunos = new Dictionary<int, Aluno>();
            Turmas = new Dictionary<int, NewTurma>();
        }

        public void Matricular(Aluno aluno) {
            if(Alunos.ContainsKey(aluno.Matricula)) {
                throw new ArgumentException("Codigo de matricula duplicado!");
            }

            this.Alunos.Add(aluno.Matricula, aluno);
        }

        public void RemoverAluno(Aluno aluno) {
            if(Alunos.ContainsKey(aluno.Matricula)) {
                if(Turmas.ContainsKey(aluno.TurmaMatriculado))
                    throw new ArgumentException("O aluno não pode estar matriculado em uma turma");

                aluno.TurmaMatriculado = -1;

                return;
            }
            else throw new ArgumentException("Aluno não matriculado/encontrado");
        }

        public void CriarTurma(int codigo) {
            NewTurma novaTurma = new NewTurma(codigo);

            Turmas.Add(codigo, novaTurma);
        }

        public void RemoverTurma(int codigo) {
            if(Turmas.ContainsKey(codigo)) {
                if(Turmas[codigo].BaseAlunos.Count > 0) throw new ArgumentException("Nao pode fechar turma com alunos!");

                Turmas.Remove(codigo);
                return;
            }
            throw new ArgumentException("Turma nao encontrada");
        }

        public void ListarTurmas() {
            foreach(KeyValuePair<int, NewTurma> turma in Turmas) {
                if(turma.Value.BaseAlunos.Count > 0) {
                    Console.WriteLine("=================================================");
                    Console.WriteLine($"Turma: {turma.Key}");
                    turma.Value.ListarAlunos();
                }
            }
        }
    }
}
