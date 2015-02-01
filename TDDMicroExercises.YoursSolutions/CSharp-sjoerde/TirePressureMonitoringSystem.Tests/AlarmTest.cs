using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TDDMicroExercises.TirePressureMonitoringSystem.Tests
{
    public class TestSensor : Sensor 
    {
        public double MockedPressure { get; set; }

        public override double PopNextPressurePsiValue()
        {
            return MockedPressure;
        }
    }

    [TestClass]
    public class AlarmTest
    {
        [TestMethod]
        public void TestPressureBelowThreshold()
        {
            // Arrange
            Alarm alarm = new Alarm();

            // Act
            bool pressureCorrect = alarm.IsPressureCorrect(16);

            // Assert
            Assert.IsFalse(pressureCorrect);
        }

        [TestMethod]
        public void TestPressureAboveThreshold()
        {
            // Arrange
            Alarm alarm = new Alarm();

            // Act
            bool pressureCorrect = alarm.IsPressureCorrect(22);

            // Assert
            Assert.IsFalse(pressureCorrect);
        }

        [TestMethod]
        public void TestPressureCorrect()
        {
            // Arrange
            Alarm alarm = new Alarm();

            // Act
            bool pressureCorrect = alarm.IsPressureCorrect(17);

            // Assert
            Assert.IsTrue(pressureCorrect);

            // Act
            pressureCorrect = alarm.IsPressureCorrect(21);

            // Assert
            Assert.IsTrue(pressureCorrect);
        }

        [TestMethod]
        public void TestAlarmOnBelowThreshold()
        {
            // Arrange
            var sensor = new TestSensor();
            sensor.MockedPressure = 16;
            Alarm alarm = new Alarm(sensor);

            // Act
            alarm.Check();

            // Assert
            Assert.IsTrue(alarm.AlarmOn);
        }

        [TestMethod]
        public void TestAlarmOnAboveThreshold()
        {
            // Arrange
            var sensor = new TestSensor();
            sensor.MockedPressure = 22;
            Alarm alarm = new Alarm(sensor);

            // Act
            alarm.Check();

            // Assert
            Assert.IsTrue(alarm.AlarmOn);
        }

        [TestMethod]
        public void TestAlarmOff()
        {
            // Arrange
            var sensor = new TestSensor();
            sensor.MockedPressure = 17;
            Alarm alarm = new Alarm(sensor);

            // Act
            alarm.Check();

            // Assert
            Assert.IsFalse(alarm.AlarmOn);

            // Arrange
            ((TestSensor)alarm.Sensor).MockedPressure = 21;

            // Act
            alarm.Check();

            // Assert
            Assert.IsFalse(alarm.AlarmOn);
        }
    }
}
