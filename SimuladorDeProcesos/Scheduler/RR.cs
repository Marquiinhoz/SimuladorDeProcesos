using System.Collections.Generic;
using SimuladorDeProcesos.Procesos;

namespace SimuladorDeProcesos.Scheduler
{
    public class RoundRobin : IScheduler
    {
        public Queue<Process> RRQueue { get; set; } = new();
        public int Quantum { get; set; }

        public RoundRobin(int quantum)
        {
            Quantum = quantum;
        }

        public void AddProcess(Process p)
        {
            p.Estado = "Listo";
            RRQueue.Enqueue(p);
        }

        public Process GetNextProcess(Process current = null)
        {
            if (RRQueue.Count == 0)
                return null;

            var p = RRQueue.Dequeue();
            p.Estado = "Ejecutando";
            return p;
        }

        public void EjecutarQuantum(Process p)
        {
            p.BurstRestante -= Quantum;

            if (p.BurstRestante > 0)
            {
                // No terminó → volver a la cola
                p.Estado = "Listo";
                RRQueue.Enqueue(p);
            }
            else
            {
                // Termina
                p.BurstRestante = 0;
                p.Estado = "Terminado";
            }
        }
    }
}
