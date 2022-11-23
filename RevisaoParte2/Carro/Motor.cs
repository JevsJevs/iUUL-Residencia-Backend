using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carro{
    internal class Motor {

        public float Cilindrada { get; private set; }
        public Carro CarroInstalado { get; private set; }

        public Motor(float cilindrada) {
            Cilindrada = cilindrada;
        }

        public void AssociarCarro(Carro c) {
            if(CarroInstalado != null) throw new Exception("Esse motor ja esta instalado");
            if(c == null) throw new ArgumentNullException("O carro escolhido nao existe!");
            CarroInstalado = c;
        }

        public

        public override string ToString() {

            string placaCarro = CarroInstalado?.Placa == null ? "NENHUM" : CarroInstalado.Placa;

            return $"Motor cilindrada {this.Cilindrada.ToString("0.0")} instalado no carro => {placaCarro}";
        }
    }
}
