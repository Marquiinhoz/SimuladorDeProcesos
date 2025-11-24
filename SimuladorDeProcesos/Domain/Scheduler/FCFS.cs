using System;
using System.Collections.Generic;
using SimuladorDeProcesos.Domain.Procesos;

namespace SimuladorDeProcesos.Domain.Scheduler
{
    public class FCFS : IScheduler
    {
        public Queue<Process> ReadyQueue { get; set; } = new Queue<Process>();

        public void AddProcess(Process p)
        {
            ReadyQueue.Enqueue(p);
        }

        public Process GetNextProcess(Process current = null)
        {
            if (ReadyQueue.Count > 0)
            {
                return ReadyQueue.Dequeue();
            }
            return null;
        }
    }
}
