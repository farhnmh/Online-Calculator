using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

public class Client
{
    public static void Main()
    {
        try
        {
            TcpClient client = new TcpClient("192.168.100.117", 8080);
            Console.WriteLine(" [Berhasil Terhubung...]");

            StreamReader reader = new StreamReader(client.GetStream());
            StreamWriter writer = new StreamWriter(client.GetStream());

            string pesanAngka1;
            string pesanAngka2;
            string pesanOperator;

            while (true)
            {
                Console.Write("\n");
                Console.Write(" [Angka Pertama]     : ");
                pesanAngka1 = Console.ReadLine();
                writer.WriteLine(pesanAngka1);
                writer.Flush();

                Console.Write(" [Operator]          : ");
                pesanOperator = Console.ReadLine();
                writer.WriteLine(pesanOperator);
                writer.Flush();

                Console.Write(" [Angka Kedua]       : ");
                pesanAngka2 = Console.ReadLine();
                writer.WriteLine(pesanAngka2);
                writer.Flush();

                string hasil1 = reader.ReadLine();
                Console.WriteLine(hasil1);
            }

            reader.Close();
            writer.Close();
            client.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}