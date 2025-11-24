using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimuladorDeProcesos.Procesos;

namespace SimuladorDeProcesos.Scheduler
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

        // Pseudocódigo SJF
        /*
        public Process GetNextProcessSJF(List<Process> availableProcesses)
        {
            // Ordenar por BurstRestante ascendente
            // return availableProcesses.OrderBy(p => p.BurstRestante).FirstOrDefault();
            return null;
        }
        */

        // Pseudocódigo RR
        /*
        public Process GetNextProcessRR(Queue<Process> rrQueue, int quantum)
        {
            // Tomar el primero, ejecutar quantum, si no termina, volver a encolar
            // return rrQueue.Dequeue();
            return null;
        }
        */
    }
}
