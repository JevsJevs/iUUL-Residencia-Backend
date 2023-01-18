using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter {
    internal class FormManager {

        internal class Prompt {
            public string Text { get; set; }
            public string Value { get; private set; }
            
            private List<Predicate<string>> Validation { get; set; }

            public Prompt(string text, string val, List<Predicate<string>> validation ) { 
                Text = text;
                Value = val;
                Validation = validation;
            }

            public bool RequestInput() {
                Console.WriteLine(Text);
                string input = Console.ReadLine() ?? "";

                // faz validacoes
                bool isValid = true;
                foreach(Predicate<string> predicate in Validation ) {
                    isValid = isValid && predicate(input);
                }

                return isValid;
            }
        }

        //internal class Validation {

        //    public

        //}


        public List<Prompt> Prompts { get; set; }





    }
}
