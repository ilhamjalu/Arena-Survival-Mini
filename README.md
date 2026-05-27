# Arena Survival Mini

> **Disclaimer**  
> This project uses third-party assets from the Unity Asset Store for learning and portfolio purposes.  
> All asset credits belong to their respective creators.  
> Asset links are provided at the bottom of this README.

A small top-down arena survival game prototype made with Unity.

This project was created to practice:
- MVC/MVP-inspired architecture
- POCO-based gameplay systems
- Event-driven communication
- Object pooling
- Separation of gameplay and presentation logic
- Reusable and scalable Unity code structure

---

# Features

## Gameplay
- Player movement
- Enemy chase AI
- Shooting system
- Enemy spawning
- Health & damage system
- Win/Lose condition
- Score system

---

# Architecture Highlights

## POCO Gameplay Systems
Gameplay logic is separated from Unity-specific code.

Examples:
- `Health`
- `MovementModel`
- `Score`

These classes:
- do not inherit MonoBehaviour
- contain pure gameplay logic
- are reusable and easier to test

---

## MVC/MVP-inspired Structure

### Controller
Handles:
- input
- Unity lifecycle
- orchestration between systems

Examples:
- `PlayerController`
- `EnemyController`

---

### View
Handles:
- animation
- sprite direction
- weapon visuals
- VFX
- UI

Examples:
- `PlayerView`
- `WeaponView`
- `HealthView`

---

### Model
Handles:
- gameplay data
- gameplay rules

Examples:
- `Health`
- `Score`

---

# Event-Driven Architecture

Global game communication uses events to reduce coupling.

Examples:
- `OnEnemyKilled`
- `OnPlayerDead`
- `OnScoreChanged`

This allows systems to communicate without directly depending on each other.

---

# Object Pooling

Enemies are spawned using object pooling to reduce:
- Instantiate/Destroy overhead
- Garbage Collection spikes

Components:
- `EnemyPool`
- `EnemySpawner`

---

# Weapon System

The weapon visual system is direction-based and data-driven.

Features:
- different sprites per direction
- muzzle/fire point repositioning
- sprite flipping for left/right direction

Main components:
- `WeaponView`
- `WeaponDirection`

---

# Tech Stack

- Unity
- C#
- Unity Animator
- Object Pooling
- Event System

---

# Goals of This Project

This project focuses more on:
- code quality
- architecture
- maintainability
- scalability

rather than polished visual presentation.

It is intended as a programming-focused portfolio project.

---

# Folder Structure

```text
Scripts
├── Controllers
├── Views
├── Models
├── Systems
├── Events
└── Pooling
```

---


# Link To The Assets

- [Top-Down Zombie Pack] (https://assetstore.unity.com/packages/2d/characters/top-down-zombie-pack-329361)
- [2D Character - Astronaut] (https://assetstore.unity.com/packages/2d/characters/2d-character-astronaut-182650)
- [Farm Game UI - Starter 2D] (https://assetstore.unity.com/packages/2d/gui/farm-game-ui-starter-2d-318607)
