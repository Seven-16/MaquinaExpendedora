using System;
using System.Collections.Generic;

namespace MaquinaExpendedora
{
    public class Snack
    {
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }
    }

    public class MaquinaDeSnacks
    {
        private Dictionary<string, Snack> inventario;

        public MaquinaDeSnacks()
        {
            inventario = new Dictionary<string, Snack>
            {
                { "Papas fritas", new Snack { Nombre = "Papas fritas", Precio = 1.50, Stock = 10 } },
                { "Galletas", new Snack { Nombre = "Galletas", Precio = 1.00, Stock = 10 } },
                { "Chocolate", new Snack { Nombre = "Chocolate", Precio = 2.00, Stock = 10 } }
            };
        }

        public string ComprarSnack(string nombreSnack, int cantidad, double pago)
        {
            if (!inventario.ContainsKey(nombreSnack))
                return "Snack no disponible.";

            var snack = inventario[nombreSnack];

            if (snack.Stock < cantidad)
                return "Stock insuficiente.";

            double costoTotal = snack.Precio * cantidad;

            if (pago < costoTotal)
                return "Pago insuficiente.";

            snack.Stock -= cantidad;
            return $"Compra exitosa. Cambio: ${pago - costoTotal:F2}";
        }

        public void MostrarInventario()
        {
            Console.WriteLine("\nInventario de la Máquina Expendedora:");
            foreach (var snack in inventario.Values)
            {
                Console.WriteLine($"{snack.Nombre} - Precio: ${snack.Precio:F2} - Stock: {snack.Stock}");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            MaquinaDeSnacks maquina = new MaquinaDeSnacks();
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\nSeleccione una opción:");
                Console.WriteLine("1. Comprar snack");
                Console.WriteLine("2. Ver inventario");
                Console.WriteLine("3. Salir");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("Ingrese el nombre del snack:");
                        string nombre = Console.ReadLine();

                        Console.WriteLine("Ingrese la cantidad:");
                        int cantidad = int.Parse(Console.ReadLine());

                        Console.WriteLine("Ingrese el pago:");
                        double pago = double.Parse(Console.ReadLine());

                        string resultado = maquina.ComprarSnack(nombre, cantidad, pago);
                        Console.WriteLine(resultado);
                        break;

                    case "2":
                        maquina.MostrarInventario();
                        break;

                    case "3":
                        salir = true;
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }
    }
}
