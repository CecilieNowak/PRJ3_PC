using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer
{
    public interface IBloodPressureObserver
    {
        //Interface til implementering af Observers
        void Update();
    }
}
