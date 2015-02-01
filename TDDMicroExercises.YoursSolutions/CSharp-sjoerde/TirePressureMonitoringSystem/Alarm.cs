namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class Alarm
    {
        private const double LowPressureThreshold = 17;
        private const double HighPressureThreshold = 21;

        readonly Sensor _sensor;

        public Sensor Sensor
        {
            get
            {
                return _sensor;
            }
        }

        public bool AlarmOn
        {
            get;
            private set;
        }

        public Alarm() : this(new Sensor())
        {
        }

        public Alarm(Sensor sensor) 
        {
            _sensor = sensor;
        }

        public void Check()
        {
            double psiPressureValue = _sensor.PopNextPressurePsiValue();
            AlarmOn = !IsPressureCorrect(psiPressureValue);
        }

        public bool IsPressureCorrect(double psiPressure)
        {
            if (psiPressure >= LowPressureThreshold && psiPressure <= HighPressureThreshold)
            {
                return true;
            }
            return false;
        }
    }
}
