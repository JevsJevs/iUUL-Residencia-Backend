using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AgendaDentista {
    internal static class ValidationUtils {

        private static bool ValidaCpf(string cpf) {
            Regex rx = new Regex(@"(^\d{11}$)");
            if(!rx.Match(cpf).Success) {
                Console.WriteLine("Erro: Formato de CPF inválido!");
                return false;
            }

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

            if(digitoJCalculado != (verificadores[0] - '0')) {
                Console.WriteLine("Erro: CPF inválido");
                return false;
            }

            int somaParcialVerificadorDois = 0;
            counter = 0;
            string sequenciaDois = sequenciaUm + digitoJCalculado.ToString();
            for(int i = 11; i > 1; i--) {
                somaParcialVerificadorDois += (sequenciaDois[counter] - '0') * i;
                counter++;
            }

            int digitoKCalculado = somaParcialVerificadorDois % 11 < 2 ? 0 : 11 - (somaParcialVerificadorDois % 11);

            if(digitoKCalculado != (verificadores[1] - '0')) {
                Console.WriteLine("Erro: CPF inválido");
                return false;
            }

            return true;
        }

        private static bool ValidaNascimento(string dataNasc) {
            Regex rx = new Regex(@"(^\d{2}\/\d{2}\/[1-2]\d{3}$)");
            if(!rx.Match(dataNasc).Success) {
                Console.WriteLine("Erro: Formato de  Data inválida");
                return false;
            }

            try {
                string[] separado = dataNasc.Split('/');
                int[] valores = { int.Parse(separado[0]), int.Parse(separado[1]), int.Parse(separado[2]) };

                DateTime data = new DateTime(valores[2],valores[1],valores[0]);
                if(data.CompareTo(DateTime.Now) > 0) {
                    Console.WriteLine("Erro: Data inválida");
                    return false;
                }

                if(DateTime.Now.Subtract(data).TotalDays < 4745) {
                    Console.WriteLine("Erro: Paciente deve ter pelo menos 13 anos");
                    return false;
                }

                return true;
            }
            catch {
                Console.WriteLine("Erro: Data inválida");
                return false;
            }
        }

        private static bool ValidaNome(string nome) {
            Regex rx = new Regex(@"(^[A-z ]{5,}$)");
            if(!rx.Match(nome).Success) {
                Console.WriteLine("Nome muito curto");
                return false;
            }

            return true;
        }


        private static bool ValidaFormatoData(string data) {
            Regex rx = new Regex(@"(^\d{2}\/\d{2}\/[1-2]\d{3}$)");
            if(!rx.Match(data).Success) {
                Console.WriteLine("Erro: Data inválida");
                return false;
            }
            return true;
        }

        private static bool ValidaData(string data) {
            if(!ValidaFormatoData(data))
                return false;

            try {
                string[] separado = data.Split('/');
                int[] valores = { int.Parse(separado[0]), int.Parse(separado[1]), int.Parse(separado[2]) };

                DateTime dateTime = new DateTime(valores[2],valores[1],valores[0]);
                if(dateTime.CompareTo(DateTime.Today) < 0) {
                    Console.WriteLine("Erro: Data inválida");
                    return false;
                }

                return true;
            }
            catch {
                Console.WriteLine("Erro: Data inválida");
                return false;
            }
        }

        private static bool ValidaHora(string dataNasc) {
            Regex rx = new Regex(@"(^\d{2}:\d{2}$)");
            if(!rx.Match(dataNasc).Success) {
                Console.WriteLine("Erro: Formato de hora inválido");
                return false;
            }

            try {
                short min = Convert.ToInt16(dataNasc.Substring(3));
                short hora = Convert.ToInt16(dataNasc.Substring(0, 2));

                if(min % 15 != 0 || min >= 60) {
                    Console.WriteLine("Erro: hora inválida");
                    return false;
                }

                if(hora < 8 || hora > 19) {
                    Console.WriteLine("Erro: fora de expediente");
                    return false;
                }

                return true;
            }
            catch {
                Console.WriteLine("Erro: Hora inválida");
                return false;
            }
        }

        private static bool ValidaTipoListarAgenda(string content) {
            Regex rx = new Regex(@"(^[TPtp])");
            if(!rx.Match(content.ToUpper()).Success) {
                Console.WriteLine("Erro: Input inválido - Escolha T ou P");
                return false;
            }

            return true;

        }

        /// <summary>
        /// To do: Refatorar as validações para não depender mais da query, e sim de um Id definido
        /// To do: Permitir mais de uma validação por campo -> ?Array de ID´s de validacao?
        /// </summary>
        /// <param name="query"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static bool ExecuteValidation(string query, string content) {
            switch(query) {
                case "CPF: ": return ValidaCpf(content);
                case "Data de Nascimento: ": return ValidaNascimento(content);
                case "Nome: ": return ValidaNome(content);

                case "Data do agendamento: ": return ValidaFormatoData(content);

                case "Data inicial: ": return ValidaFormatoData(content);
                case "Data final: ": return ValidaFormatoData(content);

                case "Data da Consulta: ": return ValidaData(content);
                case "Hora inicial: ": return ValidaHora(content);
                case "Hora final: ": return ValidaHora(content);

                case "Apresentar a agenda T-toda ou P-Periodo: ": return ValidaTipoListarAgenda(content);

                default: return false;
            }
        }
    }
}
