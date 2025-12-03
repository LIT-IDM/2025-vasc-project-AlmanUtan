# 8bit Christmas

Mobile AR experience that spawns a Christmas tree on a tracked marker with a toggle button to switch between lit/unlit versions.

## Project Info

- **Unity Version:** 2022.3.1f1
- **Platform:** iOS/Android
- **AR Framework:** AR Foundation + AR Tracked Image Manager

## Requirements

- Unity 2022.3.1f1
- AR Foundation, ARCore XR Plugin (Android), ARKit XR Plugin (iOS)
- ARCore/ARKit compatible device
- Printed marker from Reference Image Library

## Installation

1. Open project in Unity Hub with version 2022.3.1f1
2. Verify AR packages installed (Window → Package Manager)
3. Open main AR scene
4. Build to iOS/Android via File → Build Settings

## How to Use

1. Launch app and grant camera permission
2. Point camera at printed marker
3. AR Christmas tree spawns on marker
4. Tap UI button to toggle between Tree_NoLights and Tree_WithLights

## Key Components

- **TreeSwitchRoot prefab:** Contains both tree variants, spawned by AR Tracked Image Manager
- **TreeModelSwitcher.cs:** Singleton script that toggles between tree models
- **UIController.cs:** Handles button press to trigger toggle
