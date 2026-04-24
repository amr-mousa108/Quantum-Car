using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum_Car
{
    class HybridEngine : Engine
    {
        private ElectricEngine electric = new ElectricEngine();
        private GasEngine gas = new GasEngine();

        public override string Type => "Hybrid";

        // Tells the car which sub-engine is active right now
        public string ActiveEngine => speed < 50 ? "Electric" : "Gas";

        public new void Increase()
        {
            if (speed < 50)
                electric.Increase();
            else
                gas.Increase();

            speed += 1;
        }

        public new void Decrease()
        {
            if (speed <= 0) return;

            if (speed < 50)
                electric.Decrease();
            else
                gas.Decrease();

            speed -= 1;
        }
    }

}
