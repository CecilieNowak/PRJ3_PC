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



                    // Her skal der måske oprettes blockcollection og så skal data fra blodData tilføjes til det 
              

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
