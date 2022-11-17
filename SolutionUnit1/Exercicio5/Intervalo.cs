using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio5 {
    class Intervalo {

        public DateTime DataTempoIni { get; private set; }
        public DateTime DataTempoFim { get; private set; }

        public Intervalo(DateTime ini, DateTime fim) {
            if(ini.CompareTo(fim) > 0) {
                throw new ArgumentException("A data do inicio é posterior a do fim!");
            }

            DataTempoIni = ini;
            DataTempoFim = fim;
        }

        public bool TemIntersecao(Intervalo other) {
            if(this.DataTempoIni.CompareTo(other.DataTempoFim) <= 0 && other.DataTempoIni.CompareTo(this.DataTempoFim) <= 0)
                return true;

            return false;
        }

        public TimeSpan Duracao() {
            TimeSpan dur = DataTempoFim - DataTempoIni;
            return dur;
        }

        public bool isEqual(Intervalo other) {
            bool equal = false;

            if(this.DataTempoIni.CompareTo(other.DataTempoIni) == 0 && this.DataTempoFim.CompareTo(other.DataTempoFim) == 0)
                equal= true;

            return equal;
        }

        public override string ToString() {
            return $"Data 1: {DataTempoIni}\nData 2: {DataTempoFim}";
        }
    }
}
}
