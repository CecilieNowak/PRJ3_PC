using System;
using System.Collections.Generic;
using System.Text;
using DTO_BloodPressureData;
using BusinessLogicLayer;
using System.Threading;
using System.Threading.Tasks;



namespace PresentationLayer
{
    class FilterTest
    {

        private MainWindow _mainWindow;
        private BloodPressureSubject _bp;
        
        private Random random;


        public FilterTest(MainWindow mw, BloodPressureSubject bp)
        {
            _mainWindow = mw;
            _bp = bp;
            random = new Random();
            
        }



        public void randomDTO()
        {
            BloodPressureData dto = new BloodPressureData();
            while (true)
            {
                dto.Værdi = 50;
                dto.Diastolic = random.Next(0, 100);
                if (dto.Diastolic > 50 && dto.Diastolic < 55)
                {
                    dto.Værdi = 90;
                }

                dto.Systolic = random.Next(0, 100);
                dto.Pulse = random.Next(0, 100);
                _bp.NewDataRecieved(dto);

              

                Thread.Sleep(100);

            }

        }
    }
}
