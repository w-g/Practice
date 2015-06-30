using System;

namespace ConsoleApp
{
    public class CarInfoEventArgs : EventArgs
    {
        public CarInfoEventArgs(string car)
        {
            this.Car = car;
        }

        public string Car { get; private set; }
    }

    public class CarDealer
    {
        public event EventHandler<CarInfoEventArgs> NewCarInfo;

        public void NewCar(string car)
        {
            Console.WriteLine("Car Dealer, new car {0}", car);

            if (NewCarInfo != null)
            {
                NewCarInfo(this, new CarInfoEventArgs(car));
            }
        }
    }

    public class Consumer
    {
        private string name;

        public Consumer(string name)
        {
            this.name = name;
        }

        public void NewCarIsHere(object sender, CarInfoEventArgs eventArgs)
        {
            Console.WriteLine("{0}: car {1} is new", this.name, eventArgs.Car);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var dealer = new CarDealer();

            var lucy = new Consumer("lucy");
            dealer.NewCarInfo += lucy.NewCarIsHere; // 订阅事件

            dealer.NewCar("Mercedes"); // 发布事件

            var lily = new Consumer("lily");
            dealer.NewCarInfo += lily.NewCarIsHere; // 订阅事件

            dealer.NewCar("Ferrari"); // 发布事件

            dealer.NewCarInfo -= lucy.NewCarIsHere; // 取消订阅

            dealer.NewCar("Toyota");

            Console.ReadKey();
        }
    }
}
