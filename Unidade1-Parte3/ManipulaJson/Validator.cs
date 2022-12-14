using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ManipulaJson {
    internal static class Validator {

        //Assumindo uma string de cpf com conteudo de numeros apenas
        private static Erro ValidaCpf(string cpf) {
            Regex rx = new Regex(@"(^\d{11}$)");
            if(!rx.Match(cpf).Success) return new Erro("CPF", "Formato de CPF inserido é inválido!");

            string sequenciaUm = cpf.Substring(0,9);
            string verificadores = cpf.Substring(9, 2);

            int somaParcialVerificadorUm = 0;
            int counter = 0;

            //https://stackoverflow.com/questions/239103/convert-char-to-int-in-c-sharp
            //Tabela ascii ao ataque
            for(int i = 10; i > 1; i--) {
                somaParcialVerificadorUm += (sequenciaUm[counter] - '0') * i;
                counter++;
            }


            int digitoJCalculado = somaParcialVerificadorUm % 11 < 2 ? 0 : 11 - (somaParcialVerificadorUm % 11);

            if(digitoJCalculado != (verificadores[0] - '0'))
                return new Erro("CPF", "O CPF inserido é invalido");

            int somaParcialVerificadorDois = 0;
            counter = 0;
            string sequenciaDois = sequenciaUm + digitoJCalculado.ToString();
            for(int i = 11; i > 1; i--) {
                somaParcialVerificadorDois += (sequenciaDois[counter] - '0') * i;
                counter++;
            }

            int digitoKCalculado = somaParcialVerificadorDois % 11 < 2 ? 0 : 11 - (somaParcialVerificadorUm % 11);

            if(digitoKCalculado != (verificadores[1] - '0'))
                return new Erro("CPF", "O CPF inserido é invalido"); ;

            return null;
        }

        private static Erro ValidaNome(string nome) {
            Regex rx = new Regex(@"(^[A-z]{5,}$)");
            if(!rx.Match(nome).Success) return new Erro("Nome", "Nome inserido é inválido!");

            return null;
        }

        private static Erro ValidaEstadoCivil(string estado) {
            Regex rx = new Regex(@"(^[C|S|V|D|c|s|v|d]{1}$)");
            if(!rx.Match(estado).Success) return new Erro("EstadoCivil", "Input Invalido!");
            return null;
        }

        private static Erro ValidaRenda(string renda) {
            Regex rx = new Regex(@"(^-?\d{1,},\d{2}$)");
            if(!rx.Match(renda).Success) return new Erro("RendaMensal", "Input Invalido!");

            float valor = float.Parse(renda.Replace(',','.'));
            if(valor < 0) return new Erro("Renda Mensal", "Renda Negativa!");

            return null;
        }

        private static Erro ValidaNascimento(string dataNasc) {
            Regex rx = new Regex(@"(^\d{2}\/\d{2}\/[1-2]\d{3}$)");
            if(!rx.Match(dataNasc).Success) return new Erro("DataNasc", "Input Invalido!");

            try {
                string[] separado = dataNasc.Split('/');
                int[] valores = { int.Parse(separado[0]), int.Parse(separado[1]), int.Parse(separado[2]) };

                DateTime data = new DateTime(valores[2],valores[1],valores[0]);
                if(data.CompareTo(DateTime.Now) > 0) return new Erro("DataNasc", "Data futura!");

                if(DateTime.Now.Subtract(data).TotalDays > 6570) return new Erro("DataNasc", "Menor de idade!");

                return null;
            }
            catch(ArgumentOutOfRangeException e) {
                return new Erro("DataNasc", "Data Inválida!");
            }
        }

        private static Erro ValidaDependente(string num) {
            Regex rx = new Regex(@"(^\d{2}$)");
            if(!rx.Match(num).Success) return new Erro("Dependente", "Input Invalido!");

            int valor = int.Parse(num);
            if(valor < 0 || valor > 10) return new Erro("Dependente", "Intervalo inválido. | Min 0 | Max 10 |");

            return null;
        }

        public static List<ItemErro> ValidaDados(List<StringedCliente> clientes) {
            List<ItemErro> erros = new List<ItemErro>();

            //Separarei as validacoes de campos pelo nome dos campos no JSON
            foreach(StringedCliente cli in clientes){
                List<Erro> dadosErrados = new List<Erro> {
                    ValidaNome(cli.nome),
                    ValidaCpf(cli.cpf),
                    ValidaEstadoCivil(cli.estado_civil),
                    ValidaRenda(cli.renda_mensal),
                    ValidaNascimento(cli.dt_nascimento),
                    ValidaDependente(cli.dependentes)
                };

                dadosErrados.RemoveAll(x => x == null);

                if(dadosErrados.Count > 0) {
                    erros.Add(new ItemErro(cli, dadosErrados));
                }
            }

            return erros;
        }

    }

}
