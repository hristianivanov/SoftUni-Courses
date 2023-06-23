using System.Diagnostics;

namespace Chronometer
{
    public class Chronometer : IChronometer
    {
        private Stopwatch stopwatch;
        private List<string> laps;

        public Chronometer()
        {
            stopwatch = new Stopwatch();
            laps = new List<string>();
        }



        public string GetTime
        => stopwatch.Elapsed.ToString(@"mm\:ss\.ff");
        public List<string> Laps
        => laps;

        public void Start()
        => stopwatch.Start();
        public void Stop()
        => stopwatch.Stop();
        public string Lap()
        {
            string result = GetTime;
            laps.Add(result);
            return result;
        }
        public void Reset()
        {
            stopwatch.Reset();
            laps.Clear();
        }
    }
}
