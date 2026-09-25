# ReGenesis: Beginner Unity Implementation Guide

This guide starts from the current ReGenesis Unity project after `firsttry.unity` was deleted. Follow the sections in order. Do not move to the next section until the **Completion check** at the end of the current section passes.

Project path:

`C:\Semester 4\Game Development KMIPN 2026\ReGenesis`

Unity version:

`6000.3.19f1`

## Before every work session

1. Open Unity Hub.
2. Open the ReGenesis project with Unity `6000.3.19f1`.
3. Wait until the progress indicator finishes importing and compiling.
4. Open **Window > General > Console**.
5. If the Console contains red errors, solve them before editing a scene.
6. Save work with **File > Save** or `Ctrl+S` after every meaningful change.
7. At the end of a working feature, exit Play Mode before saving or committing. Changes made while the Play button is blue usually disappear when Play Mode stops.

## The target for the first prototype

The first prototype is complete when the player can:

1. Start `Prototype_Stage01`.
2. Select a Solar Turret.
3. Click one of four placement nodes to build it.
4. Start a wave.
5. Watch Malware Drones follow a path.
6. Watch the Solar Turret attack enemies in range.
7. Win when every enemy is defeated.
8. Lose when the Energy Core reaches zero health.

Use placeholder colors, cubes, and simple UI whenever needed. The goal is to prove the gameplay loop before polishing the visuals.

---

## 1. Repair the placement scripts and clear the Console

### Purpose

Unity must compile all scripts before gameplay components can be attached and tested. The current `BuildManager.cs` references members that do not exist inside that class.

### Files involved

- `Assets/Scripts/Gameplay/BuildSystem/BuildManager.cs`
- `Assets/Scripts/Gameplay/BuildSystem/PlacementNode.cs`
- `Assets/Scripts/Gameplay/BuildSystem/BuildNode.cs`

### Exact actions

1. Open **Window > General > Console**.
2. Click **Clear**.
3. Allow Unity to compile again.
4. Double-click the first red error to open the offending script in the configured code editor.
5. Keep `BuildManager` responsible only for remembering which tower prefab the player selected.
6. Keep `PlacementNode` responsible for checking occupancy and placing the selected tower.
7. Remove the empty `BuildNode` component from objects and delete `BuildNode.cs` after confirming nothing uses it.
8. Save the scripts and return to Unity.
9. Wait for the spinning compile indicator to stop.
10. Repeat until the Console has no red errors.

### Required behavior

- `BuildManager` has one active instance in the scene.
- A UI button can call `BuildManager.SelectTower(towerPrefab)`.
- A placement node reacts to a click.
- The node asks `BuildManager` for the selected tower.
- The node refuses placement when occupied or when no tower is selected.
- A successful placement instantiates the prefab at a dedicated build point.

### Completion check

- The Console contains **zero red errors**.
- Unity lets you attach `BuildManager` and `PlacementNode` in the Inspector.
- Entering and leaving Play Mode does not produce an exception.

---

## 2. Create the project folders and `Prototype_Stage01`

### Create the folders

In the Project window, right-click `Assets`, choose **Create > Folder**, and create this structure:

```text
Assets/
  Art/
  Audio/
  Data/
    Enemies/
    Towers/
    Waves/
  Materials/
  Models/
  Prefabs/
    Enemies/
    Environment/
    Gameplay/
    Towers/
    UI/
  Scenes/
  Scripts/
    Core/
    Enemies/
    Gameplay/
    Towers/
    UI/
  Settings/
  UI/
```

Do not move imported models merely to match this list if moving them risks breaking references. The existing `Assets/Models` organization is acceptable.

### Create the scene

1. Select `Assets/Scenes` in the Project window.
2. Right-click empty space and choose **Create > Scene**.
3. Name it exactly `Prototype_Stage01`.
4. Double-click the new scene.
5. Press `Ctrl+S`.
6. Confirm that the Hierarchy contains a `Main Camera` and a `Directional Light`. Create them from **GameObject** if the chosen template did not provide them.

