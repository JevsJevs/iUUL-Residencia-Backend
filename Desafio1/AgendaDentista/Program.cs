// See https://aka.ms/new-console-template for more information
using AgendaDentista;
using System.Collections.Generic;
using System.Globalization;

PacientDB pacientDB = new PacientDB();
ScheduleDB  scheduleDB = new ScheduleDB();

//=============================MOCK DE PERSISTENCIA DE DADOS=============================
//Pacient pct1 = new Pacient("05966866090", "Joseph Joestar", "01/01/2000");
//Appointment apt1 = new Appointment("05966866090", "02/12/2022", "14:00", "15:30");
//Appointment apt2 = new Appointment("05966866090", "03/12/2022", "14:00", "15:30");
//pacientDB.Store.Add(22188921895, pct1);
//scheduleDB.AppointmentList.Add(apt1);
//scheduleDB.AppointmentList.Add(apt2);
//=======================================================================================
void PacientRegistryMenu() {
    string input;
    int command;
    bool leave = false;

    do {
        Console.WriteLine();
        Console.WriteLine("Menu do Cadastro de Pacientes");
        Console.WriteLine("1 - Cadastrar novo paciente");
        Console.WriteLine("2 - Excluir paciente");
        Console.WriteLine("3 - Listar pacientes(ordenado por CPF)");
        Console.WriteLine("4 - Listar pacientes(ordenado por nome)");
        Console.WriteLine("5 - Voltar p / menu principal");

        input = Console.ReadLine() ?? "";
        //Não aceita input vazio -> substitue por valor inválido
        input = input == "" ? "-1" : input;

        command = input[0] - '0';

        switch(command) {
            case 1: pacientDB.RegisterPacient(); break;
            case 2: pacientDB.DeletePatient(scheduleDB) ; break;
            case 3: pacientDB.PatientList(0, scheduleDB); break;
            case 4: pacientDB.PatientList(1, scheduleDB); break;
            case 5: leave = true;  break;
            default: leave = false; break;
        }

    } while(command > 5 || command < 1 || !leave);

}

void ScheduleMenu() {
    string input;
    int command;
    bool leave = false;

    do {
        Console.WriteLine();
        Console.WriteLine("Agenda");
        Console.WriteLine("1 - Agendar consulta");
        Console.WriteLine("2 - Cancelar agendamento");
        Console.WriteLine("3 - Listar agenda");
        Console.WriteLine("4 - Voltar p / menu principal");

        input = Console.ReadLine() ?? "";
        //Não aceita input vazio -> substitue por valor inválido
        input = input == "" ? "-1" : input;

        command = input[0] - '0';

        switch(command) {
            case 1: scheduleDB.ScheduleAppointment(pacientDB); break;
            case 2: scheduleDB.CancelAppointment(pacientDB); break;
            case 3: scheduleDB.ScheduleList(pacientDB); break;
            case 4: leave = true; break;
            default: leave = false; break;
        }

    } while(command > 5 || command < 1 || !leave) ;
}

// Store do cadastro de usuarios (SortedDict)
// Store dos agendamentos


string input;
int command;
do {
    Console.WriteLine("Menu Principal");
    Console.WriteLine("1-Cadastro de Pacientes");
    Console.WriteLine("2-Agenda");
    Console.WriteLine("3-Fim\n");

    input = Console.ReadLine() ?? "";
    //Não aceita input vazio -> substitue por valor inválido
    input = input == "" ? "-1" : input;

    command = input[0] - '0';

    switch(command) {
        case 1: {
                PacientRegistryMenu();
                command = 0; 
                break;
        }
        case 2: {
                ScheduleMenu();
                command = 0;
                break;
        }
        case 3: System.Environment.Exit(0); break;

        default: break;
    }

} while(command > 3 || command < 1);

