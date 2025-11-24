using System;
using System.Collections.Generic;
using SimuladorDeProcesos.Domain.Procesos;
using SimuladorDeProcesos.Domain.Memoria;
using SimuladorDeProcesos.Domain.Scheduler;
using SimuladorDeProcesos.Domain.Despachador;
using SimuladorDeProcesos.Domain.IO;

namespace SimuladorDeProcesos.BLL
{
    public class SimulationService
    {
        public ProcessManager ProcessManager { get; private set; }
        public MemoryManager MemoryManager { get; private set; }
        public IOManager IOManager { get; private set; }
        public IScheduler Scheduler { get; private set; }
        public Dispatcher Dispatcher { get; private set; }

        public Process CurrentProcess { get; private set; }

        public SimulationService()
        {
            ProcessManager = new ProcessManager();
            MemoryManager = new MemoryManager();
            IOManager = new IOManager();
            Dispatcher = new Dispatcher();

            // Default Scheduler
            Scheduler = new FCFS();
        }

        public void SetScheduler(string schedulerType)
        {
            // Preserve current queue if possible or clear it? 
            // For simplicity in this refactor, we just switch strategies.
            // In a real scenario, we might want to migrate the queue.
            switch (schedulerType)
            {
                case "FCFS":
                    Scheduler = new FCFS();
                    break;
                case "SJF":
                    Scheduler = new SJF();
                    break;
                case "SRTF":
                    Scheduler = new SRTF();
                    break;
                case "Round Robin":
                    Scheduler = new RoundRobin(3); // Default Quantum
                    break;
                case "Prioridad":
                    Scheduler = new PriorityScheduler();
                    break;
                default:
                    Scheduler = new FCFS();
                    break;
            }
        }

        public void GenerateProcesses()
        {
            ProcessManager.GenerarProcesos();
            // Add generated processes to Scheduler
            foreach (var p in ProcessManager.ListaProcesos)
            {
                p.Estado = "Ready";
                Scheduler.AddProcess(p);
            }
        }

        public void RunDispatcher()
        {
            Process next = Scheduler.GetNextProcess(CurrentProcess);

            if (next != null)
            {
                Dispatcher.ContextSwitch(CurrentProcess, next);
                CurrentProcess = next;
            }
        }

        public void SimulateIO()
        {
            // Logic to simulate IO would go here, interacting with IOManager
            // For now we just expose the manager
        }
    }
}
