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

        public List<StringedCliente> LerJson() {
            List<StringedCliente> retorno = new List<StringedCliente>();
            string conteudo = File.ReadAllText(FilePath);

            //https://zetcode.com/csharp/json/
            JsonDocument documento = JsonDocument.Parse(conteudo);
            JsonElement raiz = documento.RootElement;

            retorno = JsonSerializer.Deserialize<List<StringedCliente>>(raiz);
            

            return retorno;
        }


    }
}
