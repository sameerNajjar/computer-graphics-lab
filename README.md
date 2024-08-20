# 3D Powder Game

## Overview

The **3D Powder Game** is an immersive simulation game inspired by 2D falling sand and powder games, but with a unique twist: it is designed in a 3D environment. This game leverages a 3D grid system where each cube represents an element, and the grid is dynamically updated each frame to simulate realistic interactions and behaviors of various elements.

## Implementation Details

The game utilizes a 3D grid system, where each cube in the grid represents an element. The grid is updated each frame to simulate the physics and interactions of these elements. Key features of the implementation include:

- **3D Grid Management:** Each cube in the grid represents a particle, with the grid being updated every frame to reflect changes in element state and interactions.
- **Physics Simulation:** The game applies physics rules to simulate realistic behavior of elements, including fluid dynamics for water, oil, and acid, and particle interactions such as burning and melting.
- **Real-time Updates:** Element interactions are processed in real-time, allowing for dynamic changes and interactions within the 3D environment.


## How to Download and Run

1. **Download the Game:**
   - Download `Game.zip` from the repository.
   - Unzip the file.

2. **Run the Game:**
   - Execute `3D-Powder-Game.exe` to start playing.

## Game Features

The game includes twelve distinct elements, each with unique properties and interactions:

- **Sand:**
  - Precipitates in water and oil.
  - Fire and lava cannot burn sand.
  - Acid is the only substance that can destroy sand particles.

- **Water:**
  - Flows over solid particles like sand and stone.
  - Evaporates near lava, fire, and acid, creating cloud particles.
  - Extinguishes fire and lava.

- **Snow:**
  - Melts automatically after 5 seconds.
  - Melts when touching lava, fire, or acid, turning into water.
  - Moves like sand.

- **Lava:**
  - Disappears automatically after 10 seconds.
  - Extinguishes upon contact with water.
  - Burns acid and oil.
  - Moves like water due to its fluid nature.

- **Acid:**
  - Destroys every other particle upon contact.
  - Moves like lava and water due to its fluid characteristics.

- **Stone:**
  - Solid and does not interact with other particles.
  - Only acid can destroy stone.

- **Smoke:**
  - Appears when lava, fire, or acid burn other elements.
  - Moves like a fluid but stays in the sky.
  - Disappears after 10 seconds.

- **Fire:**
  - Unlike lava, fire is not a fluid.
  - Spreads only to burn neighboring particles.
  - Disappears after 10 seconds.

- **Oil:**
  - Flows over water.
  - Can ignite to become fire when touching fire or lava.
  - Fluid in nature.

- **Cloud:**
  - Rains water after 5 seconds.
  - Disappears after 10 seconds.
  - Moves like smoke.
  - Appears when water evaporates.

- **Salt:**
  - Melts in water.
  - Moves like sand and snow.
  - Reappears when evaporated water is gone.

- **Wood:**
  - Solid like stone.
  - Floats on water.
  - Can be burned by fire and lava.

