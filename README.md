# Simulador de Sistema Operativo - Requerimientos

## Requerimientos Generales

Este proyecto simula la gestión de procesos, memoria y E/S de un sistema operativo. Incluye la creación de procesos, planificación, administración de memoria y manejo de interrupciones.

---

## Ingreso de un Proceso

- **Proceso ingresado por usuario**
- **Proceso creado por el SO**
- **Módulo encargado**: administración de creación e ingreso de procesos
- **Colas de procesos**: totales, listos, E/S
- **PCB**: Control de cada proceso
- **Módulos adicionales**: Planificador y Dispatcher
- **CPU**: Ejecuta instrucciones según PC
- **Cola de eventos E/S**: TIMER, abortos, otros

---

## Proceso para Creación de Programa Ejecutable

- Memoria requerida por proceso:
  - Tamaño de programa ejecutable
  - Tamaño del segmento de datos (% del ejecutable)
  - Memoria variable durante ejecución (% del ejecutable)
- Memoria segmentada en bloques múltiplos de 2^n (32KB a 2MB)
- Tamaño de bloque del proceso = tamaño de bloque de memoria
- Control de bloques libres y ocupados, minimizar desperdicio
- Verificación constante de memoria requerida durante la simulación

---

## Gestión de Proceso

1. Administración de los 5 estados de un proceso y su transición
2. Administración de interrupciones:
   - E/S, finalización E/S, Timer, otros
3. Administración de PCB, incluyendo Program Counter
4. Administración de 3 colas de procesos (mínimo 5 dispositivos)
5. Funciones del Scheduler:
   - Largo, mediano y corto plazo
   - Políticas: FCFS, SJF, Round-Robin, Prioridades
6. Transiciones y planificación apropiativa y no apropiativa:
   - Bloqueo por E/S
   - Cambio de ejecutando a listo
   - Interrupción de E/S
   - Creación y finalización de proceso
7. Ordenamiento de colas según contexto
8. Opcional: adaptabilidad según procesos ingresados
9. Funciones del Dispatcher: cambio de contexto
10. Administración de errores: 0.5% de procesos con error
11. Generación aleatoria de interrupciones (5-20 por proceso)
12. Tiempos de duración de interrupciones aleatorios (5-20 unidades)
13. Cálculo de valores aleatorios documentado en informe
14. Posibilidad de ingreso manual o aleatorio de 20 procesos
15. Monitoreo en línea de cambios de estado, PCB, PC, y datos relevantes

---

## Gestión de Memoria

1. Procesos cargados completamente en memoria
2. Asignación dinámica: stack y heap
3. Direccionamiento físico
4. Administración de memoria: Mapa de Bits o Lista Encadenada
5. Aplicación de 3 estrategias de asignación
6. Evaluación de desempeño y optimización de memoria con 20 procesos

---

## Gestión de E/S

1. Simulación de dispositivos:
   - Teclado
   - Disco
   - Impresora
2. Generación de interrupciones y administración por código
3. Administración de estado del proceso según requerimiento E/S
4. Parámetros enviados al controlador
5. Administración de colas de atención de requerimientos
6. Generación de interrupción al finalizar requerimiento
7. Carga/descarga de memoria
8. Administración de estado del proceso
9. Captura de señal de teclado y acciones correspondientes
10. Mínimo 10 interrupciones aleatorias por dispositivo
11. Duración de interrupciones aleatoria según características del proceso

---

## Consideraciones Generales

1. Informe final con conclusiones sobre políticas de planificación y asignación de memoria
2. Presentación (PPT u otro) con:
   - Objetivos generales y específicos
   - Problemática resuelta
   - Actividades realizadas
   - Conclusiones y próximos pasos
3. Duración máxima de presentación: 30 minutos
   - 15 min PPT, 10 min demo, 5 min preguntas
4. Anexos: documentación del sistema, framework usado, manuales de instalación y usuario
5. Entrega de informe en UNIVIRTUAL
6. Evaluación:
   - 40% ejecución y verificación del software
   - 30% informe final
   - 30% presentación y defensa individual