Unity also supports **File > New Scene**, followed by **File > Save As**, but creating the scene directly inside `Assets/Scenes` prevents it from being saved in the wrong folder.

### Add the scene to the build profile

1. Keep `Prototype_Stage01` open.
2. Choose **File > Build Profiles**.
3. Select the intended desktop platform, normally Windows.
4. Open its **Scene List**.
5. Click **Add Open Scenes**.
6. Confirm that `Prototype_Stage01` appears and its checkbox is enabled.
7. Make it the first scene in the list.

### Completion check

- `Assets/Scenes/Prototype_Stage01.unity` exists.
- Double-clicking it opens the scene.
- It is enabled as scene 0 in the active build profile.

---

## 3. Make the gray-box Stage 01 environment

### Purpose

Build a readable test arena before decorating it. Use the existing road kit, placement node model, Energy Core, and simple primitive geometry.

### Create clean Hierarchy groups

Right-click the Hierarchy and choose **Create Empty**. Create:

```text
Prototype_Stage01
  _Systems
  Environment
  EnemyPath
  PlacementNodes
  Gameplay
  UI
```

Reset each group’s Transform from the Inspector component menu so Position and Rotation are zero and Scale is one.

### Ground

1. Right-click `Environment` in the Hierarchy.
2. Choose **3D Object > Plane**.
3. Rename it `Ground`.
4. Set Position to `(0, 0, 0)`.
5. Start with Scale `(4, 1, 4)`.
6. Create a temporary dark-gray material in `Assets/Materials` and assign it to the Plane.

### Road and path layout

1. Drag road FBX pieces from `Assets/Models/Environment/RoadKit` into `Environment`.
2. Arrange a simple path from the enemy spawn to the Energy Core.
3. Keep the first version mostly straight with one or two turns.
4. Ensure adjoining road pieces meet cleanly without gaps.
5. Do not add decorative buildings until the path is easy to read from the camera.

### Energy Core

1. Drag the Energy Core model from `Assets/Models/Environment/Objectives/EnergyCore` into `Gameplay`.
2. Rename its root `EnergyCore`.
3. Place it at the end of the road.
4. Face its most readable side toward the camera.

### Camera

1. Select `Main Camera`.
2. Change Projection to **Orthographic** for a stable tower-defense view.
3. Start with Position `(12, 16, -12)`.
4. Start with Rotation `(45, -45, 0)`.
5. Adjust Orthographic Size until the path, core, and all four nodes fit on screen.
6. Set the Camera background to a dark desaturated blue or gray.

### Light

1. Select `Directional Light`.
2. Start with Rotation `(50, -30, 0)`.
3. Use a slightly warm color and moderate intensity.
4. Confirm that model silhouettes remain readable.

### Completion check

- The Game view shows the entire combat route.
- The route direction is obvious without explanatory text.
- The Energy Core is clearly visible at the destination.
- No major model is clipped by the camera.

---

## 4. Create the enemy waypoint path

### Create waypoints

1. Select the `EnemyPath` group.
2. Right-click it and choose **Create Empty**.
3. Rename the object `Waypoints`.
4. Under `Waypoints`, create empty children named `WP_00`, `WP_01`, `WP_02`, and so on.
5. Place `WP_00` just before the beginning of the road.
6. Place a waypoint at every turn.
7. Place the last waypoint directly beside the Energy Core.
8. Keep every waypoint close to the road surface and centered on the path.

### Create spawn point

1. Under `EnemyPath`, create another empty object named `EnemySpawnPoint`.
2. Put it at the same position as `WP_00`.
3. Rotate its blue Z axis so it faces the first travel direction.

### Visual checking trick

Select all waypoint objects in the Hierarchy. Their transform gizmos will reveal the path order in the Scene view. Later, an editor gizmo script can draw connecting lines.

### Completion check

