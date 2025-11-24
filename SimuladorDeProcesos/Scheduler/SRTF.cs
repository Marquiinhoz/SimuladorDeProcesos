using System.Collections.Generic;
using System.Linq;
using SimuladorDeProcesos.Procesos;

namespace SimuladorDeProcesos.Scheduler
{
    public class SRTF : IScheduler
    {
        public List<Process> ReadyList { get; set; } = new();

        public void AddProcess(Process p)
        {
            p.Estado = "Listo";
            ReadyList.Add(p);
        }

        public Process GetNextProcess(Process procesoActual)
        {
            // Si no hay procesos listos, seguir con el actual
            if (ReadyList.Count == 0)
                return procesoActual;

            // Si no hay actual, tomar el más corto
            if (procesoActual == null)
            {
                var shortest = ReadyList.OrderBy(p => p.BurstRestante).First();
                ReadyList.Remove(shortest);
                shortest.Estado = "Ejecutando";
                return shortest;
            }

            // Comparar actual con el más corto de la lista
            var candidato = ReadyList.OrderBy(p => p.BurstRestante).First();

            if (candidato.BurstRestante < procesoActual.BurstRestante)
            {
                // Interrumpir
                procesoActual.Estado = "Listo";
                ReadyList.Add(procesoActual);

                ReadyList.Remove(candidato);
                candidato.Estado = "Ejecutando";

                return candidato;
            }

            return procesoActual; // sigue ejecutándose
        }
    }
}
