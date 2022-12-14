// See https://aka.ms/new-console-template for more information
using ManipulaJson;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

Console.WriteLine("Hello, World!");

string projectDir = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
JsonReader reader = new JsonReader(projectDir + "\\clientes.json");

List<StringedCliente> stringifiedClients = reader.LerJson();

List<ItemErro> retorno = ManipulaJson.Validator.ValidaDados(stringifiedClients);

string caminhoOutput = projectDir + "\\saida.json";
string jsonString = JsonSerializer.Serialize(retorno);

File.WriteAllText(caminhoOutput,jsonString);


