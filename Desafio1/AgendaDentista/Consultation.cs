using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDentista {
    internal class Consultation {

        public long PatientCPF { get; private set; }
        public DateTime StartingTime { get; private set; }

        public DateTime EndingTime { get; private set; }


        private DateTime DateTimeApartToDateTime(string date, string time) {
            string[] dateValues = date.Split('/');
            int[] dateVal = { int.Parse(dateValues[0]), int.Parse(dateValues[1]), int.Parse(dateValues[2]) };

            int[] timeVal = { int.Parse(time.Substring(0,2)), int.Parse(time.Substring(2)) };

            DateTime data = new DateTime(dateVal[2],dateVal[1],dateVal[0], timeVal[0], timeVal[1], 0);

            return data;
        }
        public Consultation(string patientCpf, string date, string start, string end) {
            this.PatientCPF = Convert.ToInt64(patientCpf);
            this.StartingTime = DateTimeApartToDateTime(date, start);
            this.EndingTime = DateTimeApartToDateTime(date, end);
        }

        public bool TimeIntersection(Consultation consultation) {

        }
    }
}
