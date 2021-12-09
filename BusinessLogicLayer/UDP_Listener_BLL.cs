using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer;
using DTO_BloodPressureData;

namespace BusinessLogicLayer
{
    public class UDP_Listener_BLL
    {
        private UDPListener listener;

        public UDP_Listener_BLL(BlockingCollection<BloodPressureData> blockingCollection)
        {
            listener = new UDPListener(blockingCollection);
        }

        public void startUDPListener()
        {
            listener.StartListener();
        }
    }
}
