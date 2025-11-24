using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimuladorDeProcesos.Domain.Memoria
{
    /// <summary>
    /// Gestor de memoria basado en listas encadenadas.
    /// Implementa First Fit con soporte para segmentación (Code, Data, Heap).
    /// </summary>
    public class MemoryManager
    {
        public const int TotalMemoryKB = 1024; // 1 MB = 1024 KB

        /// <summary>
        /// Cabeza de la lista encadenada de bloques de memoria
        /// </summary>
        public MemoryBlock Head { get; private set; }

        /// <summary>
        /// Diccionario de asignaciones por proceso
        /// </summary>
        private Dictionary<int, MemoryAllocation> allocations;

        public MemoryManager()
        {
            // Inicializar con un único bloque libre de toda la memoria
            Head = new MemoryBlock(0, TotalMemoryKB, true);
            allocations = new Dictionary<int, MemoryAllocation>();
        }

        /// <summary>
        /// Asigna memoria a un proceso con segmentación (Code, Data, Heap)
        /// Usa algoritmo First Fit
        /// </summary>
        public MemoryAllocation AllocateMemory(int processId, int codeSize, int dataSize, int heapSize)
        {
            int totalRequired = codeSize + dataSize + heapSize;

            // Buscar un bloque libre suficientemente grande (First Fit)
            MemoryBlock current = Head;
            MemoryBlock previous = null;

            while (current != null)
            {
                if (current.IsFree && current.Size >= totalRequired)
                {
                    // Encontramos un bloque adecuado
                    MemoryAllocation allocation = new MemoryAllocation
                    {
                        ProcessId = processId
                    };

                    int currentAddress = current.StartAddress;

                    // Asignar segmento de código
                    MemoryBlock codeBlock = SplitBlock(current, currentAddress, codeSize, processId, "Code");
                    allocation.Segments.Add(codeBlock);
                    current = codeBlock.Next;
                    currentAddress += codeSize;

                    // Asignar segmento de datos
                    MemoryBlock dataBlock = SplitBlock(current, currentAddress, dataSize, processId, "Data");
                    allocation.Segments.Add(dataBlock);
                    current = dataBlock.Next;
                    currentAddress += dataSize;

                    // Asignar segmento de heap
                    MemoryBlock heapBlock = SplitBlock(current, currentAddress, heapSize, processId, "Heap");
                    allocation.Segments.Add(heapBlock);

                    // Calcular estadísticas
                    allocation.TotalAllocated = totalRequired;
                    allocation.InternalFragmentation = 0; // En esta implementación simple, no hay fragmentación interna

                    allocations[processId] = allocation;
                    return allocation;
                }

                previous = current;
                current = current.Next;
            }

            // No hay espacio suficiente
            return null;
        }

        /// <summary>
        /// Divide un bloque libre en un bloque ocupado y (opcionalmente) un bloque libre restante
        /// </summary>
        private MemoryBlock SplitBlock(MemoryBlock freeBlock, int address, int size, int processId, string segmentType)
        {
            MemoryBlock allocatedBlock = new MemoryBlock(address, size, false)
            {
                ProcessId = processId,
                SegmentType = segmentType
            };

            int remainingSize = freeBlock.Size - size;

            if (remainingSize > 0)
            {
                // Crear bloque libre con el espacio restante
                MemoryBlock remainingBlock = new MemoryBlock(address + size, remainingSize, true)
                {
                    Next = freeBlock.Next
                };
                allocatedBlock.Next = remainingBlock;
            }
            else
            {
                allocatedBlock.Next = freeBlock.Next;
            }

            // Actualizar el bloque libre original para que apunte al nuevo bloque asignado
            freeBlock.Size = size;
            freeBlock.IsFree = false;
            freeBlock.ProcessId = processId;
            freeBlock.SegmentType = segmentType;
            freeBlock.Next = allocatedBlock.Next;

            return freeBlock;
        }

        /// <summary>
        /// Libera toda la memoria asignada a un proceso y realiza coalescing
        /// </summary>
        public void DeallocateMemory(int processId)
        {
            if (!allocations.ContainsKey(processId))
                return;

            // Marcar todos los bloques del proceso como libres
            MemoryBlock current = Head;
            while (current != null)
            {
                if (current.ProcessId == processId)
                {
                    current.IsFree = true;
                    current.ProcessId = null;
                    current.SegmentType = null;
                }
                current = current.Next;
            }

            // Realizar coalescing (fusión de bloques libres adyacentes)
            Coalesce();

            allocations.Remove(processId);
        }

        /// <summary>
        /// Fusiona bloques libres adyacentes para reducir fragmentación externa
        /// </summary>
        private void Coalesce()
        {
            MemoryBlock current = Head;

            while (current != null && current.Next != null)
            {
                if (current.IsFree && current.Next.IsFree)
                {
                    // Fusionar bloques adyacentes
                    current.Size += current.Next.Size;
                    current.Next = current.Next.Next;
                    // No avanzar, verificar si el siguiente también es libre
                }
                else
                {
                    current = current.Next;
                }
            }
        }

        /// <summary>
        /// Obtiene el mapa completo de memoria como lista de bloques
        /// </summary>
        public List<MemoryBlock> GetMemoryMap()
        {
            List<MemoryBlock> map = new List<MemoryBlock>();
            MemoryBlock current = Head;

            while (current != null)
            {
                map.Add(current);
                current = current.Next;
            }

            return map;
        }

        /// <summary>
        /// Calcula la memoria libre total
        /// </summary>
        public int GetTotalFreeMemory()
        {
            int free = 0;
            MemoryBlock current = Head;

            while (current != null)
            {
                if (current.IsFree)
                    free += current.Size;
                current = current.Next;
            }

            return free;
        }

        /// <summary>
        /// Encuentra el bloque libre contiguo más grande
        /// </summary>
        public int GetLargestContiguousFreeBlock()
        {
            int largest = 0;
            MemoryBlock current = Head;

            while (current != null)
            {
                if (current.IsFree && current.Size > largest)
                    largest = current.Size;
                current = current.Next;
            }

            return largest;
        }

        /// <summary>
        /// Calcula fragmentación interna y externa
        /// </summary>
        public (int internalFrag, int externalFrag) GetFragmentation()
        {
            int internalFrag = 0;
            int externalFrag = 0;

            // Fragmentación interna: suma de desperdicio en asignaciones
            foreach (var allocation in allocations.Values)
            {
                internalFrag += allocation.InternalFragmentation;
            }

            // Fragmentación externa: suma de bloques libres que no se pueden usar
            int totalFree = GetTotalFreeMemory();
            int largestFree = GetLargestContiguousFreeBlock();
            externalFrag = totalFree - largestFree;

            return (internalFrag, externalFrag);
        }

        /// <summary>
        /// Genera una representación en texto del mapa de memoria
        /// </summary>
        public string GetMemoryMapText()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("=== MAPA DE MEMORIA ===");

            MemoryBlock current = Head;
            while (current != null)
            {
                sb.AppendLine(current.ToString());
                current = current.Next;
            }

            sb.AppendLine();
            var (internalFrag, externalFrag) = GetFragmentation();
            sb.AppendLine($"Fragmentación Interna: {internalFrag} KB");
            sb.AppendLine($"Fragmentación Externa: {externalFrag} KB");
            sb.AppendLine($"Memoria Libre Total: {GetTotalFreeMemory()} KB");
            sb.AppendLine($"Bloque Libre Más Grande: {GetLargestContiguousFreeBlock()} KB");

            return sb.ToString();
        }

        // Método de compatibilidad con la interfaz anterior (para no romper código existente)
        [Obsolete("Use AllocateMemory con segmentación")]
        public List<int> FirstFit(int sizeKB)
        {
            // Compatibilidad: asignar todo como un solo segmento de "Data"
            var allocation = AllocateMemory(9999, 0, sizeKB, 0);
            if (allocation == null) return null;

            // Retornar lista ficticia de "bloques" para compatibilidad
            return new List<int> { allocation.Segments[0].StartAddress / 64 };
        }

        // Propiedad de compatibilidad
        [Obsolete("Bitmap ya no se usa, use GetMemoryMap()")]
        public int[] Bitmap
        {
            get
            {
                // Generar bitmap compatible desde la lista encadenada
                int[] bitmap = new int[16]; // 1024 KB / 64 KB = 16 bloques
                MemoryBlock current = Head;

                while (current != null)
                {
                    int startBlock = current.StartAddress / 64;
                    int blockCount = (int)Math.Ceiling(current.Size / 64.0);

                    for (int i = 0; i < blockCount && (startBlock + i) < 16; i++)
                    {
                        bitmap[startBlock + i] = current.IsFree ? 0 : 1;
                    }

                    current = current.Next;
                }

                return bitmap;
            }
        }
    }
}
