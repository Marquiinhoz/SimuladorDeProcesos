using SimuladorDeProcesos.Procesos;

namespace SimuladorDeProcesos.Scheduler
{
    public interface IScheduler
    {
        void AddProcess(Process p);
        Process GetNextProcess(Process current);
    }
}
