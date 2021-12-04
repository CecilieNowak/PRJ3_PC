using System;
using System.Collections.Generic;
using System.Text;
using DTO_BloodPressureData;

namespace DataAccessLayer
{
    public class UDP_Sender_Simulator
    {
        private Random random = new Random();
        private List<BloodPressureData> bpList = new List<BloodPressureData>();
        public int increase { get; set; } 
        public int constant { get; set; } 
        public int decrease { get; set; }
        public int counter { get; set; } = -1;
        public Random _random;

        public UDP_Sender_Simulator()
        {
            _random = new Random();
        }

        public void genererBlodtryksDTOer()
        {
            while(true)
            {
                BloodPressureData lokalBp = new BloodPressureData();
                lokalBp.Værdi = random.Next(0,100);
                bpList.Add(lokalBp);
            }

           

        }

        public BloodPressureData getDTO()
        {
            counter++;


            return bpList[counter];

        }




    }
    }

