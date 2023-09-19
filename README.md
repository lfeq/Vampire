# Vampire - Unity Game with Custom Physics

Vampire is a game created using Unity, featuring custom physics for player and enemy movements, as well as projectile motion. This README file provides an overview of the project and its key components.

## Table of Contents

- [Description](#description)
- [Custom Physics](#custom-physics)
- [Game Architecture](#game-architecture)
- [Installation](#installation)
- [Usage](#usage)

---

## Description

Vampire is a game inspired by Vampire Survivors, incorporating custom physics to create unique gameplay experiences. It utilizes custom physics scripts to handle player movement, enemy movement, and projectile motion. Notable features include the use of movement matrices for transformations and rotations, as well as the implementation of parabolic motion for projectile effects.

---

## Custom Physics

The project includes a set of custom physics scripts under the `Formulas` class, which facilitate various calculations and transformations required for the game's mechanics. Here's a brief overview of some of the custom physics methods:

- `magnitude(Vector3 t_v3)`: Calculates the magnitude of a Vector3.
- `normalize(Vector3 t_v3)`: Normalizes a Vector3.
- `rotate(Vector3 t_previousPosition, float t_addAngle)`: Rotates a Vector3 by a specified angle.
- `quaternion(Vector4 t_q, Vector3 t_pos)`: Applies quaternion rotation to a Vector3.
- `quaternion(Vector3 t_q, float t_angle, Vector3 t_pos, Vector3 t_center)`: Rotates a point around a center using quaternion rotation.
- `move(Vector3 t_pos, Vector3 t_moveVector)`: Moves a Vector3 by a specified translation.
- `distance(Vector3 t_pos1, Vector3 t_pos2)`: Calculates the distance between two Vector3 points.
- `direction(Vector3 t_pos1, Vector3 t_pos2)`: Calculates the direction between two Vector3 points.
- `hooke(float t_distance, float t_k)`: Calculates the force using Hooke's Law.
- `acceleration(float t_force, float t_mass)`: Calculates acceleration based on force and mass.
- `parabolicMovement(float t_time, float t_horizontalInitialVelocity, float t_verticalInitialVelocity, Vector2 t_currentPos)`: Simulates parabolic projectile motion.

These custom physics scripts enhance the gameplay mechanics and contribute to the game's unique experience.

---

## Game Architecture

The game's architecture follows the principles outlined in the video [linked here](https://www.youtube.com/watch?v=raQ3iHhE_Kk&t=0s). It employs Scriptable Objects to create a flexible and maintainable architecture. An example of this can be seen in the `FloatReference` class, which allows for dynamic referencing of float values.

Additionally, the `PlayerHPBarController` script showcases the use of `FloatReference` to update the player's health bar in real-time.

```csharp
using System;
[Serializable]
public class FloatReference
{
    public bool useConstant;
    public FloatVariable variable;
    public float constantValue;

    public float value {
        get { return useConstant ? constantValue : variable.value; }
        set { variable.value = value; }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBarController : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private FloatReference playerHealth;
    [SerializeField] private FloatReference playerMaxHealth;

    public void UpdateHPBar() {
        float fillAmount = playerHealth.value / playerMaxHealth.value;
        healthBar.fillAmount = fillAmount;
    }
}
```
This architecture promotes modularity and makes it easier to manage game variables and references.

## Installation

To play the Vampire game or work on the project, follow these installation steps:

1. Clone the repository: git clone https://github.com/lfeq/Vampire.git
2. Open the project in Unity.
3. Ensure you have the required Unity version installed.
4. Explore and modify the project as needed.

# Usage

Feel free to use this project as a reference for your own game development or to experiment with custom physics in Unity. The provided custom physics scripts and Scriptable Object-based architecture can serve as valuable resources for creating unique and engaging gameplay experiences.
