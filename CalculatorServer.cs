using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class Server
{
    private static void CalculatorClient(object argument)
    {
        TcpClient client = (TcpClient)argument;

        try
        {
            StreamReader reader = new StreamReader(client.GetStream());
            StreamWriter writer = new StreamWriter(client.GetStream());

            float pesanAngka1 = 0;
            float pesanAngka2 = 0;
            string pesanOperator = string.Empty;
            float hasil = 0;

            while (true)
            {
                string data1 = reader.ReadLine();
                pesanAngka1 = Convert.ToInt32(data1);
                Console.WriteLine("\n [Angka Masuk]        : " + pesanAngka1);

                pesanOperator = reader.ReadLine();
                Console.WriteLine(" [Operator Masuk]     : " + pesanOperator);

                string data2 = reader.ReadLine();
                pesanAngka2 = Convert.ToInt32(data2);
                Console.WriteLine(" [Angka Masuk]        : " + pesanAngka2);

                if (pesanOperator == "+")
                {
                    hasil = pesanAngka1 + pesanAngka2;
                }
                if (pesanOperator == "-")
                {
                    hasil = pesanAngka1 - pesanAngka2;
                }
                if (pesanOperator == "*")
                {
                    hasil = pesanAngka1 * pesanAngka2;
                }
                if (pesanOperator == "/")
                {
                    hasil = pesanAngka1 / pesanAngka2;
                }

                string hasil1 = Convert.ToString(hasil);
                writer.WriteLine(" Hasil Akhirnya      : " + hasil1);
                writer.Flush();
            }
        }
        catch (IOException)
        {
            Console.WriteLine("\n [Ada Client Keluar...]");
        }
        if (client != null)
        {
            client.Close();
        }
    }

    public static void Main()
    {
        TcpListener listener = null;
        try
        {
            listener = new TcpListener(IPAddress.Parse("192.168.100.117"), 8080);
            listener.Start();

            Console.WriteLine(" [Mulai...]");

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine(" [Ada Client Masuk...]");
                Thread newThread = new Thread(CalculatorClient);

                newThread.Start(client);
            }
        }

        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        finally
        {
            if (listener != null)
            {
                listener.Stop();
            }
        }
    }
}