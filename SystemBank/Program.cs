using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemBank
{
    class Program
    {
        static void Main(string[] args)
        {
            string nombre, apellido;
            Console.WriteLine("BIENVENIDO AL SISTEMA BANCARIO DE MONSTER INC \n");
            Console.WriteLine("Ingrese los siguientes campos para el nuevo empleado:\n");
            Console.Write("Escriba su nombre: ");
            nombre = Console.ReadLine();
            Console.Write("Escriba su apellido: ");
            apellido = Console.ReadLine();
            Console.WriteLine("\nSELECCIONE LA OPCION QUE DESEA : \n");
            Console.WriteLine("1. REGISTRAR TRABAJADOR");
            Console.WriteLine("2. CREAR CUENTA PARA TRABAJADOR ");
            byte opc = Convert.ToByte(Console.ReadLine());
            switch (opc)
            {
                case 1:
                    RegistrarEmpleado(nombre,apellido);
                    return;
                case 2:
                    BankSystem(nombre,apellido);
                    return;
            }
        }

        public static void RegistrarEmpleado(string nombre,string apellido)
        {
            string nip;
            Console.WriteLine("\n ¡BIENVENIDO AL SISTEMA DE CREACIÓN DE EMPLEADOS DE MonsterINC! \n");
            Console.WriteLine("presione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Write("\nSr. {0} Escriba su NIP: ",nombre);
            nip = Console.ReadLine();
            Empleado empleado = new Empleado(nombre, apellido);
            empleado.Nip = nip;
            Console.WriteLine("\n**** INFORMACIÓN DEL NUEVO TRABAJAMONSTER ****\n");
            Console.WriteLine(empleado.ToString());

        }
        public static void BankSystem(string nombreAr,string apellidosAr)
        {
            double monto, saldoInicialAr;
            byte opcion;
            string  direccionAr, rfcAr,banco;
            Console.WriteLine("\n*** BIENVENIDO AL SISTEMA DE CREACIÓN DE CUENTAS ***");
            Console.WriteLine("presione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.WriteLine("\nSR. {0} INGRESE LA SIGUIENTE INFORMACIÓN",nombreAr);
            Console.WriteLine("DIGITE SU DIRECCIÓN: ");
            direccionAr = Console.ReadLine();
            Console.WriteLine("DIGITE SU RFC: ");
            rfcAr = Console.ReadLine(); 
            Console.WriteLine("DIGITE EL MONTO INICIAL DE LA CUENTA : ");
            saldoInicialAr = Convert.ToDouble(Console.ReadLine());
            CuentaBancaria cuenta = new CuentaBancaria(nombreAr,apellidosAr,saldoInicialAr,direccionAr,rfcAr);
            Empleado emp = new Empleado(nombreAr, apellidosAr);
            banco = emp.AsignarBank();
            Console.WriteLine("SU BANCO ES : " + banco);
            Console.WriteLine("\n ¡¡ CUENTA CREADA CON EXITO !!");
            Console.WriteLine("presione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.WriteLine("\nBIENVENIDO {0} {1} A SU CUENTA", nombreAr, apellidosAr);
            do
            {
                Console.WriteLine("SELECCIONE UNA OPCIÓN: ");
                Console.WriteLine("1. DEPOSITAR DINERO ");
                Console.WriteLine("2. RETIRAR DINERO ");
                Console.WriteLine("3. CONSULTAR SALDO ");
                Console.WriteLine("4. MOSTRAR INFORMACIÓN DE CUENTA ");
                Console.WriteLine("5. SALIR");
                opcion = Convert.ToByte(Console.ReadLine());
                switch(opcion)
                {
                    case 1: 
                        Console.WriteLine("Ingrese el monto que desea depositar: $ ");    
                        monto = Convert.ToDouble(Console.ReadLine());
                        cuenta.Deposito(monto);
                        break;
                    case 2:
                        Console.WriteLine("Ingrese el monto que desea retirar: $ ");
                        monto = Convert.ToDouble(Console.ReadLine());
                        cuenta.Retiro(monto);
                        break;
                    case 3:
                        cuenta.ConsultaSaldo();
                        break;
                    case 4:
                        Console.WriteLine(cuenta.ToString());
                        break;
                    case 5: Console.WriteLine("Saliendo del sistema...");
                        break;
                    default: Console.WriteLine("Opcion no valida, por favor seleccione una opcion del 1 a 5");
                        break;
                }
            } while (opcion !=5);


        }
    }

    class Empleado
    {
        private string name, apellido, id, locker, banco, nip;

        //Constructor
        public Empleado(string nombrePa, string apellidoPa)
        {
            name = nombrePa;
            apellido = apellidoPa;

            // llamando metodos

            id = GenerarID();
            locker = GenerarLocket();
            banco = AsignarBank();

        }

        public string Nip
        {
            set => nip = value;
        }

        //metodos
        private string GenerarID()
        {
            Random ramdom = new Random();

            int i, numero;
            string id = "";
            for (i = 0; i < 10; i++)
            {
                numero = ramdom.Next(10);
                id += numero.ToString();
            }
            return id;
        }
        private string GenerarLocket()
        {
            Random ramdom = new Random();

            int i, numero;
            string locker = "";
            for (i = 0; i < 2; i++)
            {
                numero = ramdom.Next(10);
                locker += numero.ToString();
            }
            return locker;
        }
        public string AsignarBank()
        {
            Random ramdom = new Random();
            int asignarBanco;
            string banco = "";
            asignarBanco = ramdom.Next(1, 6);
            switch (asignarBanco)
            {
                case 1:
                    {
                        banco = "Nequi";
                        break;
                    }
                case 2:
                    {
                        banco = "Bancolombia";
                        break;
                    }
                case 3:
                    {
                        banco = "BBVA";
                        break;
                    }
                case 4:
                    {
                        banco = "Davivienda";
                        break;
                    }
                case 5:
                    {
                        banco = "Colpatria";
                        break;
                    }

            }
            return banco;
        }
        public override string ToString()
        {
            string mensaje = "";
            mensaje = "[Empleado: " + name + " " + apellido + "]" + "\n[Número de empleado: " + id + "]" + "\n[Locket N°:" + locker + "]" + "\n[Banco asignado: " + banco +"]" + "\n[NIP : " + nip+ "]";
            return mensaje;
        }
        

    }
    class CuentaBancaria
    {
        private string nombre, apellidos, dirección, rfc;
        private double saldo ;

        public CuentaBancaria(string namePa, string apellidosPa, double saldoPa, string direccionPa, string rfcPa)
        {
            nombre = namePa;
            apellidos = apellidosPa;
            saldo = saldoPa;
            dirección = direccionPa;
            rfc = rfcPa;

        }
        
        public double Deposito(double montoPa)
        {
            saldo += montoPa;
            return saldo;
        }
        public double Retiro(double montoPa)
        {
            if(saldo >= montoPa)
            {
                saldo -= montoPa;
            }
            else
            {
                Console.WriteLine(" ¡ Saldo insuficiente !");
            }return saldo;
        }
        public void ConsultaSaldo()
        {
            Console.WriteLine("Su saldo es: ${0}", saldo);
        }
        public override string ToString()
        {
            
           string mensaje = "\n[Nombre] : " + nombre + "\n[Apellidos] : " + apellidos + "\n[RFC] : " + rfc + "\n[Dirección] : " + dirección + "\n**[SALDO DE LA CUENTA]" + saldo;
            return mensaje;
        }
    }
}