using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer
{
    class ChartUpdate
    {
        private MainWindow _mw;

        public ChartUpdate(MainWindow mw)
        {
            _mw = mw;

        }

        public void checkChart()
        {
            while (true)
            {
                if (_mw.YValues.Count > 20)
                {

                    _mw.YValues.RemoveAt(0);

                }
            }
        }
    }
}