- Waypoint numbers follow the travel order without gaps.
- Every segment stays on the road.
- The final waypoint touches the Energy Core destination.

---

## 5. Create the four placement nodes

### Place the models

1. Drag four copies of the placement node model into `PlacementNodes`.
2. Name them `PlacementNode_01` through `PlacementNode_04`.
3. Put them beside the road, never directly on the enemy path.
4. Leave enough space around each node for the Solar Turret footprint.
5. Keep all four visible from the camera.

### Prepare each node for clicks

For each node:

1. Select the node root.
2. Click **Add Component** in the Inspector.
3. Add a `Box Collider` or another collider that fits its top platform.
4. Enable the collider; do not mark it as Trigger for the initial prototype.
5. Add the `PlacementNode` script.
6. Create an empty child named `BuildPoint`.
7. Center `BuildPoint` on the platform where the tower should stand.
8. Assign `BuildPoint` to the placement script after that field exists.
9. Assign the visible node renderer to the renderer field.

### Completion check

- Clicking the node in the Scene view selects its root or a clearly identifiable child.
- Each root has a collider and `PlacementNode`.
- Each node has one centered `BuildPoint`.
- A tower model placed temporarily at the build point does not intersect the road.

---

## 6. Create the essential prefabs

Create these prefab assets first:

```text
Assets/Prefabs/Towers/PF_Tower_Solar_L1.prefab
Assets/Prefabs/Enemies/PF_Enemy_MalwareDrone.prefab
Assets/Prefabs/Gameplay/PF_EnergyCore.prefab
Assets/Prefabs/Gameplay/PF_PlacementNode.prefab
```

### General prefab procedure

For each object:

1. Put the model into the scene.
2. Create a new empty root with a meaningful name.
3. Reset the root Transform.
4. Drag the model under the root.
5. Adjust the model child so its base rests at local Y `0` and its center is near local X/Z `0`.
6. Put scripts and colliders on the root unless a component specifically belongs to a moving child.
7. Drag the configured root from the Hierarchy into the correct `Assets/Prefabs` folder.
8. The new asset should appear blue in the Project window, and the scene instance should show a prefab connection.
9. Delete temporary duplicates from the scene.

### Solar Turret hierarchy

Use a hierarchy similar to:

```text
PF_Tower_Solar_L1
  Model
    Base
    RotatingHead
      Barrel
      MuzzlePoint
  RangeOrigin
```

- `RotatingHead` is the Transform that turns toward an enemy.
- `MuzzlePoint` is an empty Transform at the barrel tip.
- `RangeOrigin` is an empty Transform near the center of the turret.

### Malware Drone hierarchy

```text
PF_Enemy_MalwareDrone
  Model
  HealthBarAnchor
  WasteDropPoint
```

Add a collider around the visible model. Add a Rigidbody only if the movement design requires physics; waypoint movement can work without one.

### Completion check

- All four prefab assets exist in the intended folders.
- Dragging each prefab into an empty scene produces the expected model and components.
- Model scale is consistent: the enemy fits on the road and the tower fits on a node.

---

## 7. Make tower selection and click-to-place work

### Scene system object

1. Under `_Systems`, create an empty object named `BuildManager`.
2. Add the repaired `BuildManager` component.
3. Confirm there is only one `BuildManager` in the scene.

### Temporary build UI

1. Under `UI`, create **UI > Canvas**.
2. Rename it `HUDCanvas`.
3. Set Canvas Scaler to **Scale With Screen Size**.
4. Use reference resolution `1920 x 1080`.
5. Create **UI > Button - TextMeshPro** under the Canvas.
6. If Unity asks to import TMP essentials, click **Import TMP Essentials**.
7. Rename the button `BTN_SelectSolar`.
8. Change its label to `Solar Turret`.
9. In the Button component’s **On Click** list, press `+`.
10. Drag the scene `BuildManager` object into the target slot.
11. Choose `BuildManager > SelectTower`.
12. Assign `PF_Tower_Solar_L1` as the argument.

