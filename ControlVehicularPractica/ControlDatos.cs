using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlVehicularPractica
{
    internal class ControlDatos
    {
        //variables globales
        static int[] numeroFactura = new int[15];
        static string[] numeroPlaca = new string[15];
        static string[] fecha = new string[15];
        static string[] hora = new string[15];
        static int[] tipoVehiculo = new int[15];
        static int[] numeroCaseta = new int[15];
        static float[] montoPagar=new float[15];
        static float[] pagaCon=new float[15];
        static float[] vuelto=new float[15];

        static int indice;
        static int modificar;

        //Procedimiento para inicializar el vector.
        public void InicializarVectores()
        {
            indice = 0;
            for (int i = 0; i < 15; i++)
            {
                numeroFactura[i] = 0;
                numeroPlaca[i] = "";
                fecha[i] = "";
                hora[i] = "";
                tipoVehiculo[i] = 0;
                numeroCaseta[i] = 0;
                montoPagar[i] = 0;
                pagaCon[i] = 0;
                vuelto[i] = 0;
            }
            Console.WriteLine("Arreglos inicializados");
        }

        //Procedimiento para ingresar los datos.
        public void IngresarDatos()
        {
            string continuar;
            try
            {
                do
                {
                    Console.WriteLine("-------------------------------------------------------------------------");
                    Console.WriteLine("Ingrese el número de factura: ");
                    numeroFactura[indice] = int.Parse(Console.ReadLine());
                    Console.WriteLine("Ingrese el número de placa: ");
                    numeroPlaca[indice] = Console.ReadLine();
                    Console.WriteLine("Digite la fecha (Formato dd/mm/aa): ");
                    fecha[indice] = Console.ReadLine();
                    Console.WriteLine("Digite la hora (Formato 12:00 am/pm): ");
                    hora[indice] = Console.ReadLine();
                    Console.WriteLine("Digite el tipo de vehiculo: \n**[1=Moto 500,2=Vehículo liviano 700,3=Camión o Pesado 2700,4=Autobús 3700]** ");
                    tipoVehiculo[indice] = int.Parse(Console.ReadLine());
                    TipoVehiculo(tipoVehiculo[indice]);
                    Console.WriteLine("Digite el monto con el que realizará su pago");
                    pagaCon[indice] = float.Parse(Console.ReadLine());
                    Vuelto(pagaCon[indice]);
                    Console.WriteLine("Digite el número de caseta: \n[1=Caseta 1, 2=Caseta 2, 3=Caseta 3]");
                    numeroCaseta[indice]= int.Parse(Console.ReadLine());
                    ComprobarCaseta(numeroCaseta[indice]);
                    indice++;
                    Console.WriteLine("Desea continuar agregando? (Si/No)");
                    continuar = Console.ReadLine().ToLower();
                } while (!continuar.Equals("no"));
            }
            catch (Exception)
            {
                Console.WriteLine("No puede registrar más vehiculos.");
            }
        }
        //Pasar por parámetro el tipo de vehiculo escogido y dar el monto que corresponda.
        private static void TipoVehiculo(int tip)
        {
            if (tip==1)
            {
                montoPagar[indice] = 500;
            }
            else if (tip == 2)
            {
                montoPagar[indice] = 700;
            }
            else if (tip==3)
            {
                montoPagar[indice] = 2700;
            }
            else if (tip==4)
            {
                montoPagar[indice] = 3700;
            }
            else if (tip>=5)/*comprobar si el tipo digitado es igual mayor a 5, si es así quiere decir que no existe
                             y se repetirá en un while hasta que esté en el rango de 1 a 4.*/
            {
                while (tip>=5)
                {
                    Console.WriteLine("**Tipo de vehiculo no existe, por favor digite un tipo de vehiculo válido**: " +
                        "\n**[1=Moto 500, 2=Vehículo liviano 700, 3=Camión o Pesado 2700, 4=Autobús 3700]**");
                    tip=int.Parse(Console.ReadLine());
                    TipoVehiculo(tip);
                }
            }
        }
        //procedimiento que calcula el vuelto que recibirá el usuario.
        private static void Vuelto(float paga)
        {
            bool pagaMenos = true;
            if (paga >= montoPagar[indice])
            {
                paga = pagaCon[indice] - montoPagar[indice];
                vuelto[indice] = paga;
                Console.WriteLine($"Su vuelto es de {vuelto[indice]}");
                pagaMenos = false;
            }
            while (pagaMenos)//si el vuelto es menor al monto a pagar no se validará hasta que sea mayor o igual.
            {
                Console.WriteLine("Su monto a pagar es menor a la tarifa original, digite su monto nuevamente: ");
                paga=float.Parse(Console.ReadLine());
                if (paga >= montoPagar[indice])
                {
                    pagaCon[indice] = paga;
                    vuelto[indice] = pagaCon[indice] - montoPagar[indice];
                    Console.WriteLine($"Ha recibido su vuelto de {vuelto[indice]}, consultelo en reportes también.");
                    pagaMenos = false;
                }
            }              
        }
        //procedimeinto para comprobar el número de caseta
        private static void ComprobarCaseta(int cas)
        {
            while (cas>=4)
            {
                Console.WriteLine("Número de caseta no existe, por favor digite un número de caseta en el rango de 1 a 3: ");
                cas=int.Parse(Console.ReadLine());
                numeroCaseta[indice] = cas;
            }
        }



        /*Continuación de los métodos del menú principal.
         Solicitar número de placa para pasarlo por parámetro en los métodos de Consultar y Modificar.*/
        public static string SolicitarPlaca()
        {
            Console.WriteLine("Ingrese el número de placa: ");
            string placa=Console.ReadLine();

            return placa; 
        }
        //Consultar vehículo por número de placa
        public void Consultar(string plac)
        {
            int i = 0;
            while ((i<indice) && (!plac.Equals(numeroPlaca[i])))
            {
                i++;
            }
            if (i>indice)
            {
                Console.WriteLine("La placa digitada es inexistente.");
            }
            else
            {
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine($"Información registrada es: \n N de factura: {numeroFactura[i]} Fecha: {fecha[i]} Hora: {hora[i]} Tipo de vehículo: {tipoVehiculo[i]} " +
                    $"Caseta: {numeroCaseta[i]} Monto pagar: {montoPagar[i]} Paga con: {pagaCon[i]} Vuelto: {vuelto[i]}");
            }

        }

        //Modificar datos de vehículo según número de placa.
        public void Modificar(string placa)
        {
            int i = 0;
            while ((modificar<indice) && (!placa.Equals(numeroPlaca[modificar])))
            {
                modificar++;
            }
            if (modificar>indice)
            {
                Console.WriteLine("Número de placa no existe");
            }
            else
            {//corregir error, cambiar indice a i en montoPagar y vuelto para que me muestre los datos nuevos. 
                Console.WriteLine("Digite la fecha (Formato dd/mm/aa): ");
                fecha[modificar] = Console.ReadLine();
                Console.WriteLine("Digite la hora (Formato 12:00 am/pm): ");
                hora[modificar] = Console.ReadLine();
                Console.WriteLine("Digite el tipo de vehiculo: \n**[1=Moto 500,2=Vehículo liviano 700,3=Camión o Pesado 2700,4=Autobús 3700]** ");
                tipoVehiculo[modificar] = int.Parse(Console.ReadLine());
                TipoVehicul(tipoVehiculo[modificar]);
                Console.WriteLine("Digite el monto con el que realizará su pago");
                pagaCon[modificar] = float.Parse(Console.ReadLine());
                Cambio(pagaCon[modificar]);
                Console.WriteLine("Digite el número de caseta: \n[1=Caseta 1, 2=Caseta 2, 3=Caseta 3]");
                numeroCaseta[modificar] = int.Parse(Console.ReadLine());
                VerificarCaseta(numeroCaseta[i]);
            }
        }

        //Reporte de todos los datos guardados.
        public void Reporte()
        {
            Console.WriteLine("N de factura    Placa          Fecha        Hora         Tipo de vehículo    Caseta    Monto a pagar    Paga con    Vuelto");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");
            for (int i = 0; i < indice; i++)
            {
                Console.WriteLine($"     {numeroFactura[i]}        {numeroPlaca[i]}          {fecha[i]}       {hora[i]}            {tipoVehiculo[i]}             {numeroCaseta[i]}          {montoPagar[i]}          {pagaCon[i]}              {vuelto[i]}");
            }
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"Cantidad de vehículos: {indice}                                                   Total: {Total()}");
        }

        //Procedimiento que suma todos los montos para mostrar el total en los reportes.
        public float Total()
        {
            float total = 0;
            for (int i = 0; i < indice; i++)
            {
                total += montoPagar[i];
            }
            return total;
        }




        //Procesos de comprobación (mismos de agregar) para el procedimiento de modificar los datos.
        private static void TipoVehicul(int tip)
        {
            if (tip == 1)
            {
                montoPagar[modificar] = 500;
            }
            else if (tip == 2)
            {
                montoPagar[modificar] = 700;
            }
            else if (tip == 3)
            {
                montoPagar[modificar] = 2700;
            }
            else if (tip == 4)
            {
                montoPagar[modificar] = 3700;
            }
            else if (tip >= 5)/*comprobar si el tipo digitado es igual mayor a 5, si es así quiere decir que no existe
                             y se repetirá en un while hasta que esté en el rango de 1 a 4.*/
            {
                while (tip >= 5)
                {
                    Console.WriteLine("**Tipo de vehiculo no existe, por favor digite un tipo de vehiculo válido**: " +
                        "\n**[1=Moto 500, 2=Vehículo liviano 700, 3=Camión o Pesado 2700, 4=Autobús 3700]**");
                    tip = int.Parse(Console.ReadLine());
                    TipoVehicul(tip);
                }
            }
        }
        //procedimiento que calcula el vuelto que recibirá el usuario.
        private static void Cambio(float paga)
        {
            bool pagaMenos = true;
            if (paga >= montoPagar[modificar])
            {
                paga = pagaCon[modificar] - montoPagar[modificar];
                vuelto[modificar] = paga;
                Console.WriteLine($"Su vuelto es de {vuelto[modificar]}");
                pagaMenos = false;
            }
            while (pagaMenos)//si el vuelto es menor al monto a pagar no se validará hasta que sea mayor o igual.
            {
                Console.WriteLine("Su monto a pagar es menor a la tarifa original, digite su monto nuevamente: ");
                paga = float.Parse(Console.ReadLine());
                if (paga >= montoPagar[modificar])
                {
                    pagaCon[modificar] = paga;
                    vuelto[modificar] = pagaCon[modificar] - montoPagar[modificar];
                    Console.WriteLine($"Ha recibido su vuelto de {vuelto[modificar]}, consultelo en reportes también.");
                    pagaMenos = false;
                }
            }
        }
        //procedimeinto para comprobar el número de caseta.
        private static void VerificarCaseta(int cas)
        {
            while (cas >= 4)
            {
                Console.WriteLine("Número de caseta no existe, por favor digite un número de caseta en el rango de 1 a 3: ");
                cas = int.Parse(Console.ReadLine());
                numeroCaseta[modificar] = cas;
            }
        }
    }
}
