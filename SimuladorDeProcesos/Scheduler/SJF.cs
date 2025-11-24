using System.Collections.Generic;
using System.Linq;
using SimuladorDeProcesos.Procesos;

namespace SimuladorDeProcesos.Scheduler
{
    public class SJF : IScheduler
    {
        public List<Process> ReadyList { get; set; } = new List<Process>();

        public void AddProcess(Process p)
        {
            p.Estado = "Listo";
            ReadyList.Add(p);
        }

        public Process GetNextProcess(Process current = null)
        {
            if (ReadyList.Count == 0)
                return null;

            // Escoger el de menor Burst (no expropiativo)
            var next = ReadyList.OrderBy(p => p.BurstTotal).First();
            ReadyList.Remove(next);

            next.Estado = "Ejecutando";
            return next;
        }
    }
}
