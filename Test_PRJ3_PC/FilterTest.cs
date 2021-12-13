using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogicLayer;
using DTO_BloodPressureData;
using NUnit.Framework;
using PresentationLayer;

namespace Test_PRJ3_PC
{
    [TestFixture]
        
    class FilterTest
    {

            private Filter _uut;
            private BloodPressureSubject _subject;
            private UDPmock _UDPmock;
            private MainWindow _mw;
            
            
            [SetUp]
            public void Setup()
            {
                _subject = new BloodPressureSubject();
                _mw = new MainWindow();
                _uut = new Filter(_subject);
                _UDPmock = new UDPmock(_mw,_subject);
                
            }

            [Test]
            public void testOfGetDTOSample()
            {
                List<BloodPressureData> lokal = _UDPmock.getList();

                double avg = 0;
                foreach (var bloodPressureData in lokal)
                {
                    avg += bloodPressureData.Værdi;
                }

                BloodPressureData bp = _uut.getDTOSample();
                Assert.That(bp.Værdi, Is.EqualTo(avg));

            }


        }
    }
