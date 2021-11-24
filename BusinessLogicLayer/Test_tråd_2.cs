using System;
using System.Collections.Concurrent;
using System.Threading;
using DataAccessLayer;
using DTO_BloodPressureData;

namespace BusinessLogicLayer

{
    public class Test_tråd_2
    {
        
        private BloodPressureSubject _bps;
        private UDPListener udp;
        private readonly BlockingCollection<BloodPressureData> _dataQueue;


        public Test_tråd_2(BlockingCollection<BloodPressureData> dataQueue, BloodPressureSubject bps)
        {
            _dataQueue = dataQueue;
            _bps = bps;
            udp = new UDPListener(_dataQueue);
        }

        public void updateChart()
        {
            

            while (!_dataQueue.IsCompleted)
            {
                udp.StartListener();
                var container = _dataQueue.Take();
                _bps.newDataRecieved(container);
                
            }

        }
    }
}
