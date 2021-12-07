using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer;
using DTO_BloodPressureData;

namespace BusinessLogicLayer
{
    public class BloodPressureSubject : AbstractBloodPressureData
    {
        public readonly List<BloodPressureData> dtoList; //TODO make private
        public int counter { get; set; } 
        
        

        public BloodPressureSubject()
        {
            dtoList = new List<BloodPressureData>();
            counter = 0;


        }

        public void NewDataRecieved(BloodPressureData bp)
        {
            dtoList.Add(bp);

            if (dtoList.Count >= 10)
            {
                Notify();
            }
        }

        public List<BloodPressureData> GetNewestDTO()
        {
            List<BloodPressureData> lokal = new List<BloodPressureData>();
            if (dtoList.Count == 10)
            {
                lokal.AddRange(dtoList);
                //foreach (var dto in dtoList)
                //{
                   
                //    lokal.Add(dto);
                //}

                dtoList.RemoveAt(0);


            }

            return lokal;

        }
    }

}


