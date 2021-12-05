using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BusinessLogicLayer;
using DTO_BloodPressureData;
using PresentationLayer;

namespace Test_PRJ3_PC
{
    [TestFixture]
    class TestAfLiveChart
    {
        private BloodPressureSubject subject;
        private MainWindow uut;
        private DisplayObserver observer;
        private BloodPressureData dto1;

        [SetUp]
        public void Setup()
        {
            subject = new BloodPressureSubject();
            observer = new DisplayObserver(subject, uut);
            uut = new MainWindow();

            int puls = 80;

            dto1 = new BloodPressureData();

            dto1.Pulse = puls;

            subject.newDataRecieved(dto1);

            

        }

        [Test]
        public void Test_newDataRecievedWithPredefinedDTOs()
        {
            

            Assert.That(uut.YValues, Contains.Item(dto1));

            
        }

    }
}