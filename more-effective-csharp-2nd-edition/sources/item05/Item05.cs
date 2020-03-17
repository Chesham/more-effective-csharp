using System;

namespace item05
{
    public enum Planet
    {
        None = 0,
        Mercury = 1,
        Venus = 2,
        Earth = 3,
        Mars = 4
    }

    public struct LogMessage
    {
        private int ErrLevel;
        private string msg;
        public string Message 
        {
            get => msg;
            set=> msg = value;
        }
    }

    public struct LogMessageV2
    {
        private string msg;
        private int ErrLevel;
        public string Message
        {
            get => msg ?? string.Empty;
            set => msg = value;
        }
    }

    public struct Obs
    {
        public Planet whichPlanet; //觀測目標
        public double magnitude; //亮度
    }

    public struct ObsV2
    {
        public Planet whichPlanet; //觀測目標
        public double magnitude; //亮度
        public ObsV2(Planet target, double mag)
        {
            whichPlanet = target;
            magnitude = mag;
        }
    }
}
