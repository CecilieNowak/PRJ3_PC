using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using DTO_BloodPressureData;

namespace DataAccessLayer
{
    class UDPListener
    {



        private const int listenPort = 12000;
        string jsonString;

        public void StartListener()
        {
            UdpClient listener = new UdpClient(listenPort);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, listenPort);

            DTO_BloodpressureData blodData = new DTO_BloodpressureData();

            try
            {
                while (true)
                {
                    Console.WriteLine("Waiting for broadcast");
                    byte[] bytes = listener.Receive(ref groupEP);

                    jsonString = Encoding.ASCII.GetString(bytes, 0, bytes.Length);

                    blodData = JsonSerializer.Deserialize<DTO_BloodpressureData>(jsonString);    // Her tilføjer vi de modtaget data til objektet blodData

                    Console.WriteLine($"Received broadcast from {groupEP} :");      // Her udskriver den groupEp som indholder Senden IP adresse

                    Console.WriteLine("Blood pressure data:");

                    Console.WriteLine("Systolic: " + blodData.Systolic);             // Print den modtaget data fra senden på skæmmen
                    Console.WriteLine("diastolic: " + blodData.Diastolic);           // Print den modtaget data fra senden på skæmmen
                    Console.WriteLine("Pulse:" + blodData.Pulse);                    // Print den modtaget data fra senden på skæmmen

                    Console.WriteLine("");                                           // En tom line for at lave en afstand mellem de printet data
                    Console.WriteLine("");                                           // En tom line for at lave en afstand mellem de printet data



                }
            }
            catch (SocketException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                listener.Close();
            }
























        }








    }   
}
