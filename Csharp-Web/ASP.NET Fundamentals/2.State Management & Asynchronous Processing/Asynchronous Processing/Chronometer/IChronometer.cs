namespace Chronometer
{
    public interface IChronometer
    {
        public string GetTime { get; }
        public List<string> Laps { get; }
        void Start();
        void Stop();
        string Lap();
        void Reset();
    }
}
