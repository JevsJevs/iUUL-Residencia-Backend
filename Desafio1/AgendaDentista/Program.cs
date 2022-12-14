// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using System.Globalization;

Console.WriteLine("Hello, World!");

Console.WriteLine($"{13 % 15}");

void PacientRegistryMenu() {
    string input;
    int command;
    do {
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
            case 1: break;
            case 2: break;
            case 3: break;
            case 4: break;
            case 5: break;
            default: break;
        }

    } while(command > 5 || command < 1);

}

void ScheduleMenu() {
    string input;
    int command;
    do {
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
            case 1: break;
            case 2: break;
            case 3: break;
            case 4: break;
            default: break;
        }

    } while(command > 5 || command < 1) ;
}

// Store do cadastro de usuarios (SortedDict)
// Store dos agendamentos


string input;
int command = 0;
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
//do {
//    input = Console.ReadLine() ?? "";
//} while(Convert.ToChar(input) - '0' < 4);
//// considional errada

//switch(input) {
//    case 1: {
//            break;
//        }
//    case 2: {
//            break;
//        }
//    default
//}
