// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

/**
 * Sobre esse exercicio...

Não tive tempo de implementar, mas gostaria de deixar expressado
meu pensamento e lógica sobre como lidar com ele.

Criaria duas classes para resolver o exercicio;

-Validação:

Classe que contém métodos privados de validação de cada campo
e um método público "CamposInvalidos" que recebe uma Classe cliente e retorna um 
array com o nome dos campos invalidos

-Cliente:
	Tem os campos descritos no exercicio com a adicao de um campo
privado booleano "EValido".
	Construtor recebe valores quaisquer para qualquer campo e coloca
Evalido para falso.

	Essa classe tem o metodo "Validar" que invoca "Validacao.CamposInvalidos(this)"
e Solicita novamente essas informações para os clientes. Repete isso até a função campos
Invalidos retornar um array vazio, então, "Evalido" é alterado para true.
**/
