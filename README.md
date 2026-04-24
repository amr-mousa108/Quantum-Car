# 🚗 Quantum Car — Fawry N² Internship Challenge

A C# implementation of a car factory system that demonstrates key **Object-Oriented Design** principles including **Strategy**, **Factory**, and **Inheritance** patterns.

---

## 📌 Problem Overview

Design a flexible car factory where:
- A car can have one of three engine types: **Gas**, **Electric**, or **Hybrid**
- The engine can be **swapped at runtime** without changing the car's behavior
- The car supports: `Start`, `Stop`, `Accelerate` (+20 km/h), and `Brake` (-20 km/h)
- The **Hybrid engine** automatically switches between Electric (speed < 50) and Gas (speed ≥ 50) — never running both at once

---

## 🏗️ Design

### Class Structure

```
Engine (abstract)
├── GasEngine
├── ElectricEngine
└── HybridEngine        ← contains both internally, activates one at a time

Car                     ← holds an Engine, exposes car operations
CarFactory              ← static factory: creates Car by engine type string
```

### Design Patterns Used

| Pattern | Where | Why |
|---|---|---|
| **Strategy** | `Engine` is swappable inside `Car` | Decouple car behavior from engine implementation |
| **Factory** | `CarFactory.CreateCar(string)` | Centralize object creation logic |
| **Inheritance** | `GasEngine`, `ElectricEngine`, `HybridEngine` extend `Engine` | Share common speed state and operations |

---

## ⚙️ Engine Behavior

| Engine | Behavior |
|---|---|
| Gas | Simple speed increase/decrease |
| Electric | Simple speed increase/decrease |
| Hybrid | Speed < 50 → Electric active · Speed ≥ 50 → Gas active |

> The Hybrid engine is **cost-optimized** — it never runs both sub-engines simultaneously.

---

## 🚦 Car Operations

| Operation | Description |
|---|---|
| `Start()` | Starts the engine at 0 km/h |
| `Stop()` | Brings speed to 0 before shutting down |
| `Accelerate()` | +20 km/h (max 200 km/h) |
| `Brake()` | −20 km/h (min 0 km/h) |
| `ReplaceEngine()` | Swaps the engine (car must be stopped) |

---

## 💻 Sample Output

```
=== Gas Car Test ===
Car created with Gas engine.
Car started. Speed: 0 km/h
[Gas] Engine speed: 20 km/h
[Gas] Engine speed: 40 km/h
[Gas] Engine speed: 20 km/h
Car stopped.

=== Hybrid Car Test ===
Car created with Hybrid engine.
Car started. Speed: 0 km/h
[Hybrid] Active sub-engine: Electric   <- speed: 20
[Hybrid] Active sub-engine: Electric   <- speed: 40
[Hybrid] Active sub-engine: Gas        <- speed: 60
Car stopped.

=== Engine Replacement Test ===
Car created with Gas engine.
...
Engine replaced with: Electric
...
```

---

## 🗂️ Project Structure

```
QuantumCar/
└── QuantumCar.cs      ← All classes + Main entry point
```

---

## ▶️ How to Run

```bash
# Clone the repo
git clone https://github.com/amr-mousa108/quantum-car.git
cd quantum-car

# Run with .NET CLI
dotnet run
```

> Requires **.NET 6+**

---

## 👨‍💻 Author

**Amr Mousa** — [@amr-mousa108](https://github.com/amr-mousa108)

*Submitted as part of the Fawry N² Quantum Internship Program*
