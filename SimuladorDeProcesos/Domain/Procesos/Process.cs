using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorDeProcesos.Domain.Procesos
{
    public class Process
    {
        public int PID { get; set; }
        public string Estado { get; set; } // New, Ready, Running, Blocked, Exit
        public int BurstTotal { get; set; }
        public int BurstRestante { get; set; }
        public int ProgramCounter { get; set; }
        public int TamanoCodigo { get; set; }
        public int TamanoDatos { get; set; }
        public int TamanoHeap { get; set; }
        public int Prioridad { get; set; }
        public List<string> ListaInterrupciones { get; set; } = new List<string>();

        public Process(int pid, string estado, int burstTotal, int tamanoCodigo, int tamanoDatos, int tamanoHeap, int prioridad)
        {
            PID = pid;
            Estado = estado;
            BurstTotal = burstTotal;
            BurstRestante = burstTotal;
            ProgramCounter = 0;
            TamanoCodigo = tamanoCodigo;
            TamanoDatos = tamanoDatos;
            TamanoHeap = tamanoHeap;
            Prioridad = prioridad;
        }

        public override string ToString()
        {
            return $"PID: {PID}, Estado: {Estado}, BurstRestante: {BurstRestante}, PC: {ProgramCounter}";
        }
    }
}
