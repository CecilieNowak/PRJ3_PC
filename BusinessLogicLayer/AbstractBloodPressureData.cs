using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer
{
    abstract public class AbstractBloodPressureData
    {
        private object myLock = new object();
        private List<IBloodPressureObserver> _Observers = new List<IBloodPressureObserver>();

        public void Add(IBloodPressureObserver o)
        {
            lock (myLock) //Låst pga. shared ressource. UI-tråden skal på et tidspunkt tilgå _Observers
            {
                _Observers.Add(o); //
            }
        }

        public void Remove(IBloodPressureObserver o)
        {
            //lock (myLock)
            //{
                _Observers.Remove(o); //
            //}
        }

        public void Notify()
        {
            lock (myLock)
            {
                foreach (var bloodPressureObserver in
                    _Observers) //Dette loop kalder update-metoderne i alle de klasser som implementerer interfacet IBloodPressureObserver (indtil videre har vi kun implementeret 'DisplayObserver')
                {
                    bloodPressureObserver.Update();
                }
            }
        }
    }
}
