using ProcessOrder.Entities;
using ProcessOrder.Entities.Enums;
using System;
using System.Globalization;

namespace ProcessOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entre com os dados do cliente:");
            Console.Write("Nome: ");
            string clientName = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Data de aniversário: ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            Client client = new Client(clientName, email, birthDate);

            Console.WriteLine("Entre com os dados do pedido:");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

            Order order = new Order(DateTime.Now, status, client);

            Console.Write("Quantos itens para este pedido? ");
            int n = int.Parse(Console.ReadLine());

            for(int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Entre com os dados do intem #{i}");
                Console.Write("Nome do produto: ");
                string prodName = Console.ReadLine();
                Console.Write("Preço do produto: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantidade: ");
                int quantity = int.Parse(Console.ReadLine());

                Product product = new Product(prodName, price);
                OrderItem item = new OrderItem(quantity, price, product);

                order.AddItem(item);
            }
            Console.WriteLine();
            Console.WriteLine("SUMÁRIO DO PEDIDO:");
            Console.WriteLine(order);

        }
    }
}
