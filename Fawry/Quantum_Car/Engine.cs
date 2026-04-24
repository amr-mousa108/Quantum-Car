using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum_Car
{
    // Base engine class
    abstract class Engine
    {
        protected int speed = 0;

        public int Speed => speed;

        public void Increase()
        {
            speed += 1;
        }

        public void Decrease()
        {
            if (speed > 0)
                speed -= 1;
        }

        public abstract string Type { get; }
    }
}
