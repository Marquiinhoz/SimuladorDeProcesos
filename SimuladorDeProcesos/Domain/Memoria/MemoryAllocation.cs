using System;
using System.Collections.Generic;
using System.Linq;

namespace SimuladorDeProcesos.Domain.Memoria
{
    /// <summary>
    /// Representa la asignación de memoria completa para un proceso,
    /// incluyendo todos sus segmentos y estadísticas de fragmentación.
    /// </summary>
    public class MemoryAllocation
    {
        /// <summary>
        /// ID del proceso al que pertenece esta asignación
        /// </summary>
        public int ProcessId { get; set; }

        /// <summary>
        /// Lista de segmentos de memoria asignados (Code, Data, Heap)
        /// </summary>
        public List<MemoryBlock> Segments { get; set; }

        /// <summary>
        /// Total de memoria asignada en KB (incluyendo fragmentación interna)
        /// </summary>
        public int TotalAllocated { get; set; }

        /// <summary>
        /// Fragmentación interna en KB (espacio desperdiciado dentro de bloques asignados)
        /// </summary>
        public int InternalFragmentation { get; set; }

        public MemoryAllocation()
        {
            Segments = new List<MemoryBlock>();
        }

        /// <summary>
        /// Obtiene la memoria realmente utilizada (sin fragmentación interna)
        /// </summary>
        public int UsedMemory => TotalAllocated - InternalFragmentation;

        public override string ToString()
        {
            return $"P{ProcessId}: {Segments.Count} segmentos, {TotalAllocated} KB asignados, {InternalFragmentation} KB desperdicio";
        }
    }
}
