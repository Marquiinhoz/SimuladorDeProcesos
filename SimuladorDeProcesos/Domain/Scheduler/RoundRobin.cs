using System;
using System.Collections.Generic;
using SimuladorDeProcesos.Domain.Procesos;

namespace SimuladorDeProcesos.Domain.Scheduler
{
    public class RoundRobin : IScheduler
    {
        private int quantum;
        public Queue<Process> ReadyQueue { get; set; } = new Queue<Process>();

        public RoundRobin(int quantum)
        {
            this.quantum = quantum;
        }

        public void AddProcess(Process p)
        {
            ReadyQueue.Enqueue(p);
        }

        public Process GetNextProcess(Process current = null)
        {
            if (ReadyQueue.Count == 0) return null;

            var next = ReadyQueue.Dequeue();
            next.Estado = "Ejecutando";
            return next;
        }
    }
}
