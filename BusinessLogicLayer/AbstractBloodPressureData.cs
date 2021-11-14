using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer
{
    abstract public class AbstractBloodPressureData
    {
        private List<IBloodPressureObserver> _Observers = new List<IBloodPressureObserver>();

        public void Add(IBloodPressureObserver o)
        {
            _Observers.Add(o);
        }

        public void Remove(IBloodPressureObserver o)
        {
            _Observers.Remove(o);
        }

        public void Notify()
        {
            foreach (var bloodPressureObserver in _Observers)
            {
                bloodPressureObserver.Update();
            }
        }
    }
}
