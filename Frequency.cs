namespace ATISPlugin
{
    internal class Frequency
    {
        public Frequency() { }

        public Frequency(string icao, string freq) 
        { 
            ICAO = icao;
            Freq = freq;
        }

        public string ICAO { get; set; }
        public string Freq { get; set; }
    }
}
