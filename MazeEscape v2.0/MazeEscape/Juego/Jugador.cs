using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeEscape.Modelo
{
    class Jugador
    {
        private string nombre;
        private int vida;
        private int coordenadaX;
        private int coordenadaY;

        public string Nombre { get => nombre; set => nombre = value; }
        public int Vida { get => vida; set => vida = value; }
        public int CoordenadaX { get => coordenadaX; set => coordenadaX = value; }
        public int CoordenadaY { get => coordenadaY; set => coordenadaY = value; }

        public Jugador(string nombre, int vida)
        {
            this.nombre = nombre;
            this.vida = vida;
        }
    }
}
