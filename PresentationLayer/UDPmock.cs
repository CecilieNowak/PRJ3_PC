using System;
using System.Collections.Generic;
using System.Text;
using DTO_BloodPressureData;
using BusinessLogicLayer;
using System.Threading;
using System.Threading.Tasks;



namespace PresentationLayer
{
   public class UDPmock
    {

        private MainWindow _mainWindow;
        private BloodPressureSubject _bp;
        private List<BloodPressureData> _list;
        private Random random;


        public UDPmock(MainWindow mw, BloodPressureSubject bp)
        {
            _mainWindow = mw;
            _bp = bp;
            random = new Random();
            _list = new List<BloodPressureData>();

        }



        public void randomDTO()
        {

            while (true)
            {
                //Batteristatus skal være < 2.506 og >2.9
                //for (int i = 0; i < 16; i++)
                //{
                BloodPressureData dto = new BloodPressureData();
                    dto.Værdi = random.Next(0,100);
                    dto.battery = 2.701;
                    _list.Add(dto);

                    _bp.NewDataReceived(dto);
            }


                Thread.Sleep(100);

            //}

        }

        public List<BloodPressureData> getList()
        {
            return _list;
        }
    }
}
