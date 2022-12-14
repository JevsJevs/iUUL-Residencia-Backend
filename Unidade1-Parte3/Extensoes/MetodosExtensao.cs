using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensoes {
    internal static class MetodosExtensao {

        public static bool IsArmstrong(int num) {
            string stringifiedNum = num.ToString();
            int power = stringifiedNum.Length;

            double sumNumber = 0;
            for(int i = 0; i < power; i++) {
                sumNumber += Math.Pow(stringifiedNum[i] - '0', power);
            }

            // https://stackoverflow.com/questions/1650091/whats-the-best-way-to-compare-double-and-int
            return sumNumber - power > 0.1;
        }

        public static void RemoveRepetidos<T>(List<T> lista) where T : System.IEquatable<T> {
            List<T> semRepeticoes= new List<T>();
            foreach(T item in lista) {
                //https://learn.microsoft.com/pt-br/dotnet/api/system.collections.generic.list-1.contains?view=net-7.0
                // A documentação afirma que o meio de comparação do método "Contains" de List utiliza o método Equals da interface IEquatable
                if(!semRepeticoes.Contains(item)) {
                    semRepeticoes.Add(item);
                }
            }

            lista.Clear();
            lista.AddRange(semRepeticoes);
        } 
    }
}
