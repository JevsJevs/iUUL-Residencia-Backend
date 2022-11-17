using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exercicio7 {
    internal class Cliente {

        public string Nome { get; set; }
        public long CPF { get; set; }
        public DateTime DataNasc { get; set; }
        public float RendaMensal { get; set; }
        public char EstadoCivil { get; set; }
        public int Dependentes { get; set; }

        

        public Cliente(string nome, long cpf, DateTime data, float renda, char estCivil, int dependentes) {
            Nome = nome;
            CPF = cpf;
            DataNasc = data;
            RendaMensal = renda;
            EstadoCivil = estCivil;
            Dependentes = dependentes;
        }

        public override string ToString() {
            
            return $"{Nome} | {DataNasc.ToString()} | ";
        }
    }
}
