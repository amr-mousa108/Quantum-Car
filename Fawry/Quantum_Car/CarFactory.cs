using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum_Car
{

    // Factory responsible for creating cars
    static class CarFactory
    {
        public static Car CreateCar(string engineType)
        {
            Engine eng = engineType.ToLower() switch
            {
                "gas" => new GasEngine(),
                "electric" => new ElectricEngine(),
                "hybrid" => new HybridEngine(),
                _ => throw new ArgumentException("Unknown engine type")
            };

            Console.WriteLine($"Car created with {eng.Type} engine.");
            return new Car(eng);
        }
    }
}
