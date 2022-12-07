using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManipulaJson {
    internal class StringedCliente {

        public string nome { get;private set; }
        public string cpf { get;private set; }
        public string dt_Nascimento { get;private set; }
        public string renda_Mensal { get;private set; }
        public string estado_Civil { get;private set; }
        public string dependentes { get;private set; }

        //public StringedCliente(string nome, string cpf, string renda, string estadoCiv, string dataNasc, string dep) {
        //    this.nome = nome;
        //    this.cpf = cpf;
        //    renda_Mensal = renda;
        //    estado_Civil = estadoCiv;
        //    dt_Nascimento = dataNasc;
        //    dependentes = dep;
        //}
    }
}
