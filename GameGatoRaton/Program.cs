using System;
using System.Collections.Generic;

namespace GameGatoRaton
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Jugador> jugadores = new();
            Gato gato = new();
            Raton raton = new();
            jugadores.Add(gato);
            jugadores.Add(raton);

            Helper.ImprimirReglas();

            Console.WriteLine("Jugador 1 por favor digite su nombre: ");
            var jugador1 = Console.ReadLine();

            Console.WriteLine("Jugador 2 por favor digite su nombre");
            var jugador2 = Console.ReadLine();

            var defineGato = Helper.DefinirGato();
            switch(defineGato)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 9:
                    gato.SetNombre(jugador1);
                    raton.SetNombre(jugador2);
                    break;
                case 2:
                case 4:
                case 6:
                case 8:
                case 10:
                    gato.SetNombre(jugador2);
                    raton.SetNombre(jugador1);
                    break;
            }

            Console.WriteLine("El gato será: " + gato.GetNombre());
            Console.WriteLine("El ratón será: " + raton.GetNombre());


            Console.WriteLine("La posicion inicial del gato es: " + gato.ObtenerPosicion());
            Console.WriteLine("La posicion inicial del raton es: " + raton.ObtenerPosicion());
            Console.WriteLine("Presione cualquier tecla para continuar: ");
            var continuar = Console.ReadLine();
            Console.Clear();
            
            var tablero = new List<Linea>()
            {
                new Linea() {SeleccionGato = "1", PosicionGato=gato.ObtenerPosicion().ToString(), PosicionRaton = raton.ObtenerPosicion().ToString(), SeleccionRaton = "1" },
                new Linea() {SeleccionGato = "2", PosicionGato= "", PosicionRaton = "", SeleccionRaton = "2" },
                new Linea() {SeleccionGato = "3", PosicionGato= "", PosicionRaton = "", SeleccionRaton = "3" },
                new Linea() {SeleccionGato = "4", PosicionGato= "", PosicionRaton = "", SeleccionRaton = "4" },
                new Linea() {SeleccionGato = "5", PosicionGato= "", PosicionRaton = "", SeleccionRaton = "5" },
                new Linea() {SeleccionGato = "6", PosicionGato= "", PosicionRaton = "", SeleccionRaton = "6" },
                new Linea() {SeleccionGato = "7", PosicionGato= "", PosicionRaton = "", SeleccionRaton = "7" },
                new Linea() {SeleccionGato = "8", PosicionGato= "", PosicionRaton = "", SeleccionRaton = "8" },
                new Linea() {SeleccionGato = "9", PosicionGato= "", PosicionRaton = "", SeleccionRaton = "9" },
                new Linea() {SeleccionGato = "", PosicionGato= "", PosicionRaton = "", SeleccionRaton = "" },
                new Linea() {SeleccionGato = "", PosicionGato= "", PosicionRaton = "", SeleccionRaton = "" }
            };
            Helper.ImprimirTabla(tablero);
            Console.WriteLine("Comienza el juego....");

            for(var i=1; i< tablero.Count-1; i++)
            {
                int vR = 0, vG = 0;
                Console.WriteLine("Turno # " + i);
                Console.WriteLine("El ratón juega primero, adelante " + raton.GetNombre() + " por favor elige un numero entre 1 y 9 que no se haya utilizado anteriormente: ");
                raton.ObtenerNumerosDisponibles();
                vR = Helper.ValidarEntrada(raton);
                raton.ActualizarNumerosDisponibles(vR);
                raton.ActualizarPosicion(vR);

                Console.WriteLine("Excelente " + raton.GetNombre() + " ahora es el turno del Gato");
                Console.WriteLine(gato.GetNombre() + " por favor elige un numero entre 1 y 9 que no se haya utilizado anteriormente: ");
                gato.ObtenerNumerosDisponibles();
                vG = Helper.ValidarEntrada(gato);
                gato.ActualizarNumerosDisponibles(vG);
                gato.ActualizarPosicion(vG);

                Helper.ActualizarTabla(tablero, gato, raton, i);
                Helper.ValidarGanador(raton, gato);
            }

            Console.ReadLine();
        }
    }
}
