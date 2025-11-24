using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorDeProcesos.IO
{
    public struct Interrupt
    {
        public string Tipo; // "IO", "Timer", etc.
        public string Dispositivo; // "Teclado", "Disco", "Impresora"
        public int PID;
        public DateTime Tiempo;

        public override string ToString()
        {
            return $"[T={Tiempo:HH:mm:ss}] Interrupt: {Dispositivo} -> Proceso {PID}";
        }
    }

    public class IOManager
    {
        public Queue<int> ColaTeclado { get; set; } = new Queue<int>();
        public Queue<int> ColaDisco { get; set; } = new Queue<int>();
        public Queue<int> ColaImpresora { get; set; } = new Queue<int>();

        public Interrupt GenerarInterrupcionAleatoria(int pid)
        {
            string[] dispositivos = { "Teclado", "Disco", "Impresora" };
            Random rnd = new Random();
            string disp = dispositivos[rnd.Next(dispositivos.Length)];

            // Simular encolado
            if (disp == "Teclado") ColaTeclado.Enqueue(pid);
            else if (disp == "Disco") ColaDisco.Enqueue(pid);
            else ColaImpresora.Enqueue(pid);

            return new Interrupt
            {
                Tipo = "IO",
                Dispositivo = disp,
                PID = pid,
                Tiempo = DateTime.Now
            };
        }
    }
}
