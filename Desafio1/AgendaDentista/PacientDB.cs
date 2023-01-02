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

        //PacientValidation
        // Função auxiliar que contém peculiaridades de validação das regras de negócio de pacientes,
        // fazendo o uso dos utilitarios de validação do projeto
        // Retorna true se o dado for valido
        private bool PacientValidation(string query, string input) {
            bool isValid;

            try {
                isValid = query == "CPF: " ? !Store.ContainsKey(Convert.ToInt64(input)) : true;
                if(!isValid) Console.WriteLine("Paciente já cadastrado!");
            }
            catch {
                isValid = false;
            }

            return ValidationUtils.ExecuteValidation(query, input) && isValid;
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
                string input;
                do {
                    Console.Write($"\n{queries[i]}");

                    // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-messages/nullable-warnings?f1url=%3FappId%3Droslyn%26k%3Dk(CS8600)
                    input = Console.ReadLine() ?? "";
                    inputs[i] = input;

                } while(!PacientValidation(queries[i],input));
            }

            //instanciar Pacient
            Pacient paciente = new Pacient(inputs[0], inputs[1], inputs[2]);
            
            this.Store.Add(paciente.CPF, paciente);
        }

        public void DeletePatient(ScheduleDB scheduleDB) {
            string query = "CPF: ";

            bool DeletionValidation(string query, string input) {
                bool isValid = ValidationUtils.ExecuteValidation(query, input);
                if(isValid && !Store.ContainsKey(Convert.ToInt64(input))) {
                    Console.WriteLine("Erro: CPF não cadastrado");
                    isValid = false;
                }
                return isValid;
            }

            string cpfInput;
            do {
                Console.Write("\n"+query);
                cpfInput = Console.ReadLine() ?? "";
            } while(!DeletionValidation(query, cpfInput));

            long pacientCPF = Convert.ToInt64(cpfInput);

            //Remover Agendamentos anteriores e futuros
            var queryAllAppontments = from apt in scheduleDB.AppointmentList
                                      where apt.PatientCPF == pacientCPF
                                      select apt;

            List<Appointment> patientAppointments = new List<Appointment>();
            foreach(Appointment apt in queryAllAppontments) {
                patientAppointments.Add(apt);
            }

            //Insere uma nova lista com todos as consultas EXCETO aquelas do paciente sendo removido
            scheduleDB.AppointmentList = scheduleDB.AppointmentList.Except(patientAppointments).ToList();

            //Remover o paciente
            Store.Remove(pacientCPF);
        }

        //Listar por cpf
        //Listar por nome (Usar LINQ)
        public void PatientList(int tipo, ScheduleDB scheduleDB) {
            //https://learn.microsoft.com/en-us/dotnet/csharp/linq/perform-left-outer-joins
            //Selecionar pacientes e suas consultas futuras (se houverem)
            var queryConsultasFuturas = from apt in scheduleDB.AppointmentList
                                        where apt.StartingTime.CompareTo(DateTime.Now) > 0
                                        select apt;

            //Nas proximas consultas fazemos o join com a consulta anterior para termos o resultado desejado
            var queryPorNome = from pcte in Store
                               join apt in queryConsultasFuturas on pcte.Value.CPF equals apt.PatientCPF into pcteWithFutAppointement
                               from subApt in pcteWithFutAppointement.DefaultIfEmpty()
                               orderby pcte.Value.Nome
                               select new { pcte, appointment = subApt };


            var queryPorCpf = from pcte in Store 
                              join apt in queryConsultasFuturas on pcte.Value.CPF equals apt.PatientCPF into pcteWithAppointments
                              from subApt in pcteWithAppointments.DefaultIfEmpty()
                              orderby pcte.Key
                              select new { pcte, appointment = subApt};

            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("CPF         Nome                                     Dt.Nasc.   Idade");
            Console.WriteLine("---------------------------------------------------------------------");

            switch(tipo) {
                case 0: {
                        foreach(var item in queryPorCpf) {
                            Console.WriteLine($"{item.pcte.Value.ToString()}");
                            if(item.appointment != null) {
                                Console.WriteLine(new string(' ', 12)+ $"Agendado para: {item.appointment.StartingTime.ToString("dd/MM/yyyy")}");
                                Console.WriteLine(new string(' ', 12) + $"{item.appointment.StartingTime.ToString("HH:mm")} às {item.appointment.EndingTime.ToString("HH:mm")}");
                            }
                        }
                        break;
                    }
                case 1: {
                        foreach(var item in queryPorNome) {
                            Console.WriteLine($"{item.pcte.Value.ToString()}");
                            if(item.appointment != null) {
                                Console.WriteLine(new string(' ', 12) + $"Agendado para: {item.appointment.StartingTime.ToString("dd/MM/yyyy")}");
                                Console.WriteLine(new string(' ', 12) + $"{item.appointment.StartingTime.ToString("HH:mm")} às {item.appointment.EndingTime.ToString("HH:mm")}");
                            }
                        }
                        break;
                    }
                default: break;
            }
        }
    }
}
