<p align="center">
  <img src="https://img.shields.io/badge/Unity-2022.3-000000?style=flat-square&logo=unity&logoColor=white">
  <img src="https://img.shields.io/badge/Blender-3.5-F5792A?style=flat-square&logo=blender&logoColor=white">
  <img src="https://img.shields.io/badge/C%23-239120?style=flat-square&logo=csharp&logoColor=white">
  <img src="https://img.shields.io/badge/ShaderLab-FF5733?style=flat-square">
  <img src="https://img.shields.io/badge/NVIDIA%20Flex-1.0%20Beta-76B900?style=flat-square&logo=nvidia&logoColor=white">
  <br>
 
</p>

 <h1  align="center">Echoes of Europa</h1>

## 🚩 Overview

Echoes of Europa is an educational and technical showcase developed using Unity and Blender, exploring the unique terrain of Jupiter's moon, Europa. The project demonstrates advanced implementations of physics simulations, 3D modeling, and shader development through interactive environments.

### 🎮 Gameplay Experience

This first-person exploration provides an educational journey through distinct ecosystems on Europa:
Engage in dynamic physics-based interactions.
Explore educational content detailing Europa's geology and potential habitability.
Interact with realistic simulations of fluid dynamics, cloth movement, rigid objects, and soft body deformation.


### 💡 Key Technical Features

- **Advanced 3D Modeling**: Utilizes geometric, hierarchical, mechanical, organic, and physics-based modeling techniques in Blender.
- **Physics Simulations**: Leveraging NVIDIA Flex, including:
- **Water dynamics** in ponds and droplets.
- **Cloth behavior** for realistic flag movements.
- **Rigid and deformable object interactions**, exemplified by rocks and mushrooms.
- **Custom Shader Development**: ShaderLab scripts for realistic planetary gradients and ocean waves.
- **Real-time Animations**: Integrated with Unity's Input System package for responsive and natural avatar movements.
- **Immersive Camera and Lighting**: First-person camera setups with dynamic rotation and adaptive lighting for atmospheric realism.

### 🛠️ Technologies and Tools

- Unity 2022.3: Core engine for simulation, real-time interactions, and rendering.
- Blender 3.5: Modeling and structural layout for all scene components.
- ShaderLab: Custom shader scripts for visual effects and interactions.
- C#: Scripting for physics, interactions, and animation logic.
- NVIDIA Flex: Integration for advanced particle-based physical simulations.

### 📂 Project Structure
```
Echoes_of_Europa/
├── Assets/
│   ├── Animations/
│   ├── Models/
│   ├── Prefabs/
│   ├── NVIDIA/Flex/
│   ├── Scripts/
│   ├── Shaders/
│   └── Textures/
├── ProjectSettings/
├── bin/
```

### 🖼️ Screenshots

| Beach Scene 🌊 | Cave Scene 🕳️ |
|:--------------:|:--------------:|
| ![Beach](screenshots/beach.png) | ![Cave](screenshots/cave.png) |

| Forest Scene 🌳 | Cliff Scene ⛰️ |
|:---------------:|:---------------:|
| ![Forest](screenshots/forest.png) | ![Cliff](screenshots/hike.png) |


### 🎬 Demonstration Video

Watch the complete exploration and technical demo [here](https://drive.google.com/file/d/1Y5p1qhuIvTr1_AzgaMqIDnX1EYO-SuxD/view).

#### 📖 Technical Documentation

The technical documentation delves into every aspect of the project’s development pipeline: it explains how 3D assets were modeled in Blender using geometric, hierarchical, mechanical, organic, and physics-based techniques; details how NVIDIA Flex was integrated into Unity to simulate water behavior, cloth dynamics, rigid-body interactions, and soft-body deformations; outlines the process of creating custom ShaderLab scripts (including the DistantPlanetShader for realistic planetary gradients and the Ocean_waves shader for dynamic water surfaces); describes how animations and user input were implemented via Unity’s Input System, FPSController, and Animator components; and covers UI layering for HUD elements, scene transition logic using canvas-based triggers, and dynamic lighting setups that drive the day–night cycle and first-person flashlight. Each section provides step‑by‑step explanations, code snippets, and asset‑organization strategies to guide users through reproducing or extending the core systems.

### 🚀 Getting Started

Prerequisites:
- Unity 2022.3 or later
- Blender 3.5 or later
- NVIDIA Flex 1.0 Beta

Installation:

1. Clone the repository:
2. git clone `https://github.com/gsalvador209/Echoes_of_Europa.git`
3. Open Unity Hub, load the project, and select the appropriate Unity version.

Explore scenes in the Scenes directory to engage with the simulations and environments.

### 📚 Authors

- Giovanni Salvador Chávez Villanueva
- Daniel Alejandro Cruz Cedillo
- Vanessa Nava Alberto
- José Luis Tapia Estevez

### 🎯 Purpose

Developed as a final project for "Temas Selectos de Ingeniería II" at Universidad Nacional Autónoma de México (UNAM), Facultad de Ingeniería, showcasing complex engineering concepts and interactive simulation techniques.

Explore, learn, and immerse yourself in the fascinating technical and educational journey of Europa!

