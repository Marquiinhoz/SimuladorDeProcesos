using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorDeProcesos.Memoria
{
    internal class MemoryManager
    {
        public const int TotalMemory = 1024 * 1024; // 1 MB
        public const int BlockSize = 64 * 1024;     // 64 KB por bloque
        public int TotalBlocks => TotalMemory / BlockSize;

        public int[] Bitmap;  // 0 = libre, 1 = ocupado

        public MemoryManager()
        {
            Bitmap = new int[TotalBlocks];
        }

        // Asigna memoria usando FIRST FIT. sizeKB es en KB (ej: 120 = 120 KB)
        public List<int> FirstFit(int sizeKB)
        {
            int blocksNeeded = (int)Math.Ceiling(sizeKB / 64.0); // cada bloque = 64 KB
            int freeCount = 0;
            int start = 0;

            for (int i = 0; i < Bitmap.Length; i++)
            {
                if (Bitmap[i] == 0)
                {
                    if (freeCount == 0) start = i;
                    freeCount++;

                    if (freeCount == blocksNeeded)
                    {
                        // Asignar los bloques
                        for (int j = start; j < start + blocksNeeded; j++)
                            Bitmap[j] = 1;

                        return Enumerable.Range(start, blocksNeeded).ToList();
                    }
                }
                else
                {
                    freeCount = 0;
                }
            }

            return null; // No hay suficiente memoria contigua
        }

        // Libera bloques previamente asignados
        public void FreeBlocks(List<int> blocks)
        {
            if (blocks == null) return;
            foreach (var b in blocks)
            {
                if (b >= 0 && b < Bitmap.Length)
                    Bitmap[b] = 0;
            }
        }
    }
}
