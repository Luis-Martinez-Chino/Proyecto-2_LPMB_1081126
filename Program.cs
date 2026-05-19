using System;
    class Program
    {
        static void Main()
        {
            // =========================
            // VARIABLES PRINCIPALES
            // =========================

            double capitalInicial;
            double dinero;
            int empleados;
            double sueldo;
            int meses;
            int mesActual = 0;
            int filas;
            int columnas;

            double costosMensuales;
            double totalSalarios = 0;
            double totalSemillas = 0;
            double ingresosTotales = 0;

            // Inventario de semillas
            int semillasTrigo = 0;
            int semillasRepollo = 0;
            int semillasTomate = 0;
            int semillasCalabaza = 0;
            int semillasEsparrago = 0;

            // =========================
            // INGRESO DE DATOS
            // =========================

            Console.WriteLine("====== GESTION DE GRANJA ======\n");
            
            Console.Write("Ingrese el capital inicial: ");          //CAPITAL INICIAL
            capitalInicial = Convert.ToDouble(Console.ReadLine());

            Console.Write("Ingrese cantidad de empleados: ");       //EMPLEADOS
            empleados = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ingrese sueldo por empleado: ");         //SUELDO
            sueldo = Convert.ToDouble(Console.ReadLine());

            Console.Write("Ingrese cantidad de meses a simular: "); //MESES
            meses = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ingrese filas de la matriz: ");          //FILAS MATRIZ
            filas = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ingrese columnas de la matriz: ");       //COLUMNAS MATRIZ
            columnas = Convert.ToInt32(Console.ReadLine());

            dinero = capitalInicial;

            // Crear matriz de parcelas
            Parcela[,] parcela = new Parcela[filas, columnas];

            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    parcela[i, j] = new Parcela();
                }
            }

            // Calcular costos mensuales
            costosMensuales = empleados * sueldo;

            // =========================
            // MENU PRINCIPAL
            // =========================

            while (meses > 0 && dinero > 0)
            {
                Console.Clear();

                Console.WriteLine("====== MENU PRINCIPAL ======");
                Console.WriteLine("1. Comprar semillas");
                Console.WriteLine("2. Sembrar cultivo");
                Console.WriteLine("3. Consultar parcelas");
                Console.WriteLine("4. Avanzar mes");
                Console.WriteLine("5. Salir");

                Console.Write("Seleccione una opcion: ");
                int opcionMenu = Convert.ToInt32(Console.ReadLine());

                switch (opcionMenu)
                {
                    case 1:     //OPCION PARA COMPRAR SEMILLAS
                    {
                            double utilidad = dinero - costosMensuales;

                            if (utilidad < 0)
                            {
                                Console.WriteLine("No se pueden comprar semillas.");
                            }
                            else
                            {
                                Console.WriteLine("\nTIPOS DE SEMILLAS");
                                Console.WriteLine("1. Trigo");
                                Console.WriteLine("2. Repollo");
                                Console.WriteLine("3. Tomate");
                                Console.WriteLine("4. Calabaza");
                                Console.WriteLine("5. Esparrago");

                                Console.Write("Seleccione una semilla: ");
                                int opcionSemilla = Convert.ToInt32(Console.ReadLine());

                                Console.Write("Cantidad a comprar: ");
                                int cantidad = Convert.ToInt32(Console.ReadLine());

                                double costo = 0;

                                switch (opcionSemilla)
                                {
                                    case 1:     //TRIGO
                                        costo = 100 * cantidad;

                                        if (dinero >= costo)
                                        {
                                            semillasTrigo += cantidad;
                                        }
                                        break;

                                    case 2:     //REPOLLO  
                                        costo = 180 * cantidad;

                                        if (dinero >= costo)
                                        {
                                            semillasRepollo += cantidad;
                                        }
                                        break;

                                    case 3:     //TOMATE    
                                    costo = 250 * cantidad;

                                        if (dinero >= costo)
                                        {
                                            semillasTomate += cantidad;
                                        }
                                        break;

                                    case 4:    //CALABAZA
                                    costo = 220 * cantidad;

                                        if (dinero >= costo)
                                        {
                                            semillasCalabaza += cantidad;
                                        }
                                        break;

                                    case 5:     //ESPARRAGO
                                    costo = 500 * cantidad;

                                        if (dinero >= costo)
                                        {
                                            semillasEsparrago += cantidad;
                                        }
                                        break;

                                    default:
                                        Console.WriteLine("Semilla invalida.");
                                        break;
                            }

                                if (dinero >= costo)
                                {
                                    dinero -= costo;
                                    totalSemillas += costo;

                                    Console.WriteLine("Compra realizada correctamente.");
                                }
                                else
                                {
                                    Console.WriteLine("Dinero insuficiente.");
                                }
                            }

                            break;
                        }

                    case 2:     //OPCION PARA SEMBRAR CULTIVO
                    {
                            Console.WriteLine("\nINVENTARIO DE SEMILLAS");
                            Console.WriteLine($"Trigo: {semillasTrigo}");
                            Console.WriteLine($"Repollo: {semillasRepollo}");
                            Console.WriteLine($"Tomate: {semillasTomate}");
                            Console.WriteLine($"Calabaza: {semillasCalabaza}");
                            Console.WriteLine($"Esparrago: {semillasEsparrago}");

                            Console.Write("\nFila: ");
                            int fila = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Columna: ");
                            int columna = Convert.ToInt32(Console.ReadLine());

                            if (fila >= 0 && fila < filas &&
                                columna >= 0 && columna < columnas)
                            {
                                if (parcela[fila, columna].EstaVacia())
                                {
                                    Console.WriteLine("\n1. Trigo");
                                    Console.WriteLine("2. Repollo");
                                    Console.WriteLine("3. Tomate");
                                    Console.WriteLine("4. Calabaza");
                                    Console.WriteLine("5. Esparrago");

                                    Console.Write("Seleccione cultivo: ");
                                    int cultivo = Convert.ToInt32(Console.ReadLine());

                                    switch (cultivo)
                                    {
                                        case 1:

                                            if (semillasTrigo > 0)
                                            {
                                                parcela[fila, columna]
                                                    .Sembrar("Trigo", 2, 130);  // Trigo tarda 1 mes en crecer, se cosecha al segundo mes y genera Q130

                                            semillasTrigo--;
                                                Console.WriteLine("Trigo sembrado.");
                                            }
                                            else
                                            {
                                                Console.WriteLine("No hay semillas.");
                                            }

                                            break;

                                        case 2:         

                                            if (semillasRepollo > 0)
                                            {
                                                parcela[fila, columna]
                                                    .Sembrar("Repollo", 3, 280); // Repollo tarda 2 meses en crecer, se cosecha al tercer mes y genera Q280

                                            semillasRepollo--;
                                                Console.WriteLine("Repollo sembrado.");
                                            }
                                            else
                                            {
                                                Console.WriteLine("No hay semillas.");
                                            }

                                            break;

                                        case 3:

                                            if (semillasTomate > 0)
                                            {
                                                parcela[fila, columna]
                                                    .Sembrar("Tomate", 4, 450); // Tomate tarda 3 meses en crecer, se cosecha al cuarto mes y genera Q450

                                            semillasTomate--;
                                                Console.WriteLine("Tomate sembrado.");
                                            }
                                            else
                                            {
                                                Console.WriteLine("No hay semillas.");
                                            }

                                            break;

                                        case 4:

                                            if (semillasCalabaza > 0)
                                            {
                                                parcela[fila, columna]
                                                    .Sembrar("Calabaza", 5, 360); // Calabaza tarda 4 meses en crecer, se cosecha al quinto mes y genera Q360

                                            semillasCalabaza--;
                                                Console.WriteLine("Calabaza sembrada.");
                                            }
                                            else
                                            {
                                                Console.WriteLine("No hay semillas.");
                                            }

                                            break;

                                        case 5:

                                            if (semillasEsparrago > 0)
                                            {
                                                parcela[fila, columna]
                                                    .Sembrar("Esparrago", 7, 1000); // Esparrago tarda 6 meses en crecer, se cosecha al septimo mes y genera Q1000

                                            semillasEsparrago--;
                                                Console.WriteLine("Esparrago sembrado.");
                                            }
                                            else
                                            {
                                                Console.WriteLine("No hay semillas.");
                                            }

                                            break;

                                        default:
                                            Console.WriteLine("Cultivo invalido.");
                                            break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("La parcela no esta libre.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Posicion invalida.");
                            }

                            break;
                        }

                    case 3:         // OPCION MAPA DE LAS PARCELAS
                    {
                            Console.WriteLine("\n===== MAPA DE PARCELAS =====\n");      

                            for (int i = 0; i < filas; i++)
                            {
                                for (int j = 0; j < columnas; j++)
                                {
                                    Console.Write($"[{parcela[i, j].tipoCultivo}]\t");
                                }

                                Console.WriteLine();
                            }

                            break;
                        }

                    case 4:         //OPCION PARA AVANZAR MES
                    {
                            dinero -= costosMensuales;
                            totalSalarios += costosMensuales;

                            for (int i = 0; i < filas; i++)
                            {
                                for (int j = 0; j < columnas; j++)
                                {
                                    if (!parcela[i, j].EstaVacia())
                                    {
                                        parcela[i, j].Crecer();

                                        if (parcela[i, j].mesesRestantes == 0)
                                        {
                                            double ganancia =
                                                parcela[i, j].Cosechar();

                                            dinero += ganancia;
                                            ingresosTotales += ganancia;
                                        }
                                    }
                                }
                            }

                            meses--;
                            mesActual++;

                            Console.WriteLine("\nMes avanzado correctamente.");
                            Console.WriteLine($"Mes actual: {mesActual}");
                            Console.WriteLine($"Dinero disponible: Q{dinero}");

                            break;
                        }

                    case 5:         // OPCION PARA SALIR DEL PROGRAMA
                    {
                            meses = 0;
                            break;
                        }

                    default:
                        Console.WriteLine("Opcion invalida.");
                        break;
                }

                Console.WriteLine("\nPresione ENTER para continuar...");
                Console.ReadKey();
            }

            // =========================
            // REPORTE FINAL
            // =========================

            Console.Clear();

            double utilidadFinal =
                capitalInicial +
                ingresosTotales -
                totalSalarios -
                totalSemillas;

            Console.WriteLine("====== REPORTE FINAL ======\n");

            Console.WriteLine($"Capital inicial: Q{capitalInicial}");
            Console.WriteLine($"Ingresos totales: Q{ingresosTotales}");
            Console.WriteLine($"Total salarios: Q{totalSalarios}");
            Console.WriteLine($"Materia prima: Q{totalSemillas}");
            Console.WriteLine($"Dinero final: Q{dinero}");
            Console.WriteLine($"Utilidad final: Q{utilidadFinal}");

            Console.WriteLine("\nFin del programa.");
        }
    }