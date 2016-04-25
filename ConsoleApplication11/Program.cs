using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication11
{
    abstract class Vehicle : IComparable
    {
        protected double[] coordinates;
        protected double price, max_speed;
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
        public abstract int CompareTo(object obj);
        public override string ToString()
        {
            return String.Concat("Название: ", Convert.ToString(this.name), ". Дата выпуска: ", Convert.ToString(this.year), " .\nМаксимальная скорость: ", Convert.ToString(this.max_speed), ". Цена: ", Convert.ToString(this.price), " .\nТекущие координаты: ", this.Coordinates);
        }
    }
    class Car : Vehicle
    {

        public Car(string name, double price, double max_speed, int year, double coordX, double coordY)
        {
            this.name = name;
            this.price = price;
            this.year = year;
            this.max_speed = max_speed;
            this.coordinates = new double[2];
            this.coordinates[0] = coordX;
            this.coordinates[1] = coordY;
        }
        override public string Coordinates
        {
            get
            {
                return "(" + Convert.ToString(this.coordinates[0]) + " , " + Convert.ToString(this.Coordinates[1]) + ")";
            }
        }
        override public int CompareTo(object obj)
        {
            Car other = (Car)obj;
            if (this.max_speed > other.max_speed)
            {
                return 1;
            }
            else if (this.max_speed < other.max_speed)
            {
                return -1;
            }
            else 
            {
                return 0;
            }
        }
        public override void CoordinatesDetermination(params double[] coords)
        {
            int i = 0;
            if (coords.Length > 2)
            {
                throw new InvalidOperationException();
            }
            else
            {
                foreach (double coordinate in coords)
                {
                    this.coordinates[i] = coordinate;
                    i++;
                }
            }
        }
        public override string ToString()
        {
            return String.Concat("Тип транспортного средства: Автомобиль\n", base.ToString());
        }

    }
    class Plane : Vehicle
    {
        int number_of_passengers;
        public Plane(string name, double price, double max_speed, int year, int number_of_passengers, double coordX, double coordY, double height)
        {
            this.name = name;
            this.price = price;
            this.year = year;
            this.max_speed = max_speed;
            this.number_of_passengers = number_of_passengers;
            this.coordinates = new double[3];
            this.coordinates[0] = coordX;
            this.coordinates[1] = coordY;
            this.coordinates[2] = height;
        }
        public double Height
        {
            get {
                return this.coordinates[2];
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
                return "(" + Convert.ToString(this.coordinates[0]) + " , " + Convert.ToString(this.Coordinates[1]) + " , " + Convert.ToString(this.coordinates[2]) + ")";
            }
        }
        override public int CompareTo(object obj)
        {
            Plane other = (Plane)obj;
            if (this.Height > other.Height)
            {
                return 1;
            }
            else if (this.Height < other.Height)
            {
                return -1;
            }
            else 
            {
                return 0;
            }
        }
        public override void CoordinatesDetermination(params double[] coords)
        {
            int i = 0;
            if (coords.Length > 3)
            {
                throw new InvalidOperationException();
            }
            else
            {
                foreach (double coordinate in coords)
                {
                    this.coordinates[i] = coordinate;
                    i++;
                }
            }
        }
        public override string ToString()
        {
            return String.Concat("Тип транспортного средства: Самолёт\n", base.ToString(), "\nВместимость: ", this.Capacity);
        }
    }
    class Ship : Vehicle
    {
        string port;
        int number_of_passengers;
        public Ship(string name, double price, double max_speed, int year, int number_of_passengers, double coordX, double coordY, string port)
        {
            this.name = name;
            this.price = price;
            this.year = year;
            this.max_speed = max_speed;
            this.number_of_passengers = number_of_passengers;
            this.coordinates = new double[3];
            this.coordinates[0] = coordX;
            this.coordinates[1] = coordY;
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
                return "(" + Convert.ToString(this.coordinates[0]) + " , " + Convert.ToString(this.Coordinates[1]) + ")";
            }
        }
        public override void CoordinatesDetermination(params double[] coords)
        {
            int i = 0;
            if (coords.Length > 2)
            {
                throw new InvalidOperationException();
            }
            else
            {
                foreach (double coordinate in coords)
                {
                    this.coordinates[i] = coordinate;
                    i++;
                }
            }
        }
        override public int CompareTo(object obj)
        {
            Ship other = (Ship) obj;
            if (Math.Sqrt(this.coordinates[0] * this.coordinates[0] + this.coordinates[1] * this.coordinates[1]) > Math.Sqrt(other.coordinates[0] * other.coordinates[0] + other.coordinates[1] * other.coordinates[1]))
            {
                return 1;
            }
            else if (Math.Sqrt(this.coordinates[0] * this.coordinates[0] + this.coordinates[1] * this.coordinates[1]) < Math.Sqrt(other.coordinates[0] * other.coordinates[0] + other.coordinates[1] * other.coordinates[1]))
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
