using SimuladorDeProcesos.Domain.Procesos;

namespace SimuladorDeProcesos.Domain.Scheduler
{
    public interface IScheduler
    {
        void AddProcess(Process p);
        Process GetNextProcess(Process current);
    }
}
