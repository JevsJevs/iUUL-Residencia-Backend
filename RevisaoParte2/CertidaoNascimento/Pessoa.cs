using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertidaoNascimento{
    internal class Pessoa {

        public string Nome { get; private set; }

        //o "?" significa que o valor pode ser null, ou não obrigatório -> reproduz a spec
        public Certidao? Certidao { get; private set; }

        public Pessoa(string nome) {
            if(nome == null) throw new ArgumentNullException("A pessoa deve ter um nome!");
            this.Nome = nome;
            this.Certidao = null;
        }

        public Pessoa(string nome, Certidao certidao) {
            if(nome == null || nome == "") throw new ArgumentNullException("A pessoa deve ter um nome!");
            if(certidao == null) throw new ArgumentException("A certidao fornecida não existe!");
            this.Nome = nome;
            this.Certidao = certidao;
        }


        public void AlterarNome(string newName) {
            if(this.Certidao == null) throw new Exception("Essa pessoa já tem certidão!");
            this.Nome = newName;
        }

        public override string ToString() {
            string resposta =  $"A pessoa se chama {this.Nome}";
            if(this.Certidao != null)
                resposta += " e é certificada";

            return resposta;
        }

    }

}

