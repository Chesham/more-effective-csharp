using System;
using System.Collections.Generic;

namespace item14
{
    public class Item14
    {
    }

    public enum Direction
    {
        North,
        East,
        South,
        West
    }

    public class WeatherData
    {
        public WeatherData(double temp, int speed, Direction direction)
        {
            Temperature = temp;
            WindSpeed = speed;
            WindDirection = direction;
        }
        public double Temperature { get; }
        public int WindSpeed { get; }
        public Direction WindDirection { get; }
        public override string ToString() =>
            $@"Temperature={Temperature},Wind is {WindSpeed} mph from the {WindDirection}";

        public static void PrintCollection<T>(IEnumerable<T> collection)
        {
            foreach (T o in collection)
            {
                Console.WriteLine($"Collection contains {o}");
            }
        }
    }

    public class WeatherDataStream : IEnumerable<WeatherData>
    {
        private Random generator = new Random();
        public WeatherDataStream(string location)
        {

        }
        private IEnumerator<WeatherData> getElements()
        {
            for (int i = 0; i < 100; i++)
            {
                yield return new WeatherData(
                    temp: generator.NextDouble() * 90,
                    speed: generator.Next(70),
                    direction: (Direction)generator.Next(3));
            }
        }
        public IEnumerator<WeatherData> GetEnumerator() => getElements();

        System.Collections.IEnumerator
            System.Collections.IEnumerable.GetEnumerator() => getElements();
    }
}
