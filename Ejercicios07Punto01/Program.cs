using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleTables.Core;

namespace Ejercicios07Punto01ConListas
{
    class Program
    {
        static void Main(string[] args)
        {
            //double[] tempSemana = new[] { 14.5, 10.7, 8.7, 10, 12, 14, 18 };//se define e inicializa el vector
            var tempSemana=new List<double>();
            do
            {
                #region Menu Principal

                int intOpcion;
                Console.Clear();//Limpia la pantalla
                Console.WriteLine("Menú Principal");
                Console.WriteLine("0 - Salir");
                Console.WriteLine("1 - Ingresar Datos");
                Console.WriteLine("2 - Modificar Datos x Indice");
                Console.WriteLine("3 - Modificar Datos x Contenido");
                Console.WriteLine("4 - Listar Datos");
                Console.WriteLine("5 - Estadísticas de Datos");
                Console.WriteLine("6 - Listado Estadístico");
                Console.WriteLine("7 - Ordenar Datos");
                Console.WriteLine("8 - Reiniciar");
                Console.WriteLine();
                do
                {
                    Console.Write("Ingrese una opción del menú:");
                    if (!int.TryParse(Console.ReadLine(), out intOpcion))
                    {
                        Console.WriteLine("Opción mal ingresada");
                    }
                    else
                    {
                        break;//me saca del ciclo
                    }

                } while (true);
                #endregion

                #region Opcion Elegida

                string opcionElegida;
                switch (intOpcion)
                {
                    case 0://Salir del Programa
                        Environment.Exit(0);
                        break;
                    case 1://Ingresar datos
                        opcionElegida = "Ingreso de datos";
                        IngresarDatos(opcionElegida, tempSemana);
                        break;
                    case 2://Modificar datos
                        opcionElegida = "Modificación de Datos";
                        ModificarDatos(opcionElegida, tempSemana);
                        break;
                    case 3://Modifcar datos por contenido
                        opcionElegida = "Modificar datos por Contenido";
                        ModificarDatosPorContenido(opcionElegida, tempSemana);
                        break;
                    case 4://Listar Datos
                        opcionElegida = "Listado de Datos";
                        ListarDatos(opcionElegida, tempSemana);
                        break;
                    case 5://Estadisticas
                        opcionElegida = "Estadísticas";
                        Estadisticas(opcionElegida, tempSemana);
                        break;
                    case 6://Listado Estadístico
                        opcionElegida = "Listado Estadístico";
                        ListaEstadistico(opcionElegida, tempSemana);
                        break;
                    case 7://Ordenar Vector
                        opcionElegida = "Ordenar Vector";
                        OrdenarVector(opcionElegida,tempSemana);
                        break;
                    case 8://Reiniciar Vector
                        opcionElegida = "Reinicio";
                        ReinicioDelVector(opcionElegida, tempSemana);
                        break;
                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }

                #endregion

            } while (true);

        }

        private static void ReinicioDelVector(string opcionElegida, List<double> tempSemana)
        {
            IngresoAlMetodo(opcionElegida);
            string respuesta;
            do
            {
                Console.Write("¿Desea borrar todos los datos de la lista?(S/N):");
                respuesta = Console.ReadLine();
                if (respuesta.ToUpper()!="S" && respuesta.ToUpper()!="N")
                {
                    Console.WriteLine("Debe ingresar S o N... pruebe otra vez");
                }
                else
                {
                    break;
                }

            } while (true);

            if (respuesta.ToUpper()=="S")
            {
                 tempSemana.Clear();
            }
        }

        private static void OrdenarVector(string opcionElegida, List<double> tempSemana)
        {
            IngresoAlMetodo(opcionElegida);
            var listaOrdenada= OrdenamientoDelVector(tempSemana);
            MostrarDatosEnTabla(listaOrdenada,false);
            SalidaDelMetodo(opcionElegida);
        }

        private static List<double> OrdenamientoDelVector(List<double> tempSemana)
        {
            return tempSemana.OrderBy(t => t).ToList();
        }

        private static void ListaEstadistico(string opcionElegida, List<double> tempSemana)
        {
            IngresoAlMetodo(opcionElegida);
            double promedio = CalcularPromedio(tempSemana);
            MostrarDatosEnTabla(tempSemana,promedio);
            SalidaDelMetodo(opcionElegida);
            

        }

        private static void Estadisticas(string opcionElegida, List<double> tempSemana)
        {
            IngresoAlMetodo(opcionElegida);
            MostrarDatosEnTabla(tempSemana,false);
            var mayorTemperatura = HallarMayorTemperatura(tempSemana);
            var menorTemperatura = HallarMenorTemperatura(tempSemana);
            var promedioTemperaturas = CalcularPromedio(tempSemana);
            Console.WriteLine($"Mayor Temperatura:{mayorTemperatura}");
            Console.WriteLine($"Menor Temperatura:{menorTemperatura}");
            Console.WriteLine($"Promedio:{promedioTemperaturas:N2}");
            SalidaDelMetodo(opcionElegida);
        }

        private static double CalcularPromedio(List<double> tempSemana)
        {
            
            return tempSemana.Average();
        }

        private static double HallarMenorTemperatura(List<double> tempSemana)
        {
            return tempSemana.Min();
        }

