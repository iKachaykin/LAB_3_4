using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication11
{
    abstract class Vehicle : IComparable
    {
        protected double price, max_speed, coordX, coordY;
        protected int year;
        protected string name;
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
        public double Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value > 0)
                {
                    this.price = value;
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
        }
        public abstract string Coordinates { get; }
        public double MaxSpeed
        {
            get
            {
                return this.max_speed;
            }
            set
            {
                if (value > 0)
                {
                    this.max_speed = value;
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
        }
        public int YearOfBirth
        {
            get
            {
                return this.year;
            }
            set
            {
                if (value > 0)
                {
                    this.year = value;
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
        }
        public abstract void CoordinatesDetermination(params double[] coords);
        public int CompareTo(object obj) 
        {
            Vehicle other = (Vehicle)obj;
            if (this.price > other.price)
            {
                return 1;
            }
            else if (this.price < other.price)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        public override string ToString()
        {
            return String.Concat("Название: ", Convert.ToString(this.name), ". Дата выпуска: ", Convert.ToString(this.year), " .\nМаксимальная скорость: ", Convert.ToString(this.max_speed), "км/ч. Цена: ", Convert.ToString(this.price), "$.\nТекущие координаты: ", this.Coordinates);
        }
    }
    class Car : Vehicle
    {
        private double[] coordinates = new double[2];
        public Car(string name, double price, double max_speed, int year, double coordX, double coordY)
        {
            this.name = name;
            this.price = price;
            this.year = year;
            this.max_speed = max_speed;
            this.coordX = coordX;
            this.coordY = coordY;
        }
        override public string Coordinates
        {
            get
            {
                return String.Concat("(", Convert.ToString(this.coordX), " , ", Convert.ToString(this.coordY), ")");
            }
        }
        public override void CoordinatesDetermination(params double[] coords)
        {
            if (coords.Length > 2)
            {
                throw new InvalidOperationException();
            }
            else
            {
                this.coordX = coords[0];
                this.coordY = coords[1];
            }
        }
        public override string ToString()
        {
            return String.Concat("Тип транспортного средства: Автомобиль\n", base.ToString());
        }

    }
    class Plane : Vehicle
    {
        private double height;
        int number_of_passengers;
        public Plane(string name, double price, double max_speed, int year, int number_of_passengers, double coordX, double coordY, double height)
        {
            this.name = name;
            this.price = price;
            this.year = year;
            this.max_speed = max_speed;
            this.number_of_passengers = number_of_passengers;
            this.coordX = coordX;
            this.coordY = coordY;
            this.height = height;
        }
        public double Height
        {
            get {
                return this.height;
            }
        }
        public int Capacity
        {
            get
            {
                return this.number_of_passengers;
            }
            set
            {
                if (value > 0)
                {
                    this.number_of_passengers = value;
                }
                else 
                {
                    throw new InvalidOperationException();
                }
            }
        }
        override public string Coordinates
        {
            get
            {
                return String.Concat("(", Convert.ToString(this.coordX), " , " + Convert.ToString(this.coordX), " , " , Convert.ToString(this.height), ")");
            }
        }

        public override void CoordinatesDetermination(params double[] coords)
        {
            if (coords.Length > 3)
            {
                throw new InvalidOperationException();
            }
            else
            {
                this.coordX = coords[0];
                this.coordY = coords[1];
                this.height = coords[2];
            }
        }
        public override string ToString()
        {
            return String.Concat("Тип транспортного средства: Самолёт\n", base.ToString(), "\nВместимость: ", this.Capacity);
        }
    }
    class Ship : Vehicle
    {
        private string port;
        private int number_of_passengers;
        public Ship(string name, double price, double max_speed, int year, int number_of_passengers, double coordX, double coordY, string port)
        {
            this.name = name;
            this.price = price;
            this.year = year;
            this.max_speed = max_speed;
            this.number_of_passengers = number_of_passengers;
            this.coordX = coordX;
            this.coordY = coordY;
            this.port = port;
        }
        public int Capacity
        {
            get
            {
                return this.number_of_passengers;
            }
            set
            {
                if (value > 0)
                {
                    this.number_of_passengers = value;
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
        }
        public string Port
        {
            get {
                return this.port;
            }
            set {
                if (!String.IsNullOrEmpty(value))
                {
                    this.port = value;
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
        }
        public override string ToString()
        {
            return String.Concat("Тип транспортного средства: Корабль\n", base.ToString(), "\nВместимость: ", this.Capacity, ". Портовая приписка: ", this.Port);
        }
        override public string Coordinates
        {
            get
            {
                return String.Concat("(" , Convert.ToString(this.coordX), " , ", Convert.ToString(this.coordY), ")");
            }
        }
        public override void CoordinatesDetermination(params double[] coords)
        {
            if (coords.Length > 2)
            {
                throw new InvalidOperationException();
            }
            else
            {
                this.coordX = coords[0];
                this.coordY = coords[1];
            }
        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            Ship tit = new Ship("Титаник", 10000000, 80, 1950, 300, 894, 0, "Южный порт Лондона");
            Ship ar = new Ship("Аризона", 1000000, 90, 1930, 500, 89.2, 123, "Северный порт Калифорнийского побережья");
            Car ben = new Car("Bentley Continental GT", 800000, 250, 2014, 23, 45);
            Car merc = new Car("Mercedes S-Klasse Coupe", 750000, 300, 2016, 45, 21);
            Plane boe = new Plane("Boeing 747", 200000000, 900, 2010, 500, 98, 24, 9);
            Plane ab = new Plane("Airbus A380", 389000000, 1000, 2005, 890, 87, 2, 8);
            ArrayList vehicleList = new ArrayList();
            vehicleList.Add(tit);
            vehicleList.Add(ar);
            vehicleList.Add(ben);
            vehicleList.Add(merc);
            vehicleList.Add(boe);
            vehicleList.Add(ab);
            foreach (object veh in vehicleList)
            {
                Console.WriteLine(veh);
            }
            vehicleList.Sort();
            Console.WriteLine("\n\nРезультаты после сортировки по цене:\n\n");
            foreach (object veh in vehicleList)
            {
                Console.WriteLine(veh);
            }

            Console.ReadKey();
        }
    }
}
