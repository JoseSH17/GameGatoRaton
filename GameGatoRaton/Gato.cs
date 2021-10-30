using System;
using System.Linq;

namespace GameGatoRaton
{
    public class Gato : Jugador
    {
        private string Nombre;
        private int Posicion = 1;
        private int[] NumerosDisponibles = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };        
        public override void SetNombre(string Nombre) { this.Nombre = Nombre; }
        public override string GetNombre() { return Nombre; }
        public override void ActualizarPosicion(int n) { Posicion += n; }
        public override int ObtenerPosicion() { return Posicion; }
        public override bool ProximaPosicionValida(int n)
        {
            if (ObtenerPosicion() + n >= 30) return false;
            return true;
        }
        public override bool HayNumerosValidos()
        {
            bool t = false;
            for (int i = 0; i < NumerosDisponibles.Length; i++)
            {
                if (ObtenerPosicion() + NumerosDisponibles[i] < 30) t = true;
            }
            return t;
        }
        public override void ActualizarNumerosDisponibles(int n) => NumerosDisponibles = NumerosDisponibles.Where(v => v != n).ToArray();
        public override void ObtenerNumerosDisponibles() => Console.WriteLine("Numeros disponibles: [{0}]", string.Join(",", NumerosDisponibles));
        public override bool ValidarNumeroDisponible(int i) 
        {
            var exists = NumerosDisponibles.Any(n => n == i);
            if (exists) return true;
            return false;
        }
        public override bool PoseeNumerosDisponibles() => NumerosDisponibles.Length != 0;
    }
}