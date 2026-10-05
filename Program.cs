using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caso_semana7
{
    internal class Program
    {
        static int max = 100;
        static string[] nombres = new string[max];
        static double[] notas = new double[max];
        static int contador = 0;
        static public void Titulo()
        {
            Console.WriteLine("******************************");
            Console.WriteLine("Sistema de notas");
            Console.WriteLine("******************************");
        }
        static public void Registrar_estudiante()
        {
            Console.WriteLine("Registro de de estudiante nuevo: ");
            if (contador >= max)
            {
                Console.WriteLine("Llegamos a la capacidad máxima");
                return;
            }
            Console.Write("Ingresar nombres: ");
            string nombre = Console.ReadLine();
            double nota;
            while (true)
            {
                Console.WriteLine("Ingresar nota: ");
                nota= double.Parse(Console.ReadLine());
                if (nota >= 0 && nota <= 20)
                {
                    break;
                }
                Console.WriteLine("ERROR la nota debe ser [0-20]: ");
            }
            nombres[contador] = nombre;
            notas[contador] = nota;
            contador++;
        }
        static public void mostrar()
        {
            Console.WriteLine("*****Listado de Estudiantes*****");
            if (contador == 0)
            {
                Console.WriteLine("No hay datos por mostar");
                return;
            }
            for(int i = 0; i < contador; i++)
            {
                Console.WriteLine((i + 1) +".-"+ nombres[i] + "-Nota:" + notas[i]);
            }
        }
        static public void buscar_estudiantes()
        {
            Console.Write("********BUSCAR ESTUDIANTE********");
            if (contador == 0)
            {
                Console.WriteLine("No hay estudiantes registrados ");
                return;
            }
            Console.Write("Ingresar nombre a buscar: ");
            string nom_buscar= Console.ReadLine().ToLower();
            bool encontrado = false;
            for (int i = 0;i < contador; i++)
            {
                if (nombres[i].ToLower() == nom_buscar)
                {
                    Console.WriteLine(nombres[i]+"tiene " + notas[i]);
                    encontrado = true;
                    break;
                }
            }
            if (!encontrado)
            {
                Console.WriteLine("ESTUDFIANTE NO ENCONTRADO");
            }
        }
        static public void modificar_estudiante()
        {
            Console.WriteLine("********MODIFICAR ESTUDIANTE**********");
            if (contador == 0)
            {
                Console.WriteLine("No hay estudiantes registrados");
                return;
            }
            Console.Write("ingresar mombre de estudiante: ");
            string nombre_buscar=Console.ReadLine().ToLower();
            for(int i = 0; i < contador; i++)
            {
                if (nombres[i].ToLower() == nombre_buscar)
                {
                    Console.WriteLine(nombres[i] + "tine" + notas[i]);
                    double nueva_nota;
                    while (true)
                    {
                        Console.Write("Ingresar la nueva nota: ");
                        nueva_nota=double.Parse(Console.ReadLine());
                        if (nueva_nota >= 0 && nueva_nota <= 20)
                        {
                            notas[i] = nueva_nota;
                            Console.WriteLine("Nota modificada.....");
                            break;
                        }
                        Console.WriteLine("ERROR...Nota no valida [0-20]:");
                    }
                }
            }
            Console.WriteLine("Estudiante no encontrado");
        }
        static public void burbuja()
        {
            double temp_notas;
            string temp_nombres;
            for (int i = 0;i < contador - 1; i++)
            {
                for (int j = 0;j < contador- i - 1; j++)
                {
                    if (notas[j] > notas[i + 1])
                    {
                        temp_notas= notas[j];
                        notas[j] = notas[j+i];
                        notas[j+i] = temp_notas;

                        temp_nombres = nombres[j];
                        nombres[j] = nombres[j + i];
                        nombres[j + i] = temp_nombres;
                    }
                }
            }   
        }

        static public void seleccion_desc()
        {
            Console.WriteLine("***** Reporte Ordenado por Selección (DESC) *****");
            if (contador == 0)
            {
                Console.WriteLine("No hay estudiantes registrados.");
                return;
            }

            double[] temp_notas = (double[])notas.Clone();
            string[] temp_nombres = (string[])nombres.Clone();

            for (int i = 0; i < contador - 1; i++)
            {
                int maxIdx = i;
                for (int j = i + 1; j < contador; j++)
                {
                    if (temp_notas[j] > temp_notas[maxIdx])
                    {
                        maxIdx = j;
                    }
                }
                if (maxIdx != i)
                {
                    double tNota = temp_notas[i];
                    temp_notas[i] = temp_notas[maxIdx];
                    temp_notas[maxIdx] = tNota;

                    string tNombre = temp_nombres[i];
                    temp_nombres[i] = temp_nombres[maxIdx];
                    temp_nombres[maxIdx] = tNombre;
                }
            }

            for (int i = 0; i < contador; i++)
            {
                Console.WriteLine((i + 1) + ".- " + temp_nombres[i] + " - Nota: " + temp_notas[i]);
            }
        }
        static public void promedio_y_maxima()
        {
            Console.WriteLine("***** Promedio y Nota Máxima *****");
            if (contador == 0)
            {
                Console.WriteLine("No hay estudiantes registrados.");
                return;
            }

            double suma = 0;
            double maxNota = notas[0];

            for (int i = 0; i < contador; i++)
            {
                suma += notas[i];
                if (notas[i] > maxNota)
                {
                    maxNota = notas[i];
                }
            }

            double promedio = suma / contador;

            Console.WriteLine($"Promedio general del curso: {promedio:F2}");
            Console.WriteLine($"Nota máxima registrada: {maxNota}");
            Console.WriteLine("Estudiante(s) con la nota máxima:");

            for (int i = 0; i < contador; i++)
            {
                if (notas[i] == maxNota)
                {
                    Console.WriteLine($"- {nombres[i]}");
                }
            }
        }
        static void Main(string[] args)
        {
            Titulo();
            int opc = 0;
            while (opc != 6)
            {
                Console.Clear();
                Console.WriteLine("***********MENÚ PRINCIPAL*************");
                Console.WriteLine("[1]Registrar estudiantes");
                Console.WriteLine("[2]Buscar estudiantes");
                Console.WriteLine("[3]Modificar nota");
                Console.WriteLine("[4]Mostrar lista sin ordenar");
                Console.WriteLine("[5]Mostrar reporte ordenado por burbuja");
                Console.WriteLine("[6]Mostrar por selección DESC");  
                Console.WriteLine("[7]Promedio y nota maxima");    
                Console.WriteLine("[8]Salir");
                Console.WriteLine("Ingresar opción: ");
                if (int.TryParse(Console.ReadLine(), out opc))
                {
                    Console.WriteLine("Ingresar un valor numerico: ");
                    continue;
                }
                opc= int.Parse(Console.ReadLine());
                if (opc <1 || opc > 6)
                {
                    Console.WriteLine("ERROR, opción fuera de rango[1-6]: ");
                    continue;
                }
                switch (opc)
                {
                    case 1: 
                        Registrar_estudiante();
                        break;
                    case 2:
                        buscar_estudiantes();
                        break;
                    case 3:
                        modificar_estudiante();
                        break;
                    case 4:
                        mostrar();
                        break;
                    case 5:
                        burbuja();
                        break;
                    case 6:
                        seleccion_desc();
                        break;
                    case 7:
                        promedio_y_maxima();
                        break;
                    case 8:
                        Console.WriteLine("Gracias por usar el sistema");
                        break;
                    default:
                        Console.WriteLine("Opción Incorrecta...!!");
                        break;
                }
            }
        }
    }
}
