using System;

namespace SimuladorDeProcesos.Domain.Memoria
{
    /// <summary>
    /// Representa un bloque de memoria en la lista encadenada.
    /// Puede estar libre u ocupado por un segmento de proceso.
    /// </summary>
    public class MemoryBlock
    {
        /// <summary>
        /// Dirección inicial del bloque en KB
        /// </summary>
        public int StartAddress { get; set; }

        /// <summary>
        /// Tamaño del bloque en KB
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// Indica si el bloque está libre (true) u ocupado (false)
        /// </summary>
        public bool IsFree { get; set; }

        /// <summary>
        /// ID del proceso que ocupa este bloque (null si está libre)
        /// </summary>
        public int? ProcessId { get; set; }

        /// <summary>
        /// Tipo de segmento: "Code", "Data", "Heap" (null si está libre)
        /// </summary>
        public string SegmentType { get; set; }

        /// <summary>
        /// Siguiente bloque en la lista encadenada
        /// </summary>
        public MemoryBlock Next { get; set; }

        /// <summary>
        /// Dirección final del bloque (calculada)
        /// </summary>
        public int EndAddress => StartAddress + Size;

        public MemoryBlock(int startAddress, int size, bool isFree = true)
        {
            StartAddress = startAddress;
            Size = size;
            IsFree = isFree;
            ProcessId = null;
            SegmentType = null;
            Next = null;
        }

        public override string ToString()
        {
            if (IsFree)
                return $"[{StartAddress}-{EndAddress} KB] LIBRE ({Size} KB)";
            else
                return $"[{StartAddress}-{EndAddress} KB] P{ProcessId} - {SegmentType} ({Size} KB)";
        }
    }
}
