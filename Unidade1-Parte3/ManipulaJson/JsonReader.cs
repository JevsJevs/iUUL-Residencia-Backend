using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace ManipulaJson {
    internal class JsonReader {

        public string FilePath { get; private set; }

        public JsonReader(string filePath) {
            FilePath = filePath;
        }

        /**
         * 
        current.GetProperty("nome"),
        current.GetProperty("cpf"),
        current.GetProperty("renda_mensal"),
        current.GetProperty("estado_civil"),
        current.GetProperty("dt_nascimento"),
        current.GetProperty("dep")
        **/

        class Test {
            public string Nome { get; set; }
            public string Cpf { get;  set; }
            public string Dt_Nascimento { get;  set; }
            public string Renda_Mensal { get;  set; }
            public string Estado_Civil { get;  set; }
            public string Dependentes { get;  set; }


            public Test(string nome, string cpf, string dataNasc, string renda, string estadoCiv, string dep) {
                Nome = nome;
                Cpf = cpf;
                Dt_Nascimento = dataNasc;
                Renda_Mensal= renda;
                Estado_Civil= estadoCiv;
                Dependentes= dep;
            }
        }
        public List<StringedCliente> LerJson() {
            List<StringedCliente> retorno = new List<StringedCliente>();
            string conteudo = File.ReadAllText(FilePath);

            //https://zetcode.com/csharp/json/
            JsonDocument documento = JsonDocument.Parse(conteudo);
            JsonElement raiz = documento.RootElement;

            List<StringedCliente> test = JsonSerializer.Deserialize<List<StringedCliente>>(raiz);


            Console.WriteLine(test.ToString());

            return null;
        }


    }
}
