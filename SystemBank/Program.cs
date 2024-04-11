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
            string nombre, apellido, nip;
            Console.WriteLine("Bienvenidos a MonsterINC.\n"); 
            Console.WriteLine("Ingrese los siguientes campos para el nuevo empleado : \n");
            Console.Write("Escriba su nombre : ");
            nombre = Console.ReadLine();
            Console.Write("Escriba su aoellido : ");
            apellido = Console.ReadLine();
            Console.Write("Escriba su Nip: ");
            nip = Console.ReadLine();   

            Empleado empleado = new Empleado(nombre,apellido);
            empleado.Nip = nip;
            Console.WriteLine("\n****INFORMACIÓN DEL NEW TRABAJAMONSTER ***** \n" +
                "");
            Console.WriteLine(empleado.ToString());
            

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
        private string AsignarBank()
        {
            Random ramdom = new Random();
            int asignarBanco;
            string banco = "";
            asignarBanco = ramdom.Next(1,6);
            switch(asignarBanco)
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
            mensaje = "Emleado : "+name +" " + apellido + "\nNúmero de empleado: "+id+"\nLocket N°:" + locker + "\nBanco asignado: " + banco;
            return mensaje;
        }


    }
}
