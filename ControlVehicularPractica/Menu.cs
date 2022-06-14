using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlVehicularPractica
{
    class Menu
    {
        //Llamar a clase del control de los datos.
        ControlDatos ControlDatos=new ControlDatos();

        //Procedimiento para mostrar el menú de opciones.
        public void MostrarMenu()
        {
            string opcionesMenu = "-----Menú control vehicular-----\n";
            opcionesMenu += "1.Inicializar vectores.\n";
            opcionesMenu += "2.Ingrese paso vehicular.\n";
            opcionesMenu += "3.Consulta de vehículos por número de placa.\n";
            opcionesMenu += "4.Modificar datos de vehículo por número de placa.\n";
            opcionesMenu += "5.Reporte de todos los datos.\n";
            opcionesMenu += "6.Salir.\n";
            opcionesMenu += "---------------------------------------\n";
            opcionesMenu += "Digite una opción:";
            int opcion;


                do
                {
                    Console.WriteLine(opcionesMenu);
                    opcion=int.Parse(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                        ControlDatos.InicializarVectores();
                            break;
                        case 2:
                        ControlDatos.IngresarDatos();
                            break;
                        case 3:
                        ControlDatos.Consultar(ControlDatos.SolicitarPlaca());
                            break;
                        case 4:
                        ControlDatos.Modificar(ControlDatos.SolicitarPlaca());
                            break;
                        case 5:
                        ControlDatos.Reporte();
                            break;
                        case 6:
                            break;
                        default:
                        Console.WriteLine("La opción no existe, intentelo de nuevo.");
                            break;
                    }
                } while (opcion!=6);
            
        }
    }
}
