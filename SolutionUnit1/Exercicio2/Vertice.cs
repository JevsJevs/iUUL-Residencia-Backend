using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio2 {
    public class Vertice {

        public double VertexX { get; private set; }

        public double VertexY { get; private set; }


        // Contructor
        public Vertice(double X, double Y) {
            this.VertexX = X;
            this.VertexY = Y;
        }


        public double Distancia(Vertice other) {
            double diffX = this.VertexX - other.VertexX;
            double diffY = this.VertexY - other.VertexY;

            return Math.Sqrt(diffX * diffX + diffY * diffY);
        }

        public void Move(double newX, double newY) {
            VertexX = newX;
            VertexY = newY;
        }

        public bool IsEqual(Vertice other) {
            if(this.VertexY == other.VertexY && this.VertexX == other.VertexX) {
                return true;
            }
            return false;
        }

        public string ToString() {
            return $"({this.VertexX}, {this.VertexY})";
        }
    }
}

