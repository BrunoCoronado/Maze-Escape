using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeEscape.Modelo
{
    class Casilla
    {
        private string objeto;
        private int coordenadaX;
        private int coordenadaY;

        public string Objeto { get => objeto; set => objeto = value; }
        public int CoordenadaX { get => coordenadaX; set => coordenadaX = value; }
        public int CoordenadaY { get => coordenadaY; set => coordenadaY = value; }

        public Casilla(string objeto, int coordenadaX, int coordenadaY)
        {
            this.objeto = objeto;
            this.coordenadaX = coordenadaX;
            this.coordenadaY = coordenadaY;
        }
    }
}
