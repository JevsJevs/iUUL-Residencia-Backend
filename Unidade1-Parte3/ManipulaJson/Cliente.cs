using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManipulaJson {
    public class Cliente : IEquatable<Cliente> {

        public string Nome { get; set; }
        public long CPF { get; set; }
        public DateTime Dt_Nascimento { get; set; }
        public float Renda { get; set; }
        public char Estado_Civil { get; set; }
        public int Dependentes { get; set; }

        //Nunca usado
        public Cliente(string Nome, long CPF, DateTime nasc, float Renda, char Estado_Civil, int Dependentes) {
            this.Nome = Nome;
            this.CPF = CPF;
            this.Dt_Nascimento = nasc;
            this.Renda = Renda;
            this.Estado_Civil= Estado_Civil;
            this.Dependentes = Dependentes;
        }

        //Visivel somente para o namespace => chamada após ser feita a validacao
        internal Cliente(StringedCliente cli) {
            this.Nome = cli.nome;
            this.CPF = Convert.ToInt64(cli.cpf);
            this.Dt_Nascimento = Convert.ToDateTime(cli.dt_nascimento);
            this.Renda = Convert.ToSingle(cli.renda_mensal);
            this.Estado_Civil = Convert.ToChar(cli.estado_civil);
            this.Dependentes = Convert.ToInt32(cli.dependentes);
        }

        public bool Equals(Cliente? other) {
            if(other == null) return false;
            return other.CPF == this.CPF;
        }
    }
}