        private static double HallarMayorTemperatura(List<double> tempSemana)
        {
            return tempSemana.Max();
        }

        private static void ModificarDatosPorContenido(string opcionElegida, List<double> tempSemana)
        {
            IngresoAlMetodo(opcionElegida);
            MostrarDatosEnTabla(tempSemana,false);
            Console.Write("Ingrese el valor a modificar:");
            var elementoModificar = double.Parse(Console.ReadLine());
            /*El metodo IndexOf me devuelve el indice del elemento a modificar
             de acuerdo con el vector que le pase en el primer argumento*/
            var intIndex = tempSemana.IndexOf(elementoModificar);
            if (intIndex >= 0)
            {
                Console.WriteLine($"El valor {elementoModificar} se encuentra en la posición {intIndex} del vector");
                Console.Write("Ingrese un nuevo contenido:");
                tempSemana[intIndex] = double.Parse(Console.ReadLine());

            }
            else
            {
                Console.WriteLine($"El elemento {elementoModificar} no se encuentra en el vector");
            }
            SalidaDelMetodo(opcionElegida);
        }

        private static void ListarDatos(string opcionElegida, List<double> tempSemana)
        {
            IngresoAlMetodo(opcionElegida);
            MostrarDatosEnTabla(tempSemana,true);
            SalidaDelMetodo(opcionElegida);
        }

        private static void MostrarDatosEnTabla(List<double> tempSemana, double promedio)
        {
            Console.Write($"El promedio de temperaturas es {promedio}");
            ConsoleTable tabla=new ConsoleTable("Día Nro", "Temperatura","Mayor a Promedio");
            int contadorDias = 0;
            foreach (var temperatura in tempSemana)
            {
                if (temperatura>promedio)
                {
                    tabla.AddRow(contadorDias,temperatura,"*");
                }
                else
                {
                    tabla.AddRow(contadorDias, temperatura,string.Empty);
                }

                contadorDias++;
            }
            tabla.Write();
        }
        private static void MostrarDatosEnTabla(List<double> tempSemana,bool mostrarFahrenheit)
        {
            ConsoleTable tabla;
            if (mostrarFahrenheit)
            {
                tabla = new ConsoleTable("Día Nro", "Temperatura","Fahrenheit"); //Crea una tabla en consola
                
            }
            else
            {
                tabla = new ConsoleTable("Día Nro", "Temperatura");
            }

            var contadorDias = 0;
            foreach (var temperatura in tempSemana)
            {
                if (mostrarFahrenheit)
                {
                    var fahrenheit = ConvertirFahrenheit(temperatura);
                    tabla.AddRow(contadorDias + 1, temperatura,fahrenheit); //Agrega una fila a la tabla en consola
                }
                else
                {
                    tabla.AddRow(contadorDias + 1, temperatura); //Agrega una fila a la tabla en consola
                }

                contadorDias++;
            }

            tabla.Write(); //Muestra la tabla en consola
        }

        private static double ConvertirFahrenheit(double celsius)
        {
            return celsius * 1.8 + 32;
        }

        private static void IngresoAlMetodo(string opcionElegida)
        {
            Console.Clear();
            Console.WriteLine($"{opcionElegida}");
        }

        private static void ModificarDatos(string opcionElegida, List<double> tempSemana)
        {
            IngresoAlMetodo(opcionElegida);
            MostrarDatosEnTabla(tempSemana,false);
            var intIndex = 0;
            do
            {
                Console.Write("Ingrese el nro. de elemento a modificar:");
                if (!int.TryParse(Console.ReadLine(), out intIndex))
                {
                    Console.WriteLine("Indice mal ingresado");
                }
                else if (intIndex < 1 || intIndex > tempSemana.Count)//me fijo que esté entre 0 y la cantidad de elementos menos 1
                {
                    Console.WriteLine("Indice fuera del rango permitido");
                }
                else
                {
                    break;
                }

            } while (true);
            Console.WriteLine($"El elemento {intIndex} del vector es {tempSemana[intIndex-1]}");
            Console.Write("Ingrese la nueva temperatura:");
            tempSemana[intIndex-1] = double.Parse(Console.ReadLine());
            SalidaDelMetodo(opcionElegida);

        }

        private static void IngresarDatos(string opcionElegida, List<double> tempSemana)
        {
            IngresoAlMetodo(opcionElegida);
            do
            {
                double temperatura;
                do
                {
                    Console.Write($"Ingrese una temperatura:");
                    if (!double.TryParse(Console.ReadLine(), out temperatura))
                    {
                        Console.WriteLine("Temperatura mal ingresada");
                    }
                    else if (temperatura < -10 || temperatura > 24)
                    {
                        Console.WriteLine("Temperatura fuera del rango permitido");
                    }
                    else
                    {
                        break;
                    }

                } while (true);
                tempSemana.Add(temperatura);
                Console.WriteLine("Desea ingresar otra temperatura?:");
                var respuesta = Console.ReadLine();
                if (respuesta.ToUpper()=="N")
                {
                    break;
                }
            } while (true);

            SalidaDelMetodo(opcionElegida);
        }

        private static void SalidaDelMetodo(string opcionElegida)
        {
            Console.WriteLine($"Fin de {opcionElegida}... Tecla para continuar");
            Console.ReadLine();
        }
    }
}
