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
            for (int i = 0; i < 100; i++)
            {
                BloodPressureData bp = new BloodPressureData();
               
                bp.Værdi = 10;
                
                if (i == 10) 
                {

                    bp.Værdi = 100;
                }

                if (i == 20)
                {
                    bp.Værdi = 300;
                }

                _bp.NewDataReceived(bp);

                Thread.Sleep(100);
            }

                
                }
            } 
        }
    




