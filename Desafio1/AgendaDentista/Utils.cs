using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDentista {
    static class Utils {

        /// <summary>
        /// Essa função converte as strings de input para o formato DateTime
        /// </summary>
        /// <param name="date">String de data no formato dd/MM/yyyy</param>
        /// <param name="time">String de hora no formato hh:mm</param>
        /// <returns>
        /// DateTime com os inputs convertidos
        /// </returns>
        static public DateTime DateTimeApartToDateTime(string date, string time) {
            string[] dateValues = date.Split('/');
            int[] dateVal = { int.Parse(dateValues[0]), int.Parse(dateValues[1]), int.Parse(dateValues[2]) };

            string[] timeValues = time.Split(':');
            int[] timeVal = { int.Parse(timeValues[0]), int.Parse(timeValues[1]) };

            DateTime data = new DateTime(dateVal[2],dateVal[1],dateVal[0], timeVal[0], timeVal[1], 0);

            return data;
        }
    }
}
