namespace GameGatoRaton
{
    public abstract class Jugador
    {
        public abstract void SetNombre(string n);
        public abstract string GetNombre();        
        public abstract void ActualizarPosicion(int n);
        public abstract int ObtenerPosicion();
        public abstract bool ProximaPosicionValida(int n);

        public abstract bool HayNumerosValidos();
        public abstract void ActualizarNumerosDisponibles(int n);
        public abstract void ObtenerNumerosDisponibles();
        public abstract bool ValidarNumeroDisponible(int i);
        public abstract bool PoseeNumerosDisponibles();
    }
}