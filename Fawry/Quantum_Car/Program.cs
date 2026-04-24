namespace Quantum_Car
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("=== Gas Car Test ===");
            Car gasCar = CarFactory.CreateCar("gas");
            gasCar.Start();
            gasCar.Accelerate();
            gasCar.Accelerate();
            gasCar.Brake();
            gasCar.Stop();

            Console.WriteLine("\n=== Electric Car Test ===");
            Car electricCar = CarFactory.CreateCar("electric");
            electricCar.Start();
            electricCar.Accelerate();
            electricCar.Brake();
            electricCar.Stop();

            Console.WriteLine("\n=== Hybrid Car Test ===");
            Car hybridCar = CarFactory.CreateCar("hybrid");
            hybridCar.Start();
            // Go under 50 => Electric should be active
            hybridCar.Accelerate();
            hybridCar.Accelerate();
            hybridCar.Accelerate();
            // Now above 50 => Gas should kick in
            hybridCar.Brake();
            hybridCar.Stop();

            Console.WriteLine("\n=== Engine Replacement Test ===");
            Car myCar = CarFactory.CreateCar("gas");
            myCar.Start();
            myCar.Accelerate();
            myCar.Stop();
            myCar.ReplaceEngine(new ElectricEngine());
            myCar.Start();
            myCar.Accelerate();
            myCar.Stop();
        }
    }
}
