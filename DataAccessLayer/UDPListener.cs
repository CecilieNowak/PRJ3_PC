using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using DTO_BloodPressureData;


namespace DataAccessLayer
{
    public class UDPListener
    {

        private const int listenPort = 12000;
        string jsonString;
        
        private readonly BlockingCollection<BloodPressureData> _dataQueue;

        public UDPListener(BlockingCollection<BloodPressureData> dataQueue)
        {
            _dataQueue = dataQueue;
        }

        public void StartListener()
        {
            UdpClient listener = new UdpClient(listenPort);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, listenPort);
            

           

            try
            {
                
                    BloodPressureData blodData = new BloodPressureData();

                    Console.WriteLine("Waiting for broadcast");
                    byte[] bytes = listener.Receive(ref groupEP);

                    jsonString = Encoding.ASCII.GetString(bytes, 0, bytes.Length);

                    blodData = JsonSerializer.Deserialize<BloodPressureData>(jsonString);    // Her tilføjer vi de modtaget data til objektet blodData
                    
                    //Console.WriteLine("Diastolic: " + blodData.Diastolic + "Systolic: " + blodData.Systolic + "Pulse: " + blodData.Pulse);
                    // Her skal der måske oprettes blockcollection og så skal data fra blodData tilføjes til det 

                    _dataQueue.Add(blodData);



                
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
