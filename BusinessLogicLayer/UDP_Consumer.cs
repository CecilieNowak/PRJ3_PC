﻿using System;
using System.Collections.Concurrent;
using System.Threading;
using DataAccessLayer;
using DTO_BloodPressureData;

namespace BusinessLogicLayer

{
    public class UDP_Consumer
    {
        
        private readonly BloodPressureSubject _bps;
        private readonly BlockingCollection<BloodPressureData> _dataQueue;


        public UDP_Consumer(BlockingCollection<BloodPressureData> dataQueue, BloodPressureSubject bps)
        {
            _dataQueue = dataQueue;
            _bps = bps;
        }

        public void UpdateChart()
        {
            
            while (!_dataQueue.IsCompleted)
            {

                var container = _dataQueue.Take();

                _bps.NewDataRecieved(container);

                Thread.Sleep(10);
                
            }

        }
    }
}
