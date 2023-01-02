using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace AgendaDentista {
    internal class ScheduleDB {

        public List<Appointment> AppointmentList { get; set; }

        public ScheduleDB() { 

            this.AppointmentList = new List<Appointment>();
        }

        /// <summary>
        /// Retorna true se o dado for válido
        /// </summary>
        /// <param name="query"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        private bool ScheduleValidation(string query, string input, string[] previousInputs, PacientDB pacientDB) {
            //Validações basicas de formato
            bool isValid = ValidationUtils.ExecuteValidation(query, input);

            //Validacoes mais complexas e de interdependência entre campos e registros dos bancos
            if(query == "CPF: " && isValid) {
                long patientCpf = Convert.ToInt64(input);

                isValid = pacientDB.Store.ContainsKey(patientCpf);
                if(!isValid) { Console.WriteLine("Erro: Paciente não Cadastrado"); return isValid; }
                
                //Max de um agendamento futuro <-> Podem haver n agendamentos passados
                int futureAppointments = (from apt in this.AppointmentList 
                                          where apt.PatientCPF == patientCpf && DateTime.Now.CompareTo(apt.StartingTime) < 0 
                                          select apt).Count();

                isValid = isValid && futureAppointments == 0;

                if(!isValid) Console.WriteLine("Erro: Ja ha agendamento futuro");
            }

            if(query == "Hora inicial: " && isValid) {
                DateTime StartTime = Utils.DateTimeApartToDateTime(previousInputs[1], input);

                //Conflito de horário ocorre quando o horário inicial ocorre após o inicio de outro atendomento e antes de seu fim
                var conflictCounter =  (from apt in this.AppointmentList 
                                        where apt.EndingTime.CompareTo(StartTime) > 0  && apt.StartingTime.CompareTo(StartTime) <= 0
                                        select apt).Count();


                isValid = isValid && conflictCounter == 0;
                if(!isValid) Console.WriteLine("Erro: Conflito de horário");
            }

            if(query == "Hora final: " && isValid) {
                DateTime StartTime = Utils.DateTimeApartToDateTime(previousInputs[1], previousInputs[2]);
                DateTime EndingTime = Utils.DateTimeApartToDateTime(previousInputs[1], input);

                isValid = isValid && StartTime.CompareTo(EndingTime) <= 0;
                if(!isValid) {
                    Console.WriteLine("Erro: horário final anterior ao inicial");
                    return isValid;
                }

                //Conflito de horário ocorre quando o horário final está após o inicio de outro atendimento e antes de seu fim
                int conflictCounter =  (from apt in this.AppointmentList 
                                        where apt.EndingTime.CompareTo(EndingTime) >= 0  && apt.StartingTime.CompareTo(EndingTime) < 0 
                                        select apt).Count();

                //Conflito de horário TAMBÉM ocorre quando o horário final é posterior a outro atendimento
                //SE o horario inicial ocorre antes do inicio desse outro atendimento
                conflictCounter += (from apt in this.AppointmentList
                                    where apt.StartingTime.CompareTo(StartTime) >= 0 && apt.EndingTime.CompareTo(EndingTime) <= 0
                                    select apt).Count();

                isValid = isValid && conflictCounter == 0;
                if(!isValid) Console.WriteLine("Erro: Conflito de horário");
            }

            return isValid;
        }

        //Agendar consulta
        public void ScheduleAppointment(PacientDB pacientDB) {
            string[] inputs = new string[4];
            string[] queries =  {
                "CPF: ",
                "Data da Consulta: ",
                "Hora inicial: ",
                "Hora final: "
            };

            //Solicita os dados do paciente na ordem do array querries, repete a solicitação se o dado for inválido
            //No caso do cpf verificamos se ele já está cadastrado no Banco (prop Store). Abstraí isso para a função ScheduleValidation
            for(int i = 0; i < queries.Length; i++) {
                string input;
                do {
                    Console.Write($"\n{queries[i]}");

                    // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-messages/nullable-warnings?f1url=%3FappId%3Droslyn%26k%3Dk(CS8600)
                    input = Console.ReadLine() ?? "";
                    inputs[i] = input;

                } while(!ScheduleValidation(queries[i], input, inputs, pacientDB));
            }

            Appointment consultation = new Appointment(inputs[0], inputs[1], inputs[2], inputs[3]);

            this.AppointmentList.Add(consultation);
        }


        //Cancelar agendamento
        public void CancelAppointment(PacientDB pacientDB) {
            string[] inputs = new string[3];
            string[] queries =  {
                "CPF: ",
                "Data do agendamento: ",
                "Hora inicial: ",
            };

            //Funcao local restrita nesse contexto para validação referente a essa regra de negócio
            bool CancelInputValidation(string query, string[] previousInputs , string input) {
                bool isValid = ValidationUtils.ExecuteValidation(query, input);

                if(isValid && query == "CPF: ") {
                    isValid = pacientDB.Store.ContainsKey(Convert.ToInt64(input));
                    if(!isValid) Console.WriteLine("Erro: CPF não cadastrado");
                }

                if(isValid && query == "Data do agendamento: ") {
                    DateTime date = Utils.DateTimeApartToDateTime(input, "00:00");
                    //data inserida deve ser de agendamento futuro
                    isValid = DateTime.Today.CompareTo(date) <= 0;
                    if(!isValid) {
                        Console.WriteLine("Erro: Data passada");
                        return isValid;
                    }

                    // Essa query nao pega o dia todo!
                    int appoitmentsOnDate = (from apt in AppointmentList
                                            where apt.StartingTime.CompareTo(date) >= 0 && apt.StartingTime.CompareTo(date.AddDays(1)) < 0
                                            select apt).Count();

                    if(appoitmentsOnDate <= 0) {
                        isValid = false;
                        Console.WriteLine("Erro: Sem agendamentos na data");
                    }
                }

                if(isValid && query == "Hora inicial: ") {
                    DateTime date = Utils.DateTimeApartToDateTime(previousInputs[1], input);
                    isValid = DateTime.Now.CompareTo(date) < 0;
                    if(!isValid) {
                        Console.WriteLine("Erro: Hora passada");
                        return isValid;
                    }

                    int appoitmentsOnDate = (from apt in AppointmentList
                                             where apt.StartingTime.CompareTo(date).Equals(0)
                                             select apt).Count();
                    if(appoitmentsOnDate <= 0) {
                        isValid = false;
                        Console.WriteLine("Erro: Sem agendamentos na hora");
                    }
                }

                return isValid;
            }

            //Solicita os dados do paciente na ordem do array querries, repete a solicitação se o dado for inválido
            // No caso do cpf verificamos se ele já está cadastrado no Banco (prop Store). Não abstraí isso para a classe validations para não complicar os parâmetros da função 
            for(int i = 0; i < queries.Length; i++) {
                string input;
                do {
                    Console.Write($"\n{queries[i]}");

                    input = Console.ReadLine() ?? "";
                    inputs[i] = input;

                } while(!CancelInputValidation(queries[i], inputs, input));
            }

            DateTime initialTimeToRemove = Utils.DateTimeApartToDateTime(inputs[1], inputs[2]);

            try {
                var appointmentSearch = from apt in AppointmentList
                                        where apt.StartingTime.CompareTo(initialTimeToRemove).Equals(0)
                                        select apt;
                Appointment aptToRemove = appointmentSearch.First();

                AppointmentList.Remove(aptToRemove);
            }
            catch(Exception ex) {
                Console.WriteLine("Erro: Ocorreu um erro na remoção");
            }
        }


        private bool ScheduleListValidation(string query, DateTime[] previousInput, string data) {
            bool isValid = ValidationUtils.ExecuteValidation(query, data);

            if(isValid && query == "Data final: ") {
                DateTime finalDate = Utils.DateTimeApartToDateTime(data, "00:00");
                DateTime initialDate = previousInput[0];

                if(initialDate.CompareTo(finalDate) > 0) {
                    Console.WriteLine("Erro: Data final anterior a inicial");
                    return false;
                }

            }

            return isValid;
        }

        //Listar agendamento(Ordem de data e hora) 
        //Selecao de periodo ou toda agenda
        public void ScheduleList(PacientDB pacientDB) {
            var queryAllAppointments = from apt in AppointmentList 
                             join pcte in pacientDB.Store on apt.PatientCPF equals pcte.Value.CPF 
                             orderby apt.StartingTime 
                             select new { apt, pcte };


            string typeQuery = "Apresentar a agenda T-toda ou P-Periodo: ";
            string content;

            string[] periodQuery = {"Data inicial: ", "Data final: "};

            bool leave = false;
            do {
                Console.WriteLine();
                Console.Write("\n" + typeQuery);
                content = Console.ReadLine() ?? "";
                content = content.ToUpper();

                switch(content) {
                    case "T": {
                            Console.WriteLine("-------------------------------------------------------------------------------");
                            Console.WriteLine("Data       H.Ini H.Fim Tempo Nome                                     Dt.Nasc. ");
                            Console.WriteLine("-------------------------------------------------------------------------------");
                            foreach(var item in queryAllAppointments) {
                                Console.WriteLine($"{item.apt} " +
                                    $"{item.apt.EndingTime.Subtract(item.apt.StartingTime).ToString(@"hh\:mm")} " +
                                    $"{item.pcte.Value.ToString().Substring(12,51)}");
                            }
                            leave = true;
                            break;
                        }
                    case "P": {
                            string input;
                            DateTime[] dates = new DateTime[2];
                            for(int i = 0; i < 2; i++) {
                                do {
                                    Console.Write("\n" + periodQuery[i]);
                                    input = Console.ReadLine() ?? "";
                                    //Checar dataini < dataFim aqui
                                } while(!ScheduleListValidation(periodQuery[i], dates, input));
                                //Horario nao importa nesse contexto. Portanto coloquei 00:00
                                dates[i] = Utils.DateTimeApartToDateTime(input, "00:00");
                            }

                            //Aqui vemos uma consulta nas ED de armazenamento trazendo valores dentro dos limites desejados.
                            //Note que adicionei um dia no ending time da query. Isso se dá pela escolha de 00:00 no horario mock da data
                            //Assim, levando em conta o expediente a consulta precisa englobar o dia final além das 00:00
                            var queryPeriod = from apt in AppointmentList
                                              where apt.StartingTime.CompareTo(dates[0]) > 0 && apt.EndingTime.CompareTo(dates[1].AddDays(1)) < 0
                                              join pcte in pacientDB.Store on apt.PatientCPF equals pcte.Value.CPF
                                              orderby apt.StartingTime
                                              select new { apt, pcte };

                            Console.WriteLine("-------------------------------------------------------------------------------");
                            Console.WriteLine("Data       H.Ini H.Fim Tempo Nome                                     Dt.Nasc. ");
                            Console.WriteLine("-------------------------------------------------------------------------------");

                            foreach(var item in queryPeriod)
                                Console.WriteLine($"{item.apt} " +
                                    $"{item.apt.EndingTime.Subtract(item.apt.StartingTime).ToString(@"hh\:mm")} " +
                                    $"{item.pcte.Value.ToString().Substring(12, 51)}");
                            leave = true;
                            break;
                        }
                    default: break;
                }


            } while(!ValidationUtils.ExecuteValidation(typeQuery, content) || !leave);

            
        }
    }
}

