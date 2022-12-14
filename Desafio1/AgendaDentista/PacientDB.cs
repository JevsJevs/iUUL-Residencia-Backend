using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDentista {
    internal class PacientDB {
        
        // CPF / Pacient
        public SortedDictionary<long, Pacient> Store { get; set; }

        public PacientDB() {
            this.Store = new SortedDictionary<long, Pacient>();        
        }

        //Cadastrar
        public void RegisterPacient() {
            string[] inputs = new string[3];
            string[] queries =  { 
                "CPF: ",
                "Nome: ",
                "Data de Nascimento: "
            };

            //Solicita os dados do paciente na ordem do array querries, repete a solicitação se o dado for inválido
            // No caso do cpf verificamos se ele já está cadastrado no Banco (prop Store). Não abstraí isso para a classe validations para não complicar os parâmetros da função 
            for(int i = 0; i < queries.Length; i++) {
                string input = "";
                do {
                    Console.Write($"\n{queries[i]}");

                    // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-messages/nullable-warnings?f1url=%3FappId%3Droslyn%26k%3Dk(CS8600)
                    input = Console.ReadLine() ?? "";
                    inputs[i] = input;

                    //Validação de CPF já cadastrado => Se já houver cadastro substitui por um input inválido para a função de validação disparar
                    try {
                        if(i == 0 && Store.ContainsKey(Convert.ToInt64(input)))
                            input = "0";
                    } catch(Exception) { input = "0"; }


                } while(!ValidationUtils.ExecuteValidation(queries[i], input));
            }

            //instanciar Pacient
            Pacient paciente = new Pacient(inputs[0], inputs[1], inputs[2]);
            
            this.Store.Add(paciente.CPF, paciente);
        }

        //Excluir
        private bool PatientIsRegistered(string cpf) {
            //if(!ValidationUtils.ExecuteValidation("CPF: ", cpf)) {
            //    return false;
            //}

            if(this.Store.ContainsKey(Convert.ToInt64(cpf))) {
                return true;
            }

            Console.WriteLine("Erro: paciente não cadastrado ");
            return false;
        }

        public void DeletePatient(ScheduleDB agenda) {
            string[] queries =  {
                "CPF: ",
            };

            //CPF deve existir no cadastro
            string input;
            do {
                input = Console.ReadLine() ?? "";
            } while(!PatientIsRegistered(input) || !ValidationUtils.ExecuteValidation("CPF: ", input));

            //Paciente nao pode ter consulta

        }

        //Listar por cpf
        //Listar por nome (Usar LINQ)



    }
}
