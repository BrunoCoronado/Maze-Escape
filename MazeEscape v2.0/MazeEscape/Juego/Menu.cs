using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeEscape.Sistema
{
    class Menu
    {
        private Juego juego = new Juego();

        public void menuPrincipal()
        {
            Console.WriteLine("****MAZE ESCAPE****");
            //imprimimos el menu en pantalla añadimos el salto de linea \n
            Console.WriteLine("1) Ingresar nombre del personaje \n2) Iniciar juego \n     a) Tablero 1 \n     b) Tablero 2 \n3) Salir \n");
            
            var opcion = Console.ReadLine();//capturamos la opcion 
            switch (opcion)
            {
                case "1":
                    nombreJugador();
                    break;
                case "a":
                    if (juego.Jugador != null)//validamos que exista un jugador para iniciar el juego
                    {
                        //dado el procedimiento para crear tableros asignamos filas, columnas, obstactulos, enemigos
                        juego.crearTablero(5, 5, 2, 2);
                        //mostramos el tablero de juego
                        juego.verTablero();
                        //mostramos el menu del juego
                        opcionesJuego();
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
                        //dado el procedimiento para crear tableros asignamos filas, columnas, obstactulos, enemigos
                        juego.crearTablero(10, 10, 5, 5);
                        //mostramos el tablero de juego
                        juego.verTablero();
                        //mostramos el menu del juego
                        opcionesJuego();
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

        public void nombreJugador()
        {
            Console.WriteLine("Ingrese el nombre");
            var nombre = Console.ReadLine();
            //dado el constructor de la clase jugador definida
            //guardamos el nombre del jugador y le asignamos 10 de vida
            juego.Jugador = new Modelo.Jugador(nombre, 10);
            menuPrincipal();//regresamos al menu principal
        }

        public void opcionesJuego()
        {
            Console.WriteLine("****MAZE ESCAPE****");
            //imprimimos el menu en pantalla
            Console.WriteLine("1) Comandos \n2) Imprimir tablero \n3) Estatus personaje principal \n4) Terminar partida \n");
            var opcion = Console.ReadLine();//obtenemos la opcion
            switch (opcion)
            {
                case "1":
                    comandos();//mostramos los comandos
                    break;
                case "2":
                    juego.verTablero();//mostramos el tablero
                    opcionesJuego();//volvemos a mostrar las opciones de juego
                    break;
                case "3":
                    juego.verJugador();//mostramos la informacion del jugador
                    opcionesJuego();//volvemos a mostrar las opciones de juego
                    break;
                case "4":
                    menuPrincipal();//terminamos la partida y regresamos al menu principal
                    break;
                default:
                    Console.WriteLine("¡Opcion Invalida!");
                    opcionesJuego();//en caso de error, volvemos a llamar al menu
                    break;
            }
        }

        public void comandos()
        {
            Console.WriteLine("****MAZE ESCAPE****");
            Console.WriteLine("1) Mover derecha\n2) Mover izquierda\n3) Mover arriba\n4) Mover abajo\n5) Atacar izquierda\n6) Atacar derecha\n7) Atacar arriba\n8) Atacar abajo\n9) Regresar\n");
            
            var comando = Console.ReadLine();//capturamos el comando
            switch (comando)
            {
                case "1":
                    juego.realizarMovimiento(1, "x");//realizamos el movimiento
                    break;
                case "2":
                    juego.realizarMovimiento(-1, "x");//realizamos el movimiento
                    break;
                case "3":
                    juego.realizarMovimiento(1, "y");//realizamos el movimiento
                    break;
                case "4":
                    juego.realizarMovimiento(-1, "y");//realizamos el movimiento
                    break;
                case "5":
                    juego.realizarAtaque(-1, "x");//realizamos el ataque
                    break;
                case "6":
                    juego.realizarAtaque(1, "x");//realizamos el ataque
                    break;
                case "7":
                    juego.realizarAtaque(1, "y");//realizamos el ataque
                    break;
                case "8":
                    juego.realizarAtaque(-1, "y");//realizamos el ataque
                    break;
                case "9":
                    opcionesJuego();//regresamos a las opciones del juego
                    break;
                default:
                    Console.WriteLine("¡Comando Invalido!");
                    comandos();//en caso de error, volvemos a llamar al menu
                    break;
            }
            verificarEstado();
        }

        private void verificarEstado()
        {
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
                opcionesJuego();
            }
        }
    }
}
