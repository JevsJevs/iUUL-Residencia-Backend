using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDentista {
    internal class Appointment {

        public long PatientCPF { get; private set; }
        public DateTime StartingTime { get; private set; }

        public DateTime EndingTime { get; private set; }


        
        public Appointment(string patientCpf, string date, string start, string end) {
            this.PatientCPF = Convert.ToInt64(patientCpf);
            this.StartingTime = Utils.DateTimeApartToDateTime(date, start);
            this.EndingTime = Utils.DateTimeApartToDateTime(date, end);
        }

        public override string ToString() {
            return $"{StartingTime.ToString("dd/MM/yyyy HH:mm")} {EndingTime.ToString("HH:mm")}";
        }
    }
}
