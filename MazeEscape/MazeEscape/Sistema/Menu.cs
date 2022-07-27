using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeEscape.Sistema
{
    class Menu
    {
        private Juego juego;

        public Menu()
        {
            juego = new Juego();
        }

        public void menuPrincipal()
        {
            //imprimimos el menu en pantalla
            Console.WriteLine("1) Ingresar nombre del personaje");
            Console.WriteLine("2) Iniciar juego");
            Console.WriteLine("     a) Tablero 1");
            Console.WriteLine("     b) Tablero 2");
            Console.WriteLine("     c) Tablero 3");
            Console.WriteLine("3) Salir");
            //obtenemos la entrada 
            var entrada = Console.ReadLine();
            switch (entrada)
            {
                case "1":
                    ingresarNombre();
                    break;
                case "a":
                    if (juego.Jugador != null)//validamos que exista un jugador para iniciar el juego
                    {
                        juego.generarTablero(4, 4, 8, 4);
                        juego.verTablero();
                        menuJuego();
                    }
                    else
                    {
                        Console.WriteLine("¡No existe Jugador!");
                        menuPrincipal();//en caso de error, volvemos a llamar al menu
                    }
                    break;
                case "b":
                    if (juego.Jugador != null)//validamos que exista un jugador para iniciar el juego
                    {
                        juego.generarTablero(6, 6, 15, 12);
                        juego.verTablero();
                        menuJuego();
                    }
                    else
                    {
                        Console.WriteLine("¡No existe Jugador!");
                        menuPrincipal();//en caso de error, volvemos a llamar al menu
                    }
                    break;
                case "c":
                    if (juego.Jugador != null)//validamos que exista un jugador para iniciar el juego
                    {
                        juego.generarTablero(10, 10, 30, 25);
                        juego.verTablero();
                        menuJuego();
                    }
                    else
                    {
                        Console.WriteLine("¡No existe Jugador!");
                        menuPrincipal();//en caso de error, volvemos a llamar al menu
                    }
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("¡Opcion Invalida!");
                    menuPrincipal();//en caso de error, volvemos a llamar al menu
                    break;
            }
        }

        public void ingresarNombre()
        {
            Console.WriteLine("Ingrese el nombre");
            var nombre = Console.ReadLine();
            juego.Jugador = new Modelo.Jugador(nombre, 5);
            menuPrincipal();
        }

        public void menuJuego()
        {
            //imprimimos el menu en pantalla
            Console.WriteLine("1) Comandos");
            Console.WriteLine("2) Imprimir tablero");
            Console.WriteLine("3) Estatus personaje principal");
            Console.WriteLine("4) Terminar partida");
            //obtenemos la entrada 
            var entrada = Console.ReadLine();
            switch (entrada)
            {
                case "1":
                    menuComandos();
                    break;
                case "2":
                    juego.verTablero();
                    menuJuego();
                    break;
                case "3":
                    juego.verJugador();
                    menuJuego();
                    break;
                case "4":
                    menuPrincipal();
                    break;
                default:
                    Console.WriteLine("¡Opcion Invalida!");
                    menuJuego();//en caso de error, volvemos a llamar al menu
                    break;
            }
        }

        public void menuComandos()
        {
            Console.WriteLine("Ingrese el comando");
            Console.WriteLine("1) Mover derecha: moverá al personaje sobre el eje X una posición del lado positivo.");
            Console.WriteLine("2) Mover izquierda: moverá al personaje sobre el eje X una posición del lado negativo.");
            Console.WriteLine("3) Mover arriba: moverá al personaje sobre el eje Y una posición del lado positivo.");
            Console.WriteLine("4) Mover abajo: moverá al personaje sobre el eje Y una posición del lado negativo.");
            Console.WriteLine("5) Atacar izquierda: atacará a un enemigo que se encuentre en una ubicación negativa en el eje X");
            Console.WriteLine("6) Atacar derecha: atacará a un enemigo que se encuentre en una ubicación positiva en el eje X.");
            Console.WriteLine("7) Atacar arriba: atacará a un enemigo que se encuentre en una ubicación positiva en el eje Y.");
            Console.WriteLine("8) Atacar abajo: atacará a un enemigo que se encuentre en una ubicación negativa en el eje Y.");
            Console.WriteLine("9) Regresar");

            var comando = Console.ReadLine();
            switch (comando)
            {
                case "1":
                    juego.movimiento(1);
                    break;
                case "2":
                    juego.movimiento(2);
                    break;
                case "3":
                    juego.movimiento(3);
                    break;
                case "4":
                    juego.movimiento(4);
                    break;
                case "5":
                    juego.ataque(2);
                    break;
                case "6":
                    juego.ataque(1);
                    break;
                case "7":
                    juego.ataque(3);
                    break;
                case "8":
                    juego.ataque(4);
                    break;
                case "9":
                    menuJuego();
                    break;
                default:
                    Console.WriteLine("¡Comando Invalido!");
                    menuComandos();//en caso de error, volvemos a llamar al menu
                    break;
            }
            if (juego.EstadoPartida != 0)//validamos cual es el estado de la partida despues de ralizar una accion
            {
                if (juego.EstadoPartida == 1)
                {
                    Console.WriteLine("¡Victoria!");
                }
                else
                {
                    Console.WriteLine("¡Derrota!");
                }
                menuPrincipal();
            }
            else
            {
                juego.verTablero();
                menuJuego();
            }
        }
    }
}
