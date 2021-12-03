using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer;
using DTO_BloodPressureData;

namespace BusinessLogicLayer
{
    public class BloodPressureSubject : AbstractBloodPressureData
    {
        private readonly List<BloodPressureData> dtoList;
        public int counter { get; private set; }
        

        public BloodPressureSubject()
        {
            dtoList = new List<BloodPressureData>();
            counter = 9;

        }

        public void NewDataRecieved(BloodPressureData bp)
        {
            dtoList.Add(bp);
            
            
            Notify();

        }

        public List<BloodPressureData> GetNewestDTO()
        {
            List<BloodPressureData> lokal = new List<BloodPressureData>();
            if (dtoList.Count > 9)
            {
                for (int i = counter -9 ; i <= counter; i++)
                {
                    BloodPressureData lokalbp = dtoList[i];
                    lokal.Add(lokalbp);
                    
                }

                counter = +10;

            }

            return lokal;

        }
        }

    }


