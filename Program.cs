using System;

namespace lab1
{
    struct Train
    {
        public string number;
        public string departure;
        public string destination;
        public int hourOfIn;
        public int minOfIn;
        public int hourOfOut;
        public int minOfOut;

        public Train(string number, string departure, string destination, int hourOfIn, int minOfIn, int hourOfOut, int minOfOut)
        {
            this.number = number;
            this.departure = departure;
            this.destination = destination;
            this.hourOfIn = hourOfIn;
            this.minOfIn = minOfIn;
            this.hourOfOut = hourOfOut;
            this.minOfOut = minOfOut;
        }

        public void GetInfo()
        {
            int parkInMin;
            int parkInHour;
            if (minOfIn <= minOfOut) parkInMin = minOfOut - minOfIn;
            else  parkInMin = minOfOut + 60 - minOfIn;
            parkInHour = hourOfOut - hourOfIn;
            Console.WriteLine("Number of the train: " + number + ", " + "destination: " + destination + ", " + "parking time: " + parkInHour + ":" + parkInMin + ".");
        }

        public void GetAllInfo()
        {
            Console.WriteLine("Number of the train: " + number + ", " + "departure: " + ", " + departure + ", " + "destination: " + destination + ", " + "arrival time: " + hourOfIn + ":" + minOfIn + ", " + "departure: " + hourOfOut + ":" + minOfOut + ".");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Train[] station = new Train[8];
            Train first = new Train("121A", "A", "B", 6, 15, 7, 30);
            station[0] = first;
            Train second = new Train("122B", "A", "C", 6, 30, 7, 20);
            station[1] = second;
            Train third = new Train("123C", "X", "D", 7, 5, 8, 10);
            station[2] = third;
            Train fourth = new Train("124D", "A", "E", 6, 20, 7, 35);
            station[3] = fourth;
            Train fifth = new Train("125E", "Z", "B", 9, 15, 10, 30);
            station[4] = fifth;
            Train sixth = new Train("121F", "A", "D", 11, 5, 12, 10);
            station[5] = sixth;
            Train seventh = new Train("122F", "Z", "E", 14, 30, 15, 45);
            station[6] = seventh;
            Train eighth = new Train("123A", "Y", "B", 12, 15, 13, 30);
            station[7] = eighth;
            Console.WriteLine("Enter the hour of your time:");
            int hour = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the minutes of your time:");
            int min = int.Parse(Console.ReadLine());
            int count1 = 0;
            for(int i = 0; i< station.Length; i++)
            {
                if(station[i].hourOfIn <= hour && station[i].hourOfOut >= hour )
                {
                    if(hour == station[i].hourOfOut && min <= station[i].minOfOut)
                    {
                        Console.WriteLine(station[i].number + " is on the station and going to " + station[i].destination);
                        count1++;
                    }
                    if(hour < station[i].hourOfOut && hour > station[i].hourOfIn)
                    {
                        Console.WriteLine(station[i].number + " is on the station and going to " + station[i].destination);
                        count1++;
                    }
                    if(hour == station[i].hourOfIn && min >= station[i].minOfIn)
                    {
                        Console.WriteLine(station[i].number + " is on the station and going to " + station[i].destination);
                        count1++;
                    }
                }
            }
            if (count1 == 0) Console.WriteLine("There is no train on the station.");
            Console.WriteLine("Enter the destinetion that you need:");
            string des = Console.ReadLine();
            int b = 0;
            for(int k = 0; k<station.Length; k++)
            {
                if (des == station[k].destination)
                {
                    if (station[k].hourOfIn <= hour && station[k].hourOfOut >= hour)
                    {
                        if (hour == station[k].hourOfOut && min <= station[k].minOfOut) b++;
                        if (hour < station[k].hourOfOut && hour > station[k].hourOfIn) b++;
                        if (hour == station[k].hourOfIn && min >= station[k].minOfIn) b++;
                    }
                    if (hour == station[k].hourOfIn && min <= station[k].minOfIn) b++;           
                    if (hour < station[k].hourOfIn) b++;
                }
            }
            if (b > 0)
            {
                Train[] dest = new Train[b];
                int a = 0;
                for (int j = 0; j < station.Length; j++)
                {
                    if (des == station[j].destination)
                    {
                        if (station[j].hourOfIn <= hour && station[j].hourOfOut >= hour)
                        {
                            if (hour == station[j].hourOfOut && min <= station[j].minOfOut)
                            {
                                dest[a] = station[j];
                                a++;
                            }
                            if (hour < station[j].hourOfOut && hour > station[j].hourOfIn)
                            {
                                dest[a] = station[j];
                                a++;
                            }
                            if (hour == station[j].hourOfIn && min >= station[j].minOfIn)
                            {
                                dest[a] = station[j];
                                a++;
                            }
                        }
                        if (hour == station[j].hourOfIn && min <= station[j].minOfIn)
                        {
                            dest[a] = station[j];
                            a++;
                        }
                        if(hour < station[j].hourOfIn)
                        {
                            dest[a] = station[j];
                            a++;
                        }
                    }
                }
                Array.Sort(dest, new Comparison<Train>((a, b) => a.hourOfOut.CompareTo(b.hourOfOut)));
                Console.WriteLine(dest[0].number + " is the train what you needed. It goes on " + dest[0].hourOfOut + ":" + dest[0].minOfOut + ".");
            }
            else Console.WriteLine("There is no train going to this direction.");
            Console.WriteLine("List of all trains for today");
            for(int c = 0; c<station.Length; c++)
            {
                station[c].GetInfo();
            }
            Console.WriteLine("Choose arrival:");
            string arr = Console.ReadLine();
            int e = 0;
            for(int d = 0; d<station.Length; d++)
            {
                if (arr == station[d].departure) e++;
            }
            Train[] arrive = new Train[e];
            int g = 0;
            for(int f = 0; f<station.Length; f++)
            {
                if (arr == station[f].departure)
                {
                    arrive[g] = station[f];
                    g++;
                }
            }
            Array.Sort(arrive, new Comparison<Train>((a, b) => a.hourOfIn.CompareTo(b.hourOfIn)));
            for(int h = 0; h<arrive.Length; h++)
            {
                arrive[h].GetAllInfo();
            }
        }
    }
}
