# ?? ProyectoVideojuegosP1

Proyecto de videojuego 3D desarrollado en **Unity 6** (6000.4.1f1) con estética retro **PSX** (PlayStation 1).

## ?? Descripción

Juego de acción en 3D con vista top-down que incluye combate cuerpo a cuerpo, sistema de auto-apuntado, recolección de ítems y enfrentamiento contra jefes. El proyecto utiliza shaders estilo PSX para lograr una estética retro nostálgica.

## ??? Características

- **Movimiento 3D** con físicas basadas en Rigidbody
- **Sistema de combate** con ataques y auto-aim hacia enemigos
- **Sistema de salud** para el jugador y enemigos
- **Recolección de ítems** (pickups)
- **Zona de victoria** (WinZone)
- **Cámara dinámica** con límites de seguimiento
- **Game Manager** para gestión del estado del juego
- **Estética retro PSX** con shaders personalizados (PSXShaderKit)
- **Skyboxes** incluidos (AllSkyFree)

## ??? Estructura del Proyecto

`
Assets/
+-- Animations/      # Animaciones del jugador y enemigos
+-- AllSkyFree/      # Skyboxes gratuitos
+-- Materials/       # Materiales del juego
+-- Models/          # Modelos 3D
+-- Prefabs/         # Prefabs reutilizables
+-- PSXShaderKit/    # Shaders estilo PlayStation 1
+-- Scenes/          # Escenas del juego
+-- Scripts/         # Lógica del juego (C#)
¦   +-- AutoAimSystem.cs
¦   +-- CameraFollowBounds.cs
¦   +-- GameManager.cs
¦   +-- HealthSystem.cs
¦   +-- ItemPickup.cs
¦   +-- PlayerCombat.cs
¦   +-- PlayerMovement3D.cs
¦   +-- WinZone.cs
+-- SpriteSheets/    # Sprites (UI, enemigos, jugador, boss, FX)
+-- Textures/        # Texturas adicionales
+-- TextMesh Pro/    # Fuentes y shaders de texto
`

## ??? Requisitos

- **Unity 6** (6000.4.1f1 o superior)
- **Plataforma:** Windows / macOS / Linux

## ?? Cómo Ejecutar

1. Clona el repositorio:
   `ash
   git clone https://github.com/TheRealJeankisK/ProyectoVideojuegosP1.git
   `
2. Abre el proyecto con **Unity Hub** seleccionando la carpeta del proyecto.
3. Abre la escena principal en `Assets/Scenes/SampleScene.unity`.
4. Presiona **Play** ?? en el editor de Unity.

## ?? Licencia

Proyecto académico — Progreso 1.
