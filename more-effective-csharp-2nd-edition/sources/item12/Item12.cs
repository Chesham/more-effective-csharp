using System;

namespace item12
{
    public class Item12
    {
        public string SetName(string lastName, string firstName = "Lin")
        {
            return firstName + " " + lastName;
        }

        /*public string SetName(string lastName)
        {
            return "KUO " + lastName;
        }
        public string SetName(string lastName, string firstName)
        {
            return firstName + " " + lastName;
        }*/

        public int compute(int one, int two = 5, int three = 10)
        {
            return one + two * three;
        }
    }
}
