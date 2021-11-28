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
        

        public BloodPressureSubject()
        {
            dtoList = new List<BloodPressureData>();
            }

        public void NewDataRecieved(BloodPressureData bp)
        {
            dtoList.Add(bp);
            
            
            Notify();

        }

        public List<BloodPressureData> GetNewestDTO()
        {
            List<BloodPressureData> lokal = new List<BloodPressureData>();
            for (int i = 0; i <= 10; i++)
            {
                int counter = dtoList.Count - 1;
            }

            return lokal;

        }
        }

    }


