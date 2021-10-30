using System;
using System.Collections.Generic;
using TableParser;

namespace GameGatoRaton
{
    public static class Helper
    {
        public static int DefinirGato()
        {
            Random rnd = new();
            return rnd.Next(1, 2);
        }

        public static void ImprimirTabla(List<Linea> tablero)
        {
            var customTable = tablero.ToStringTable(new[] { "#", "Gato", "Ratón", "#" },
            t => t.SeleccionGato,
            t => t.PosicionGato,
            t => t.PosicionRaton,
            t => t.SeleccionRaton
            );

            Console.WriteLine(customTable);
        }

        public static void ActualizarTabla(List<Linea> tablero, Gato gato, Raton raton, int indice)
        {
            tablero[indice].PosicionGato = gato.ObtenerPosicion().ToString();
            tablero[indice].PosicionRaton = raton.ObtenerPosicion().ToString();
            Console.Clear();
            ImprimirTabla(tablero);
        }

        public static int ValidarEntrada(Jugador j)
        {
            int vD = 0;
            var v = Console.ReadLine();
            while (!int.TryParse(v, out vD))
            {
                Console.WriteLine("El valor ingresado no corresponde a un número, por favor intente de nuevo");
                v = Console.ReadLine();
                int.TryParse(v, out vD);
            }
            while (!j.ValidarNumeroDisponible(vD))
            {
                Console.WriteLine("El número ingresado no está disponible, por favor intente con un valor de la lista");
                j.ObtenerNumerosDisponibles();
                v = Console.ReadLine();
                int.TryParse(v, out vD);
            }
            while (!j.ProximaPosicionValida(vD))
            {
                if(!j.HayNumerosValidos())
                {
                    Console.WriteLine("Lo siento " + j.GetNombre() + " ya no tienes números disponibles válidos ya que en todas las combinaciones tu posición es igual o mayor a 30, la partida se da por terminada");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
                Console.WriteLine("El número ingresado obtendra un valor mayor o igual a 30, por favor intente con otro valor de la lista");
                j.ObtenerNumerosDisponibles();
                v = Console.ReadLine();
                int.TryParse(v, out vD);
            }
            return vD;
        }

        public static void ImprimirReglas()
        {
            Console.WriteLine("Bienvenido al juego del Gato y el Ratón \n");
            Console.WriteLine("Las reglas definidas para este juego lógico matemático son las siguientes: ");
            Console.WriteLine("\n1. Un jugador hace el papel de gato el cual inicia en la posición 1. El otro jugador es el ratón, que inicia en la posición 30. El objetivo del ratón es hacer cálculos con números disponibles para entrar en su madriguera que se sitúa en el 0.");
            Console.WriteLine("\n2. El ratón juega primero: escoge uno de los números nueve naturales disponibles, lo raya o enmarca, lo sustrae de 30 y escribe el resultado debajo en su columna que empieza en 30. Seguidamente le toca el turno al gato quien escoge también uno de los números naturales entre 1 y 9, lo raya, lo agrega a 1 y escribe el resultado debajo en su columna.");
            Console.WriteLine("\n3. Continua el juego cada jugador, por turno, seleccionando uno de los números naturales aún disponible, lo agrega o resta según corresponda (en función si es gato o ratón), al último número que él ha escrito en su columna y coloca el resultado debajo del mismo.");
            Console.WriteLine("\n4. Todos los resultados que se obtengan deben oscilar entre 0 y 30 para ambos jugadores.");
            Console.WriteLine("\n5. La partida terminar en uno de los tres siguientes escenarios: \n  a. Gana el gato: Si después de jugar, obtiene el número donde está el ratón en su última jugada. \n  b. Gana el ratón: Si logra llegar al 0. \n  c. Nula o empatada: Si los dos jugadores han utilizado los números sin que se haya dado ninguna de las anteriores opciones, la partida se declara empatada.");
            Console.WriteLine("\nPresione cualquier tecla para continuar");
            Console.ReadLine();
            Console.Clear();
        }

        public static void ValidarGanador(Raton raton, Gato gato)
        {
            if (raton.ObtenerPosicion() == gato.ObtenerPosicion())
            {
                Console.WriteLine("Felicidades " + gato.GetNombre() + " has atrapado a " + raton.GetNombre());
                Console.ReadLine();
                Environment.Exit(0);
            }
            if (!raton.PoseeNumerosDisponibles() && !gato.PoseeNumerosDisponibles())
            {
                Console.WriteLine("Todos los números disponibles han sido utilizados el juego termina en empate");
                Console.ReadLine();
                Environment.Exit(0);
            }
            if (raton.ObtenerPosicion() == 0)
            {
                Console.WriteLine("Felicidades " + raton.GetNombre() + " has ganado");
                Console.ReadLine();
                Environment.Exit(0);
            }
        }
    }
}