### Node click behavior

1. Press Play.
2. Click an empty node before selecting a tower; nothing should be built.
3. Click `Solar Turret` in the UI.
4. Click an empty node.
5. One Solar Turret should appear at its `BuildPoint`.
6. Click the same node again; no second tower should appear.
7. Stop Play Mode.

### Completion check

- Selection works from the UI button.
- Exactly one tower can occupy a node.
- The tower is aligned correctly and parented or tracked by the node.
- No red Console error appears during placement.

---

## 8. Implement Malware Drone waypoint movement

### Scripts to create

Create:

```text
Assets/Scripts/Enemies/EnemyMovement.cs
Assets/Scripts/Enemies/EnemyPath.cs
```

### Responsibilities

`EnemyPath`:

- Stores the ordered waypoint Transforms.
- Provides them to enemies and the wave spawner.

`EnemyMovement`:

- Receives an `EnemyPath`.
- Moves toward the current waypoint using a units-per-second speed.
- Rotates smoothly toward travel direction.
- Advances to the next waypoint when close enough.
- Signals arrival when it reaches the final waypoint.

### Unity setup

1. Select `Waypoints`.
2. Add `EnemyPath`.
3. Fill its waypoint list in numeric order.
4. Open `PF_Enemy_MalwareDrone` in Prefab Mode by double-clicking it.
5. Add `EnemyMovement` to its root.
6. Set initial speed to about `2` world units per second.
7. Save the prefab and exit Prefab Mode.
8. Drag one Malware Drone into the scene at `EnemySpawnPoint`.
9. Assign the scene `EnemyPath` reference to it for this manual test.
10. Press Play.

### Completion check

- The drone follows every waypoint in order.
- It stays centered on the road.
- It faces the direction of movement.
- It reaches the core without stopping at a corner.
- The Console remains error-free.

---

## 9. Add enemy health and Energy Core health

### Scripts to create

```text
Assets/Scripts/Core/Damageable.cs
Assets/Scripts/Enemies/EnemyHealth.cs
Assets/Scripts/Gameplay/EnergyCoreHealth.cs
```

Prefer a small common damage interface or base component so a tower can damage enemies without knowing each enemy class.

### Enemy health

1. Add `EnemyHealth` to `PF_Enemy_MalwareDrone`.
2. Start with maximum health `30`.
3. On damage, subtract health and raise a health-changed event.
4. At zero, report the enemy death once and destroy the enemy.
5. Do not add Digital Waste yet; first make death reliable.

### Energy Core health

1. Add `EnergyCoreHealth` to `PF_EnergyCore`.
2. Start with maximum health `100`.
3. When an enemy reaches the final waypoint, apply prototype damage such as `10` to the core.
4. Remove that enemy after it damages the core so it cannot apply damage every frame.
5. At zero health, trigger the loss state once.

### Completion check

- A test damage call can destroy a Malware Drone.
- A drone reaching the destination removes exactly 10 core health once.
- Ten undamaged prototype drones can reduce a 100-health core to zero.
- Health never falls below zero or triggers death twice.

---

## 10. Implement Solar Turret targeting and attacks

### Scripts to create

```text
Assets/Scripts/Towers/TowerTargeting.cs
Assets/Scripts/Towers/SolarTurret.cs
Assets/Scripts/Gameplay/Projectile.cs
```

Start with a visible projectile. It is easier to debug than instant invisible damage.

### Tower behavior

1. Search for enemies inside a starting range of `5` world units.
2. Select one consistent target, preferably the enemy furthest along the path.
3. Keep the target while it is alive and inside range.
4. Rotate `RotatingHead` only around its vertical axis.
5. Fire from `MuzzlePoint` at a starting rate of one shot per second.
6. Let each projectile deal `10` damage.
7. Give the projectile a limited lifetime so missed shots cannot remain forever.

### Layers

