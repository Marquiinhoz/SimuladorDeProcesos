using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorDeProcesos.Procesos
{
    internal class ProcessManager
    {
        public List<Process> ListaProcesos { get; set; } = new List<Process>();
        private Random rnd = new Random();

        // Genera 2-3 procesos aleatorios
        public void GenerarProcesos()
        {
            int cantidad = rnd.Next(2, 4); // genera 2 o 3 procesos
            for (int i = 1; i <= cantidad; i++)
            {
                Process p = new Process(
                    pid: i,
                    estado: "New",
                    burstTotal: rnd.Next(5, 21),
                    tamanoCodigo: rnd.Next(50, 101),
                    tamanoDatos: rnd.Next(20, 51),
                    tamanoHeap: rnd.Next(10, 31),
                    prioridad: rnd.Next(1, 6)
                );
                ListaProcesos.Add(p);
            }
        }

        // Mostrar procesos en consola
        public void MostrarProcesos()
        {
            foreach (var p in ListaProcesos)
            {
                Console.WriteLine(p.ToString());
            }
        }
    }
}
