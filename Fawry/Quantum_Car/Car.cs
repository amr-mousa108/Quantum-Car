using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum_Car
{
    class Car
    {
        private Engine engine;
        private bool running = false;

        public Car(Engine eng)
        {
            engine = eng;
        }

        // Replaces the engine (car must be stopped first)
        public void ReplaceEngine(Engine newEngine)
        {
            if (running)
            {
                Console.WriteLine("Stop the car before replacing the engine.");
                return;
            }
            engine = newEngine;
            Console.WriteLine($"Engine replaced with: {engine.Type}");
        }

        public void Start()
        {
            if (running)
            {
                Console.WriteLine("Car is already running.");
                return;
            }
            running = true;
            Console.WriteLine("Car started. Speed: 0 km/h");
        }

        public void Stop()
        {
            if (!running)
            {
                Console.WriteLine("Car is not running.");
                return;
            }

            // Bring speed to 0 before stopping
            while (engine.Speed > 0)
            {
                if (engine is HybridEngine h)
                    h.Decrease();
                else
                    engine.Decrease();
            }

            running = false;
            Console.WriteLine("Car stopped.");
        }

        public void Accelerate()
        {
            if (!running)
            {
                Console.WriteLine("Start the car first.");
                return;
            }

            if (engine.Speed >= 200)
            {
                Console.WriteLine("Already at max speed (200 km/h).");
                return;
            }

            // Each accelerate = +20 km/h => 20 x increase(1)
            int steps = Math.Min(20, 200 - engine.Speed);
            for (int i = 0; i < steps; i++)
            {
                if (engine is HybridEngine h)
                    h.Increase();
                else
                    engine.Increase();
            }

            NotifyEngine();
            Console.WriteLine($"Speed: {engine.Speed} km/h");
        }

        public void Brake()
        {
            if (!running)
            {
                Console.WriteLine("Car is not running.");
                return;
            }

            if (engine.Speed == 0)
            {
                Console.WriteLine("Already stopped.");
                return;
            }

            int steps = Math.Min(20, engine.Speed);
            for (int i = 0; i < steps; i++)
            {
                if (engine is HybridEngine h)
                    h.Decrease();
                else
                    engine.Decrease();
            }

            NotifyEngine();
            Console.WriteLine($"Speed: {engine.Speed} km/h");
        }

        private void NotifyEngine()
        {
            if (engine is HybridEngine hybrid)
                Console.WriteLine($"[Hybrid] Active sub-engine: {hybrid.ActiveEngine}");
            else
                Console.WriteLine($"[{engine.Type}] Engine speed: {engine.Speed} km/h");
        }
    }
}
