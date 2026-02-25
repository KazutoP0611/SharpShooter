# Low Poly FPS Shooter

#### 🔫 Low Poly FPS Prototype
A first-person shooter prototype built in Unity, focused on modular weapon systems, AI behavior using NavMesh, and structured object-oriented programming design.

This project emphasizes scalable weapon architecture, enemy AI interaction, and gameplay systems such as reloading, magazine management, and ranged combat behavior.

<img src="your-screenshot-link-here" width="854" />


---

#### ⚙️ Technical Highlights
- Engine: Unity 6 (6000.0.49f1)
- Programming Language: C#
- Unity NavMesh for AI pathfinding
- Object-Oriented weapon system architecture
- Modular shooting & reload system
- Magazine and ammo data managed through Scritable Object
- Enemy spawn system with multiple spawn points

---

#### 🎥 Gameplay Video
[Watch Gameplay Video](your-video-link-here)

---

#### 🎮 Core Features

### 🔫 Weapon System
- Multiple weapon types (pistol, machine gun, rifle)
  - <img width="854" height="480" alt="image" src="https://github.com/user-attachments/assets/2c7b01e4-757f-4777-948f-67532b35d846" />
  - 

- Shared base weapon class using OOP principles
- Magazine-based ammo system

Weapons share a common structure for handling:
- Fire rate
- Weapon type
- Damage dealing
- Ammo count tracking

---

### 🤖 Enemy AI System
- Enemies spawn from multiple locations
- NavMesh-based pathfinding to chase the player
- Cannon-type enemy:
  - Detects player within range
  - Shoots at the player when in attack range

---

### 🧠 Gameplay Focus
- Combat flow and weapon feel
- Ammo management pressure
- Clean system architecture for scalability

---

#### 📌 Design Goals
- Build a reusable weapon components
- Practice OOP structure for gameplay systems
- Camera management, change camera's fov when using sniper's normal aim & sniping aim
- Create a clean, extendable combat prototype

---

This project focuses on system architecture, AI interaction, and scalable weapon design within a low-poly FPS environment.
