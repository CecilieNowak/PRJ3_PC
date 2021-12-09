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
            while (true)
            {
                for (int i = 0; i < 100; i++)
                {
                    BloodPressureData dto = new BloodPressureData();
                    dto.battery = 900;
                    dto.Værdi = 100;
                    _bp.NewDataReceived(dto);


                    if (i == 33 || i == 34 || i == 35 || i == 36 || i == 37 || i == 38 || i == 39 || i == 40 ||
                        i == 41 || i == 42 || i == 43 || i == 44 || i == 45 || i == 46 || i == 47 || i == 48)
                    {
                        _bp.NewDataReceived(dto);
                        dto.Værdi = 50;
                    }
                    else if (i == 66)
                    {
                        _bp.NewDataReceived(dto);
                        dto.Værdi = 100;
                    }

                    Thread.Sleep(100);
                }
            }


        }
            } 
        }
    




