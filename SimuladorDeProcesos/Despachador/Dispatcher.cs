using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimuladorDeProcesos.Procesos;

namespace SimuladorDeProcesos.Despachador
{
    internal class Dispatcher
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
