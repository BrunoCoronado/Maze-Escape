using MazeEscape.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeEscape.Sistema
{
    class Juego
    {
        private Jugador jugador;
        private Casilla[,] tablero;
        private int filas;
        private int columnas;
        private Random numAleatorio = new Random();
        private int estadoPartida; //0 = en proceso | 1 = victoria | 2 = derrota

        internal Jugador Jugador { get => jugador; set => jugador = value; }
        public int EstadoPartida { get => estadoPartida; set => estadoPartida = value; }

        public void crearTablero(int filas,int columnas,int obstaculos,int enemigos)
        {
            this.filas = filas;
            this.columnas = columnas;
            tablero = new Casilla[filas, columnas];
            
            for (int y = 0; y < filas; y++)//desde la fila 0 hasta la superior
            {
                for (int x = 0; x < columnas; x++)//desde la columna 0 hasta la final, de izquierda a derecha
                {
                    //notacion para arrays bidimensionales [filas, columnas] -> columnas = coordenada X y filas = coordenada Y
                    tablero[y, x] = new Casilla(" ", x, y);//creamos el tablero sin contenido
                }
            }
            agregarJugadorAlTablero();
            agregarAlTablero(3);//generamos la estrella en una posicion aleatoria
            agregarObstaculosYEnemigos(obstaculos, enemigos); //generamos los obstaculos y enemigos
        }
        
        private void agregarJugadorAlTablero()
        {        
            estadoPartida = 0; //ponemos el estado de la partida como en proceso
            jugador.Vida = 10; //definimos la vida del jugador
            //inicializamos la posicion del jugador en el origen 
            jugador.CoordenadaX = 0;
            jugador.CoordenadaY = 0;
            tablero[0, 0].Objeto = "&";//ponemos al jugador en la coordenada (0,0)
        }

        private void agregarObstaculosYEnemigos(int obstaculos, int enemigos)
        {
            for (int i = 0; i < obstaculos; i++)//generamos obstaculos aleatorios
            {
                agregarAlTablero(1);
            }
            for (int i = 0; i < enemigos; i++)//generamos enemigos aleatorios
            {
                agregarAlTablero(2);
            }
        }
        
        private void agregarAlTablero(int contenido)// 1 = obstaculo = "o" | 2 = enemigo = "x" | 3 = estrella "*"
        {
            string c = "";
            switch (contenido)
            {
                case 1:
                    c = "o";
                    break;
                case 2:
                    c = "x";
                    break;
                case 3:
                    c = "*";
                    break;
            }

            int coordenadaAleatoriaX = numAleatorio.Next(0, columnas); //generamos una coordenada aleatoria entre 0 y el numero de columnas
            int coordenadaAleatoriaY = numAleatorio.Next(0, filas); //generamos una coordenada aleatoria entre 0 y el numero de filas

            //verificamos que no exista nada en ese casilla del tablero 
            //en caso de que no se cumplan las condiciones dadas, aplicamos recursividad para volver a generar coordenadas
            if (tablero[coordenadaAleatoriaY, coordenadaAleatoriaX].Objeto == " ")
            {
                tablero[coordenadaAleatoriaY, coordenadaAleatoriaX].Objeto = c;
            }
            else
            {
                agregarAlTablero(contenido);
            }
        }

        public void verTablero()
        {
            for (int y = (filas - 1); y > -1; y--)//lo recorremos al revés ya que la fila superior se imprime primero
            {
                Console.Write("\n");
                for (int x = 0; x < columnas; x++)
                {
                    Console.Write(" ___");
                }
                Console.Write("\n| ");
                for (int x = 0; x < columnas; x++)//las columnas se recorren normal, de izquierda a derecha
                {
                    Console.Write(tablero[y, x].Objeto + " | ");
                }
            }
            Console.Write("\n");
        }

        public void verJugador()
        {
            Console.WriteLine("****MAZE ESCAPE****");
            Console.WriteLine("\nNombe: "+jugador.Nombre+"\nVida: "+jugador.Vida.ToString()+"\n");
        }

        public void realizarMovimiento(int direccion, string eje)//direccion 1 positivo | -1 negativo
        {
            switch (eje)
            {
                case "x":
                    switch (direccion)
                    {
                        case 1://movimiento hacia x positivo
                            mover(1, 0);
                            break;
                        case -1://movimiento hacia x negativo
                            mover(-1, 0);
                            break;
                    }
                    break;
                case "y":
                    switch (direccion)
                    {
                        case 1://movimiento hacia y positivo
                            mover(0, 1);
                            break;
                        case -1://movimiento hacia y negativo
                            mover(0, -1);
                            break;
                    }
                    break;
            }
        }

        public void realizarAtaque(int direccion, string eje)//direccion 1 positivo | -1 negativo
        {
            switch (eje)
            {
                case "x":
                    switch (direccion)
                    {
                        case 1://movimiento hacia x positivo
                            atacar(1, 0);
                            break;
                        case -1://movimiento hacia x negativo
                            atacar(-1, 0);
                            break;
                    }
                    break;
                case "y":
                    switch (direccion)
                    {
                        case 1://movimiento hacia y positivo
                            atacar(0, 1);
                            break;
                        case -1://movimiento hacia y negativo
                            atacar(0, -1);
                            break;
                    }
                    break;
            }
        }

        private void mover(int x, int y)
        {
            try
            {
                switch (tablero[jugador.CoordenadaY + y, jugador.CoordenadaX + x].Objeto)//buscamos que existe en la casilla a la que nos vamos a mover
                {
                    case "*":
                        EstadoPartida = 1;
                        break;
                    case "o":
                        Console.WriteLine("Hay un obstaculo, no se puede mover!");
                        break;
                    case "x":
                        Console.WriteLine("Hay un enemigo, no se puede mover!\nVida -1!");
                        jugador.Vida = jugador.Vida - 1;
                        if (jugador.Vida == 0)
                        {
                            EstadoPartida = 2;
                        }
                        break;
                    case " ":
                        tablero[jugador.CoordenadaY + y, jugador.CoordenadaX + x].Objeto = "&";
                        tablero[jugador.CoordenadaY, jugador.CoordenadaX].Objeto = " ";
                        jugador.CoordenadaX = jugador.CoordenadaX + x;
                        jugador.CoordenadaY = jugador.CoordenadaY + y;
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Movimiento fuera del tablero!\nVida -1!");
                jugador.Vida = jugador.Vida - 1;
                if (jugador.Vida == 0)
                {
                    EstadoPartida = 2;
                }
            }
        }

        private void atacar(int x, int y)
        {
            try//usamos un Try Catch por si sale de los limites de la matriz
            {
                if (tablero[jugador.CoordenadaY + y, jugador.CoordenadaX + x].Objeto == "x")//buscamos si existe enemigo en la casilla
                {
                    tablero[jugador.CoordenadaY + y, jugador.CoordenadaX + x].Objeto = " ";//eliminamos al enemigo
                }
            }
            catch
            {
                
            }
        }
    }
}
