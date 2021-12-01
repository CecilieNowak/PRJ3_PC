using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using System.Xml.Xsl;
using DTO_BloodPressureData;


namespace DataAccessLayer
{
    public class UDPListener
    {

        private const int listenPort = 11000;
        string jsonString;
        
        private readonly BlockingCollection<BloodPressureData> _dataQueue;
        private readonly UdpClient listener;

        public UDPListener(BlockingCollection<BloodPressureData> dataQueue)
        {
            _dataQueue = dataQueue;
            listener = new UdpClient(listenPort);

        }

        public void StartListener()
        {
                    IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, listenPort);

                     try
                     {
                         while (true)
                         {


                             BloodPressureData blodData = new BloodPressureData();

                             Console.WriteLine("Waiting for broadcast");
                             byte[] bytes = listener.Receive(ref groupEP);

                             jsonString = Encoding.ASCII.GetString(bytes, 0, bytes.Length);

                             blodData = JsonSerializer
                                 .Deserialize<
                                     BloodPressureData>(
                                     jsonString); // Her tilføjer vi de modtaget data til objektet blodData

                             _dataQueue.Add(blodData);


                         }

                     }
                     catch (Exception e)
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
