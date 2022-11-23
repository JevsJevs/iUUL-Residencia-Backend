using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carro{
    internal class Carro { 
        public string Placa { get; private set; }
        public string Modelo { get; private set; }
        public Motor MotorInstalado { get; private set; }


        public Carro(string placa, string modelo, Motor motor) {
            if(placa == null || placa == "") throw new ArgumentNullException("O argumento \"Placa\" é obrigatorio e não pode ser nulo");
            if(modelo == null || modelo == "") throw new ArgumentNullException("O argumento \"Modelo\" é obrigatorio e não pode ser nulo");
            if(motor == null) throw new ArgumentNullException("O argumento \"Motor\" é obrigatorio e não pode ser nulo");


            Placa = placa;
            Modelo = modelo;
            MotorInstalado = motor;
        }

        public Motor TrocarMotor(Motor m) {
            if(m == null) throw new ArgumentNullException("Para trocar um motor voce precisa ter um!");
            if(m.CarroInstalado != null) throw new ArgumentException("O motor já está instalado em outro carro!");

            Motor motorRetirado = this.MotorInstalado;
            motorRetirado.CarroInstalado = null;

            m.AssociarCarro(this);
            MotorInstalado = m;

            return motorRetirado;
        }

        public int VelocidadeMax() {
            if(this.MotorInstalado.Cilindrada <= 1.0)
                return 140;
            if(this.MotorInstalado.Cilindrada <= 1.6)
                return 160;
            if(this.MotorInstalado.Cilindrada <= 2.0)
                return 180;
            return 220;
        }

        public override string ToString() {
            return $"Placa {Placa}\t|\tModelo: {Modelo}\t|\tVelicidadeMax: {VelocidadeMax().ToString()} \nMotor do Carro: {this.MotorInstalado.ToString()} ";
        }

    }
}