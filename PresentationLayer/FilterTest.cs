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
            
            while (true)
            {
                BloodPressureData dto = new BloodPressureData();
                dto.Værdi = random.Next(0,100);
                
                _bp.NewDataReceived(dto);

              

                Thread.Sleep(100);

            }

        }
    }
}
