using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercicio2;

namespace Exercicio3 {
    internal class Triangulo {
        public enum TipoTriangulo {
            Equilatero,
            Isosceles,
            Escaleno
        }

        private Vertice v1 { get; set; }
        private Vertice v2 { get; set; }
        private Vertice v3 { get; set; }

        // Propriedade lados -> array
        private double[] Lados { get; set; }
        public double Perimetro { get; private set; }
        public TipoTriangulo Tipo { get; private set; }

        public double Area { get; private set; }

        //funções auxiliares para construtor
        private bool TrianguloPossivel() {
            bool isTriangulo = true;

            isTriangulo = isTriangulo && Lados[0] + Lados[1] > Lados[2];
            isTriangulo = isTriangulo && Lados[1] + Lados[2] > Lados[0];
            isTriangulo = isTriangulo && Lados[2] + Lados[0] > Lados[1];

            return isTriangulo;
        }

        private TipoTriangulo CalcularTipo() {
            if(Lados[0] == Lados[1] && Lados[1] == Lados[2] && Lados[0] == Lados[2])
                return TipoTriangulo.Equilatero;
            else if(Lados[0] == Lados[1] || Lados[1] == Lados[2] || Lados[0] == Lados[2])
                return TipoTriangulo.Isosceles;

            return TipoTriangulo.Escaleno;
        }

        private double CalcularArea() {
            double S = Perimetro / 2; 
            double componenteFormula = S;

            for(int i = 0; i < 3; i++) {
                componenteFormula *= S - Lados[i];
            }

            return Math.Sqrt(componenteFormula);
        }

        public Triangulo(Vertice v1, Vertice v2, Vertice v3) {

            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;

            this.Lados = new double[3] { v1.Distancia(v2), v2.Distancia(v3), v3.Distancia(v1) };
            
            // Logica de se pode ser triangulo
            bool isTriangulo = TrianguloPossivel();

            if(isTriangulo) {

                this.Perimetro = this.Lados.Sum();

                //Definir o tipo do triangulo
                this.Tipo = CalcularTipo();

                this.Area = CalcularArea();
            }
            else throw new Exception("Esse triangulo é impossivel");
        }

        public bool IsEqual(Triangulo other) {
            Array.Sort(this.Lados);
            Array.Sort(other.Lados);

            bool isEqual = true;

            for(int i = 0; i < 3; i++) {
                isEqual = isEqual && other.Lados[i] == this.Lados[i];
            }

            return isEqual;
        }

        public override string ToString() {
            return $"||Vertices: {v1.ToString()} {v2.ToString()} {v3.ToString()} ||\n||Lados: {Lados[0]} {Lados[1]} {Lados[2]}||\n||Perimetro: {Perimetro}\tArea: {Area}\tTipo: {Tipo.ToString()}";
        }
    }
}
 