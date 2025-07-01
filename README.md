# Emotion Runner
![1](https://github.com/user-attachments/assets/1fe0627a-3456-4b8d-89f7-dfff767d5219)


**Emotion Runner** is a 2D endless runner game developed in Unity. The game combines classic runner mechanics with a unique emotional twist. The player's emotion dynamically changes based on in-game events, affecting abilities like speed and jump power.

---

## 🎮 Game Summary

* **Genre:** 2D Endless Runner / Action Platformer
* **Platform:** PC
* **Engine:** Unity
* **Controls:** Keyboard & DualShock Controller Support

---

## 🧠 Core Concept

The twist in *Emotion Runner* is the emotion-based gameplay system:

* The player starts with a **Normal** emotion.
* **Happy** triggers when the player collects 100 gems (milestone-based).
* **Sad** triggers when the player is damaged by an enemy.
* Each emotion lasts for **10 seconds**, then resets back to Normal.
* Each emotion affects gameplay:

  * 😄 **Happy** = positive background music and mood
  * 😢 **Sad** = slower movement
  * 😠 **Angry** = higher jump force *(optional emotion)*
  * 😱 **Scared** = faster movement *(optional emotion)*

---

## ✅ Features Completed

### 🎮 Core Gameplay

* Endless environment system using prefab chunks
* Parallax background scrolling
* Auto-running player with animations
* Jumping & attacking with animation triggers
* Enemy system with basic AI movement and attack logic

### 📈 Game Mechanics

* Gem collection system with score UI
* Enemies destroyable by player attack
* Player takes damage and has a health bar
* Game over when health = 0 or player falls

### 🧠 Emotion System

* Emotion changes based on actions (not time-based)
* Emotion resets back to Normal after 10s
* Emotion affects player stats (speed, jump)
* Background music changes per emotion

### 🧩 UI System

* Main menu, Pause menu, Game Over screen
* Dashboard: Total gems, kills, deaths
* Clear Progress button using PlayerPrefs
* Emotion icon UI (dynamic update)
* Health bar UI synced with player damage

### 🎮 Controller Support

* Full DualShock (PS4) gamepad support
* Control menus using D-pad / left stick
* Jump, attack, and pause mapped to gamepad buttons

### 🔊 Audio

* Emotion-based background music (Happy, Sad, etc.)
* Sound effects: gem collect, attack, hurt
* AudioManager and SFXManager architecture

### 💾 Persistent Stats

* Uses PlayerPrefs to store:

  * Total Gems
  * Total Enemies Killed
  * Total Deaths
* Dashboard UI pulls and displays all saved stats

---

## 🧱 Data Structures & Algorithms Used

| Concept      | Usage                               |
| ------------ | ----------------------------------- |
| Arrays       | Emotions, prefab pools              |
| Lists        | Chunk prefab list, enemy list       |
| Hashing      | PlayerPrefs key-value storage       |
| Linked List  | Endless prefab chaining logic       |
| Coroutine    | Resetting emotion state after delay |
| Input Events | New Input System for controls/UI    |

---

## 🕹️ Controls

### Keyboard:

* `Space` = Jump
* `D` = Attack
* `Esc` = Pause

### PS4 Controller:

* `X` (Cross) = Jump
* `Square` = Attack
* `Options` = Pause
* Left Stick / D-Pad = Navigate Menus

---

## 🚀 How to Run

1. Open the Unity project
2. Press `Play` to test in editor
3. Connect DualShock controller for gamepad play

---

## 📂 Project Structure

```
EmotionRunner/
├── Scripts/
│   ├── PlayerController.cs
│   ├── EmotionManager.cs
│   ├── GemManager.cs
│   ├── EnemyController.cs
│   ├── AudioManager.cs
│   ├── SFXManager.cs
│   ├── DashBoardUI.cs
│   └── PlayerStats.cs
├── Prefabs/
│   ├── EnvironmentChunks
│   ├── Player
│   └── Enemies
├── UI/
│   ├── MainMenu
│   ├── PauseMenu
│   └── GameOver
└── Audio/
    ├── BGM/
    └── SFX/
```

---

## 👨‍💻 Developer Info

* **Name:** Zaid
* **Role:** Programmer, Designer
* **Tools:** Unity, C#, GitHub

---

## ✅ To-Do / Future Ideas

* Add new emotion types (e.g., Confused, Excited)
* Add emotion-triggered VFX and animations
* Add high score leaderboard
* Export PC build with save support
* Polish dashboard with visual stats icons

---

## 📌 License

This game is a university-level educational project and not intended for commercial release.
