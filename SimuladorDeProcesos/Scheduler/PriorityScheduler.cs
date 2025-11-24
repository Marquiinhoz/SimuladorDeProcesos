using System.Collections.Generic;
using System.Linq;
using SimuladorDeProcesos.Procesos;

namespace SimuladorDeProcesos.Scheduler
{
    public class PriorityScheduler : IScheduler
    {
        public List<Process> ReadyList { get; set; } = new();

        public void AddProcess(Process p)
        {
            p.Estado = "Listo";
            ReadyList.Add(p);
        }

        public Process GetNextProcess(Process current = null)
        {
            if (ReadyList.Count == 0)
                return null;

            var next = ReadyList.OrderBy(p => p.Prioridad).First();
            ReadyList.Remove(next);

            next.Estado = "Ejecutando";
            return next;
        }
    }
}
