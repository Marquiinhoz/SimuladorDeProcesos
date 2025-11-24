using System;
using System.Collections.Generic;

namespace SimuladorDeProcesos.Domain.IO
{
    public struct Interrupt
    {
        public string Tipo; // "IO", "Timer", etc.
        public string Dispositivo; // "Teclado", "Disco", "Impresora"
        public int PID;
        public DateTime Tiempo;
        public int Duracion; // Duración de la interrupción
        public int Restante; // Tiempo restante

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
            int duracion = rnd.Next(2, 8); // Duración aleatoria entre 2 y 7 unidades

            // Simular encolado
            if (disp == "Teclado") ColaTeclado.Enqueue(pid);
            else if (disp == "Disco") ColaDisco.Enqueue(pid);
            else ColaImpresora.Enqueue(pid);

            return new Interrupt
            {
                Tipo = "IO",
                Dispositivo = disp,
                PID = pid,
                Tiempo = DateTime.Now,
                Duracion = duracion,
                Restante = duracion
            };
        }
    }
}
