# FPS Sharp Shooter : Survive!

## 🎥 Gameplay Video
[Watch Gameplay Video](https://youtu.be/KgOUQAODu4I)

---

## 🔫 Survive!
A first-person shooter prototype built in Unity, focused on modular weapon systems, AI behavior using NavMesh, and structured object-oriented programming design.
This project emphasizes scalable weapon architecture, enemy AI interaction, and gameplay systems such as reloading, magazine management, and ranged combat behavior.

<img width="427" height="240" alt="image" src="https://github.com/user-attachments/assets/89c39788-5a18-4477-a490-6af0299d5146" />

---

## ⚙️ Technical Highlights
- Engine: Unity 6 (6000.0.49f1)
- Programming Language: C#
- Unity NavMesh for AI pathfinding
- Object-Oriented weapon system architecture
- Modular shooting & reload system
- Weapon stats and magazine data stored using ScriptableObjects for easy balancing and reuse
- Enemy spawn system with multiple spawn points

---

## 🎮 Core Features

### 🔫 Weapon System
- Multiple weapon types (pistol, machine gun, rifle)

---

  - Pistol
    <br><img width="427" height="240" alt="image" src="https://github.com/user-attachments/assets/2c7b01e4-757f-4777-948f-67532b35d846" />
    <br><img width="427" height="240" alt="image" src="https://github.com/user-attachments/assets/3742094d-7f4a-46a1-8473-1c24eabbe03e" />

---

  - Machine Gun
    <br><img width="427" height="240" alt="image" src="https://github.com/user-attachments/assets/441a6680-4d38-4fef-8901-79c8b666ec25" />
    <br><img width="427" height="240" alt="image" src="https://github.com/user-attachments/assets/9ebd3e64-a7c2-41f4-b42c-dfd7ffd9cc70" />

---
    
  - Sniper Rifle
    <br><img width="427" height="240" alt="image" src="https://github.com/user-attachments/assets/f71626e1-7a21-40f2-9ad3-4043f5b6e766" />
    <br><img width="427" height="240" alt="image" src="https://github.com/user-attachments/assets/5f5cb192-22ba-4941-8792-880e89fd3cfc" />

---

- Magazine-based ammo system
- Base Weapon class with inherited weapon types (Pistol, Rifle, Machine Gun)
- Polymorphic shooting behavior handled through overridden methods

#### 🔗 Weapons share a common structure for handling:
- Fire rate
- Weapon type
- Damage dealing
- Ammo count tracking

---

### 🤖 Enemy AI System

- Enemies spawn from multiple locations
  <br><img width="427" height="240" alt="image" src="https://github.com/user-attachments/assets/41d2a51f-2deb-4437-9139-9b9177631bd8" />

- NavMesh-based pathfinding to chase the player
  <br><img width="427" height="240" alt="image" src="https://github.com/user-attachments/assets/eff08f9a-847d-48ae-9bf8-092710844b31" />

- Cannon-type enemy:
  - Detects player within range
  - Shoots at the player when in attack range
  
  <br><img width="427" height="240" alt="image" src="https://github.com/user-attachments/assets/bedb0263-d0d9-4626-8729-582487fce191" />
  <br><img width="427" height="240" alt="image" src="https://github.com/user-attachments/assets/3885fa42-011c-4a11-bf36-55de8d385bd1" />
 
---

## 🧠 Gameplay Focus
- Combat flow and weapon feel
- Ammo management pressure
- Clean system architecture for scalability

---

## 📌 Design Goals
- Build reusable weapon components
- Practice OOP structure for gameplay systems
- Dynamic camera FOV adjustment when switching between normal aim and sniper scope
- Create a clean, extendable combat prototype

<img width="427" height="240" alt="image" src="https://github.com/user-attachments/assets/23922841-8c48-4392-8020-7665a5990774" />

---

This project focuses on system architecture, AI interaction, and scalable weapon design within a low-poly FPS environment.
