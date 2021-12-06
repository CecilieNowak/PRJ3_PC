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
        public int counter { get; set; } 
        
        

        public BloodPressureSubject()
        {
            dtoList = new List<BloodPressureData>();
            counter = 0;


        }

        public void NewDataRecieved(BloodPressureData bp)
        {
            dtoList.Add(bp);


                Notify();
            
        }

        public List<BloodPressureData> GetNewestDTO()
        {
            List<BloodPressureData> lokal = new List<BloodPressureData>();
            if (dtoList.Count == 10)
            {
                
                foreach (var dto in dtoList)
                {
                   
                    lokal.Add(dto);
                }

                dtoList.RemoveRange(0, 10);


            }

            return lokal;

        }
        }

    }