1. Open **Edit > Project Settings > Tags and Layers**.
2. Add layers named `Enemy`, `Tower`, `PlacementNode`, and `Projectile`.
3. Put Malware Drone prefab roots on `Enemy`.
4. Put Solar Turret prefab roots on `Tower`.
5. Put placement-node roots on `PlacementNode`.
6. Configure targeting to search only the `Enemy` layer.

### Test arrangement

1. Place one Solar Turret beside a straight road segment.
2. Put one Malware Drone on the path.
3. Press Play.
4. Confirm the turret ignores the enemy outside range.
5. Confirm it turns and fires when the enemy enters range.
6. Confirm three 10-damage hits destroy a 30-health drone.

### Completion check

- Target acquisition is reliable.
- The tower head rotates while the base stays still.
- Damage occurs at the intended fire interval.
- Destroyed enemies are immediately removed from the target system.
- Projectiles clean themselves up.

---

## 11. Add the first wave spawner

### Scripts to create

```text
Assets/Scripts/Gameplay/WaveSpawner.cs
Assets/Scripts/Gameplay/WaveDefinition.cs
```

Use a ScriptableObject for `WaveDefinition` once the basic spawner works. This lets later stages define waves without changing code.

### Prototype wave

Use these initial values:

- Enemy prefab: `PF_Enemy_MalwareDrone`
- Count: `5`
- Spawn interval: `1.5` seconds
- Delay before wave: `2` seconds

### Scene setup

1. Under `_Systems`, create `WaveSpawner`.
2. Add the `WaveSpawner` component.
3. Assign `EnemySpawnPoint`.
4. Assign the scene `EnemyPath`.
5. Assign `PF_Enemy_MalwareDrone`.
6. Add a temporary `Start Wave` UI button.
7. Connect its On Click event to `WaveSpawner.StartNextWave()`.
8. Disable the button while a wave is active.

The spawner must count living enemies. A wave is complete only when it has finished spawning and every spawned enemy is dead or has reached the core.

### Completion check

- One button click creates exactly five drones.
- Drones spawn 1.5 seconds apart.
- Each drone receives the correct path.
- Clicking repeatedly cannot overlap the same wave accidentally.
- The spawner knows when no active enemies remain.

---

## 12. Add game states, victory, and defeat

### Script to create

```text
Assets/Scripts/Core/GameManager.cs
```

### Required states

```text
Preparing
WaveRunning
Victory
Defeat
Paused
```

### Rules

1. Begin in `Preparing`.
2. Enter `WaveRunning` when Start Wave is pressed.
3. Enter `Victory` when the final wave has spawned and no active enemies remain.
4. Enter `Defeat` when Energy Core health reaches zero.
5. Stop tower placement and wave starts during Victory or Defeat.
6. Show only one result panel.
7. Provide a Restart button that reloads `Prototype_Stage01`.

### UI setup

Under `HUDCanvas`, create:

```text
ResultPanel
  TXT_Result
  BTN_Restart
```

1. Make the panel cover the center portion of the screen.
2. Disable it in the Inspector by default.
3. Display `SYSTEM RESTORED` on victory.
4. Display `CORE CORRUPTED` on defeat.
5. Connect Restart to the scene reload method.

### Completion check

- Killing all enemies displays victory once.
- Letting enough enemies through displays defeat once.
- Inputs stop after either result.
- Restart restores the initial scene state.

---

## 13. Add the minimal HUD

### HUD elements

Create these under `HUDCanvas`:

```text
TopBar
  TXT_CoreHealth
  TXT_Wave
  TXT_Energy
  TXT_Pollution
BuildBar
  BTN_SelectSolar
  TXT_SelectedTower
  BTN_StartWave
ResultPanel
```

### Initial values

- Core: `100 / 100`
- Wave: `0 / 1`
- Energy: use a temporary starting value such as `100`
- Pollution: `0%`

Energy and Pollution may remain display-only until the first combat loop works. Do not block the prototype waiting for their full systems.

### Update method

