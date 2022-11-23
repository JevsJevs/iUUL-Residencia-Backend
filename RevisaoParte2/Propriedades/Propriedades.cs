using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Propriedades{
    internal class Propriedades {
        public Dictionary<string, string> Props { get; set; }

        public Propriedades() { Props = new Dictionary<string, string>(); }

        public Propriedades(string path) {
            Props = LerArquivo(path);
        }

        private Dictionary<string, string> LerArquivo(string path) {
            // Os métodos do C# já gerarão as exceções caso ocorram problemas de manipulação
            Dictionary<string, string> ret = new Dictionary<string, string>();

            foreach(string linha in System.IO.File.ReadLines(path)) {
                string[] parts = linha.Split("=",2);
                //Pega a primeira key que for repetida
                if(!ret.TryAdd(parts[0], parts[1])) continue;
            }

            return ret;

        }

        public string GetPropriedade(string key) {
            if(!Props.ContainsKey(key)) {
                return null;
            }
            return Props[key];
        }

        public void ChangePropriedade(string key, string val) {
            if(!Props.ContainsKey(key)) {
                Props.Add(key, val);
            }
            Props.Remove(key);
            Props.Add(key, val);
        }

        public bool ExistsPropriedade(string key) {
            return Props.ContainsKey(key);
        }

        public void EscrevePropsArquivo(string path) {
            //https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/file-system/how-to-write-to-a-text-file
            //https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2.keys?view=net-7.0

            using StreamWriter file = new(path);

            foreach(KeyValuePair<string, string> par in Props)
                file.WriteLine(par.Key + "=" + par.Value);
        }

    }
}
}
