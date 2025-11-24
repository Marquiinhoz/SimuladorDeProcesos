using System;
using System.Collections.Generic;
using System.Linq;
using SimuladorDeProcesos.Domain.Procesos;

namespace SimuladorDeProcesos.Domain.Scheduler
{
    public class PriorityScheduler : IScheduler
    {
        public List<Process> ReadyList { get; set; } = new List<Process>();

        public void AddProcess(Process p)
        {
            ReadyList.Add(p);
        }

        public Process GetNextProcess(Process current = null)
        {
            if (ReadyList.Count == 0) return null;

            // Escoger el de mayor prioridad (asumiendo menor número = mayor prioridad, o viceversa)
            // Asumiremos menor número = mayor prioridad por convención común, o al revés. 
            // Implementación simple:
            var next = ReadyList.OrderBy(p => p.Prioridad).First();
            ReadyList.Remove(next);

            next.Estado = "Ejecutando";
            return next;
        }
    }
}
