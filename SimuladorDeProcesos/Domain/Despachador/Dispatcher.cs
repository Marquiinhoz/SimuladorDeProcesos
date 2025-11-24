using System;
using SimuladorDeProcesos.Domain.Procesos;

namespace SimuladorDeProcesos.Domain.Despachador
{
    public class Dispatcher
    {
        public string UltimoLog { get; private set; }

        public void ContextSwitch(Process procesoSaliente, Process procesoEntrante)
        {
            // Guardar PC del proceso saliente
            if (procesoSaliente != null)
            {
                procesoSaliente.ProgramCounter++;
                procesoSaliente.Estado = "Ready";
            }

            // Preparar al proceso entrante
            if (procesoEntrante != null)
            {
                procesoEntrante.Estado = "Running";
            }

            string pOut = procesoSaliente != null ? "P" + procesoSaliente.PID : "Ninguno";
            string pIn = procesoEntrante != null ? "P" + procesoEntrante.PID : "Ninguno";

            UltimoLog =
                $"[T={DateTime.Now:HH:mm:ss}] Cambio de contexto: {pOut} → {pIn}";
        }
    }
}
