namespace Kepler7.Core.Patrones.Comportamiento.Command
{
    // Invocador: ejecuta los comandos y maneja deshacer/rehacer con dos pilas
    public class GestorComandos
    {
        private Stack<IComando> pilaDeshacer = new Stack<IComando>();
        private Stack<IComando> pilaRehacer = new Stack<IComando>();
        private List<string> historial = new List<string>();

        // Historial para mostrar en la UI (indica qué se deshizo)
        public IReadOnlyList<string> Historial
        {
            get { return historial; }
        }

        public void Ejecutar(IComando comando)
        {
            comando.Ejecutar();
            pilaDeshacer.Push(comando);
            // Una acción nueva invalida lo que se podía rehacer
            pilaRehacer.Clear();
            historial.Add("Ejecutado: " + comando.Descripcion);
        }

        // Devuelve false si no había nada para deshacer
        public bool Deshacer()
        {
            if (pilaDeshacer.Count == 0)
            {
                return false;
            }
            IComando comando = pilaDeshacer.Pop();
            comando.Deshacer();
            pilaRehacer.Push(comando);
            historial.Add("Deshecho: " + comando.Descripcion);
            return true;
        }

        // Devuelve false si no había nada para rehacer
        public bool Rehacer()
        {
            if (pilaRehacer.Count == 0)
            {
                return false;
            }
            IComando comando = pilaRehacer.Pop();
            comando.Ejecutar();
            pilaDeshacer.Push(comando);
            historial.Add("Rehecho: " + comando.Descripcion);
            return true;
        }
    }
}
