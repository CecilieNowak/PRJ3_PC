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

        public UDP_Sender_Simulator()
        {
            increase = 0;
            decrease = 0;
            constant = 0;
        }

        public void genererBlodtryksDTOer()
        {
            for (int i = 1; i < 150; i++)
            {
                BloodPressureData lokalBp = new BloodPressureData();
                lokalBp.Værdi = random.Next(increase, i);
                increase = lokalBp.Værdi;
                bpList.Add(lokalBp);
            }

            for (int k = 1; k < 100; k++)
            {
                BloodPressureData lokalBp = new BloodPressureData();
                lokalBp.Værdi = increase;
                bpList.Add(lokalBp);
            }

            for (int d = 99; d > 50; d--)
            {
                BloodPressureData lokalBp = new BloodPressureData();
                lokalBp.Værdi = random.Next(d,increase);
                bpList.Add(lokalBp);
                increase = lokalBp.Værdi;
            }

            for (int o = 1; o < 50; o++)
            {
                BloodPressureData lokalBp = new BloodPressureData();
                lokalBp.Værdi = increase;
                bpList.Add(lokalBp);

            }

            for (int p = 20; p > 1; p--)
            {
                BloodPressureData lokalBp = new BloodPressureData();
                lokalBp.Værdi = random.Next(p,increase);
                bpList.Add(lokalBp);
                increase = lokalBp.Værdi;
            }

        }

        public BloodPressureData getDTO()
        {
            counter++;
            return bpList[counter];
            

        }




    }
    }

