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
    public class UDPListener_Simulator
    {



        private readonly BlockingCollection<BloodPressureData> _dataQueue;
        private UDP_Sender_Simulator _sender;


        public UDPListener_Simulator(BlockingCollection<BloodPressureData> dataQueue, UDP_Sender_Simulator sender)
        {
            _dataQueue = dataQueue;
            _sender = sender;
        }

        public void StartListener()
        {
            
            try
            {
                while (true)
                {


                    BloodPressureData blodData = new BloodPressureData();


                    blodData = _sender.getDTO();

                    _dataQueue.Add(blodData);



                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }
            finally
            {
                
            }

        }
    }
}
