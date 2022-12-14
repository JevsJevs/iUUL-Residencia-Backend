using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace AgendaDentista {
    internal class ScheduleDB {

        //CPF do paciente / Consulta
        public SortedDictionary<long, Consultation> Consultations { get; set; }

        public ScheduleDB() { 
            this.Consultations = new SortedDictionary<long, Consultation>();
        }

        //Agendar consulta
        public void ScheduleConsultation(PacientDB pacientDB) {
            string[] inputs = new string[4];
            string[] queries =  {
                "CPF: ",
                "Data da Consulta: ",
                "Hora inicial: ",
                "Hora final: "
            };

            //Solicita os dados do paciente na ordem do array querries, repete a solicitação se o dado for inválido
            // No caso do cpf verificamos se ele já está cadastrado no Banco (prop Store). Não abstraí isso para a classe validations para não complicar os parâmetros da função 
            for(int i = 0; i < queries.Length; i++) {
                string input;
                do {
                    Console.Write($"\n{queries[i]}");

                    // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-messages/nullable-warnings?f1url=%3FappId%3Droslyn%26k%3Dk(CS8600)
                    input = Console.ReadLine() ?? "";
                    inputs[i] = input;

                    //Validação de CPF já cadastrado => Se já houver cadastro substitui por um input inválido para a função de validação disparar
                    // + A regra de ter um agendamento por cliente
                    try {
                        if(i == 0 && pacientDB.Store.ContainsKey(Convert.ToInt64(input)) || this.Consultations.ContainsKey(Convert.ToInt64(input)))
                            input = "0";
                    }
                    catch(Exception) { input = "0"; }

                    //Verificação de disponibilidade de horario
                    try {
                        if(i == 0 && pacientDB.Store.ContainsKey(Convert.ToInt64(input)))
                            input = "0";
                    }
                    catch(Exception) { input = "0"; }


                } while(!ValidationUtils.ExecuteValidation(queries[i], input));
            }

            //instanciar Pacient
            Consultation consultation = new Consultation(inputs[0], inputs[1], inputs[2], inputs[3]);

            this.Consultations.Add(consultation.PatientCPF, consultation);
        }


        //Cancelar agendamento
        public void CancelConsultation(PacientDB pacientDB) {
            string[] inputs = new string[4];
            string[] queries =  {
                "CPF: ",
                "Data da Consulta: ",
                "Hora inicial: ",
            };

            //Solicita os dados do paciente na ordem do array querries, repete a solicitação se o dado for inválido
            // No caso do cpf verificamos se ele já está cadastrado no Banco (prop Store). Não abstraí isso para a classe validations para não complicar os parâmetros da função 
            for(int i = 0; i < queries.Length; i++) {
                string input;
                do {
                    Console.Write($"\n{queries[i]}");

                    input = Console.ReadLine() ?? "";
                    inputs[i] = input;

                    try {
                        if(i == 0 && pacientDB.Store.ContainsKey(Convert.ToInt64(input)))
                            input = "0";
                    }
                    catch(Exception) { input = "0"; }


                } while(!ValidationUtils.ExecuteValidation(queries[i], input));
            }


        }


        //Listar agendamento(Ordem de data e hora) 
        //Selecao de periodo ou toda agenda
    }
}
