using Exercicio2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio4 {
    internal class Poligono {

        public List<Vertice> Vertices { get; private set; }
        public int QtdVert { get { return Vertices.Count; } }

        public Poligono(Vertice[] vertices) {
            if(vertices.Length < 3)
                throw new ArgumentException("O poligono deve ter pelo menos 3 vertices");

            Vertices = vertices.ToList();
        }

        public bool AddVertice(Vertice v) {
            bool canAdd = true;
            List<Vertice> vertices = Vertices;
            for(int i = 0; i < vertices.Count; i++) {
                if(vertices[i].IsEqual(v))
                    canAdd = false;
            }

            if(canAdd) {
                vertices.Add(v);
               Vertices = vertices;
            }

            return canAdd;
        }

        public void RemoveVertice(Vertice v) {
            if(Vertices.Count == 3)
                throw new InvalidOperationException("Um poligono tem no minimo 3 vertices!");
            else
                foreach(Vertice ver in Vertices)
                    if(ver.IsEqual(v)) {
                        Vertices.Remove(v);
                        break;
                    }
        }

        public double Perimetro() {
            double perimetro = 0;
            for(int i = 1;  i < Vertices.Count;  i++) {
                perimetro += Vertices[i].Distancia(Vertices[i - 1]);
            }

            //Soma a distancio do ultimo vertice com o primeiro "fechando" o polígono
            perimetro += Vertices[Vertices.Count - 1].Distancia(Vertices[0]);

            return perimetro;
        }

        public override string ToString() {
            string ret = $"Vertices: {Vertices.Count} \tPerimetro {Perimetro()} \n";
            foreach(Vertice v in Vertices)
                ret += $"\t{v.ToString()}";

            return ret;
        }
    }
}
