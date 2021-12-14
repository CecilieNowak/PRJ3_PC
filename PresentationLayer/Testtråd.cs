using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogicLayer;
using DTO_BloodPressureData;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Documents;

namespace PresentationLayer
{
    class Testtråd
    {

        //Klassen er en fake-tråd / mock som kalder newDataRecieved med en random genereret DTO, for at teste om observer-mønsteret kører som det skal


        private MainWindow _mainWindow;
        private BloodPressureSubject _bp;
        private Random random;


        public Testtråd(MainWindow mw, BloodPressureSubject bp)
        {
            _mainWindow = mw;
            _bp = bp;
            random = new Random();
        }

        public void updateChart()
        {
            
            for (int i = 0; i < 1000; i++)
            {
                BloodPressureData bp = new BloodPressureData();

                bp.Værdi = random.Next(100, 250);


                if (i == 5)
                {
                    bp.Værdi = 100;
                }
                if (i == 25)
                {
                    bp.Værdi = 100;
                }
                if (i == 45)
                {
                    bp.Værdi = 100;
                }

                if (i == 65)
                {
                    bp.Værdi = 100;
                }
                if (i == 85)
                {
                    bp.Værdi = 130;
                }
                if (i == 105)
                {
                    bp.Værdi = 129;
                }
                if (i == 125)
                {
                    bp.Værdi = 130;
                }

                _bp.NewDataReceived(bp);

                Thread.Sleep(100);
                //public void updateChart()
                //{

                //    for (int i = 0; i < 100; i++)
                //    {
                //        BloodPressureData dto = new BloodPressureData();
                //        //dto.battery = 900;
                //        dto.Værdi = 100;
                //        _bp.NewDataReceived(dto);



                //        //if (i == 6 || i == 34 || i == 35 || i == 36 || i == 37 || i == 38 || i == 39 || i == 40 ||
                //        //    i == 41 || i == 42 || i == 43 || i == 44 || i == 45 || i == 46 || i == 47 || i == 48)
                //        //{
                //        //    //_bp.NewDataReceived(dto);
                //        //    dto.Værdi = 200;
                //        //}
                //        //else if (i == 66)
                //        //{
                //        //    //_bp.NewDataReceived(dto);
                //        //    dto.Værdi = 100;
                //        //}


                //        Thread.Sleep(100);
                //    }



                //}
            }
        }
    }
}