Use events from health, wave, resource, and pollution systems to refresh text. Avoid searching for objects or updating unchanged UI text every frame.

### Completion check

- Core health changes when an enemy reaches the core.
- Wave text shows preparing, active, and completed states correctly.
- The selected tower name is visible.
- The HUD remains readable at 16:9 and does not cover placement nodes.

---

## 14. Add Digital Waste, Recycler, and Pollution after the loop works

Only begin this section after the first wave can be won and lost reliably.

### Digital Waste

1. Create `PF_DigitalWaste` from one existing waste model.
2. Give each enemy a waste-drop amount.
3. On enemy death, spawn waste at `WasteDropPoint`.
4. A waste item registers itself with the pollution system.
5. Uncollected waste contributes to pollution.

### Recycler Node

1. Create `PF_Tower_Recycler_L1`.
2. Give it a collection radius.
3. At an interval, find waste within the radius.
4. Pull one waste object toward the Recycler.
5. On collection, remove its pollution contribution and award the intended resource.

### Pollution thresholds

Implement threshold events at:

- 25%
- 50%
- 75%
- 100%

The visual and gameplay effects must come from the GDD. Keep the pollution calculation in one service so towers, UI, enemies, and environmental effects read the same value.

### Completion check

- Enemy death creates visible waste.
- Pollution rises while waste remains.
- Recycler collection removes waste and updates pollution.
- Crossing each threshold invokes its event exactly once per crossing.

---

## 15. Perform the first Git checkpoint

Do this only after the prototype opens without Console errors and the scene is saved outside Play Mode.

### Check ignored Unity folders

The repository should not commit:

- `Library/`
- `Temp/`
- `Logs/`
- `UserSettings/`
- IDE-generated project files

The existing `.gitignore` already covers these common paths.

### Check Git LFS

The existing `.gitattributes` assigns common image, audio, Blender, and FBX formats to Git LFS. Confirm Git LFS is installed before committing large binary assets.

### Suggested commit boundaries

Use small commits that each leave Unity usable:

```text
Fix tower placement system
Add prototype stage layout and prefabs
Add enemy waypoint movement and health
Add Solar Turret targeting and combat
Add first wave and game result states
Add prototype HUD
Add waste and pollution prototype
```

### Before each commit

1. Exit Play Mode.
2. Press `Ctrl+S`.
3. Confirm zero red Console errors.
4. Test the feature once from the start of the scene.
5. Close Unity if Git reports files still being rewritten during import.
6. Review the changed files.
7. Commit both each asset and its `.meta` file.

### Completion check

- Another clone can open the project with the same Unity version.
- `Prototype_Stage01` is present in the build profile.
- No generated Unity cache folders appear in Git.
- The complete first-playable work is pushed to GitHub.

---

## What comes immediately after this prototype

Once the prototype gate passes, expand in this order:

1. Replace temporary energy values with the Hydro Generator and energy network.
2. Add Firewall Node path defense and waste interaction.
3. Add EMP Tower area control.
4. Add Recycler upgrades and full pollution consequences.
5. Convert tower and enemy statistics into ScriptableObject assets.
6. Add tower selling with the GDD's 50% refund.
7. Add Level 2 and Level 3 tower behavior, then create their final models.
8. Add Corrupted Robot and the remaining normal enemy variants.
9. Add Rogue AI Core boss behavior and Core Corruption.
10. Balance Stage 1 fully.
11. Build Stages 2 through 5 from the proven systems.
12. Add menus, tutorial, settings, saving, audio, VFX, animation, accessibility, optimization, and release builds.

## Recommended working rhythm

Complete one feature at a time:

1. Make the smallest version work.
2. Test success and failure behavior.
3. Clear all Console errors.
4. Save the scene and prefabs.
5. Commit the stable feature.
6. Continue to the next numbered section.

For the next development session, perform **Section 1 only**: repair the placement scripts and reach zero Console errors. Then create `Prototype_Stage01` in Section 2.
