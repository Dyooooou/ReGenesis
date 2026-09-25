# ReGenesis Development Roadmap

## Purpose

This roadmap takes ReGenesis from its current asset foundation to a complete PC tower-defense campaign. Work through the phases in order. Do not begin large amounts of later-stage content until the current phase meets its completion gate.

The immediate goal is a vertical slice: one short stage in which the player can place a Solar Turret, defeat Malware Drones, collect Digital Waste with a Recycler Node, protect the Energy Core, and finish a wave. Once that loop is reliable, expand it into the five-stage campaign.

## Current Project Status

Completed asset foundations:

- Five Level 1 tower models: Solar Turret, EMP Tower, Firewall Node, Recycler Node, and Hydro Generator.
- Malware Drone, Corrupted Robot, and Rogue AI Core boss models.
- Energy Core objective.
- Modular 4-meter road kit.
- Tower placement node.
- Three Digital Waste variants.
- Residential, office, utility, landmark, and rooftop environment assets.

Still required:

- Unity materials, prefabs, colliders, animation, scripts, UI, stages, waves, balancing, sound, VFX, saving, settings, testing, optimization, builds, and documentation.
- Final enemy roster beyond Malware Drone, Corrupted Robot, and Rogue AI Core.
- Level 2 and Level 3 tower appearances after upgrade behavior is finalized.

## Decisions to Resolve Before Balancing

1. The GDD lists five towers but also mentions a Heavy Cannon in the Sustainability Meter rules. Decide whether Heavy Cannon is an old name for Solar Turret, replaces it, or becomes a sixth tower.
2. Define the complete regular-enemy roster. The current GDD explicitly names only Malware Drone and Corrupted Robot.
3. Confirm whether the ten campaign waves are distributed as two waves per stage. This is a sensible default but is not explicitly specified.
4. Define exact Level 1-3 statistics and upgrade effects only after the vertical slice feels playable.

## Phase 1 Project Foundation 0 to 8 Percent

### 1. Protect the project

1. Commit or back up the current Unity project.
2. Use Unity 6000.3.19f1, matching ProjectVersion.txt.
3. Confirm Git LFS is installed and pulling the FBX and image assets correctly.
4. Remove generated Library, Logs, Temp, Obj, and UserSettings content from Git tracking while keeping those folders ignored.
5. Create a development branch for the first playable prototype.

### 2. Choose the rendering setup

1. Use Universal Render Pipeline for the PC build unless the team has already committed to Built-in Render Pipeline.
2. Install and configure URP before creating final materials.
3. Use one URP renderer asset for normal gameplay and enable post-processing.
4. Start with modest bloom, ambient occlusion, color adjustment, and anti-aliasing.
5. Keep lighting readable from the isometric camera; avoid heavy darkness or excessive bloom.

### 3. Install required Unity packages

- Input System for mouse, keyboard, camera rotation, and rebinding.
- Cinemachine for the isometric camera.
- TextMeshPro for UI.
- Unity Test Framework for edit-mode and play-mode checks.

Do not use NavMesh for the first prototype. Fixed waypoint paths are simpler, deterministic, and easier to debug for this tower-defense design.

### 4. Establish project folders

Create or normalize these folders under Assets:

```text
Assets/
  Art/
    Materials/
    VFX/
  Audio/
    Music/
    SFX/
  Data/
    Enemies/
    Stages/
    Towers/
    Waves/
  Models/
  Prefabs/
    Enemies/
    Environment/
    Gameplay/
    Towers/
    UI/
  Scenes/
    Bootstrap/
    Campaign/
    Menus/
    Prototype/
  Scripts/
    Core/
    Data/
    Enemies/
    Environment/
    Gameplay/
    Towers/
    UI/
  Tests/
```

### 5. Configure layers

Create these layers:

- Ground
- Road
- BuildNode
- Tower
- Enemy
- DigitalWaste
- EnergyCore
- Projectile
- Effects

Configure the physics collision matrix so unnecessary groups do not interact. Projectiles should check enemies, placement raycasts should check BuildNode, and mouse-ground raycasts should ignore decorative buildings.

### Phase 1 completion gate

- The project opens without compile errors.
- Generated Unity folders are not tracked by Git.
- URP and required packages work.
- A blank Prototype scene runs with no warnings or missing materials.

## Phase 2 Import and Prefab Setup 8 to 16 Percent

### 1. Create shared materials

Build a small shared material library rather than duplicating materials per model:

- City Armor White
- Graphite Structure
- Titanium Trim
- Cyan Energy Emission
- Recycler Mint Emission
- Water Blue
- Enemy Dark Armor
- Enemy Magenta Corruption
- Warning Yellow
- Warning Orange
- Critical Red
- Window Deep Blue
- Road Surface
- Concrete Ground

Enable emission on glowing materials and confirm bloom is restrained. Preserve material naming so replacement is predictable.

### 2. Configure FBX import settings

For every FBX:

1. Confirm scale is 1 meter per unit.
2. Confirm forward and up axes visually in Unity.
3. Disable imported cameras and lights.
4. Disable animation import for static assets.
5. Enable readable meshes only when a runtime system requires CPU access.
6. Generate lightmap UVs for static buildings and road pieces if baked lighting will be used.
7. Assign shared Unity materials instead of relying on temporary embedded materials.

### 3. Create tower prefabs

For each Level 1 tower:

1. Create a prefab root at local position zero.
2. Preserve the named model pivots and sockets.
3. Add a simple capsule or box selection collider.
4. Add a range trigger on a child object for offensive towers.
5. Add selection, range-display, and placement-highlight child objects.
6. Assign the correct tower layer.
7. Add an empty UI anchor above the model.

Solar Turret must preserve yaw, pitch, and muzzle objects. Hydro Generator must preserve its turbine pivot. Utility towers should preserve their VFX sockets.

### 4. Create environment and gameplay prefabs

Create prefabs for:

- Every road module.
- Every building and rooftop kit.
- Placement Node.
- Energy Core.
- All three Digital Waste variants.
- Spawn Gate.
- Malware Drone, Corrupted Robot, and Rogue AI Core.

Use simple primitive colliders. Avoid detailed MeshColliders on buildings unless a specific gameplay interaction needs them.

### 5. Configure Placement Node materials

Create Unity materials matching these six node states:

- Empty cyan
- Hover yellow
- Selected blue
- Occupied gray
- Disabled red
- One-slot-left warning orange

Assign them through a PlacementNodeVisual component that changes the status ring and lens renderers.

### Phase 2 completion gate

- All current models appear correctly in Unity.
- No pink materials or broken axes remain.
- Every model has a prefab.
- Placement Node can switch through all six states from an inspector test.

## Phase 3 First Playable Map and Camera 16 to 23 Percent

### 1. Create Prototype Stage

1. Create `Prototype_Stage01.unity`.
2. Build a short path using the 4-meter road grid.
3. Place one Spawn Gate at the start.
4. Place the Energy Core connector and Energy Core at the end.
5. Add four Placement Nodes beside the path.
6. Place a few buildings outside the gameplay path.
7. Mark buildings and noninteractive scenery static.

### 2. Add waypoints

1. Create a PathRoot object.
2. Add ordered waypoint children from Spawn Gate to Energy Core.
3. Display waypoint lines with gizmos.
4. Validate that segments do not cut through curbs or buildings.
5. Store the waypoint path in the stage definition.

### 3. Implement isometric camera

1. Use an orthographic Cinemachine camera.
2. Start near a 35-45 degree downward angle.
3. Support 360-degree rotation in fixed increments or smooth rotation.
4. Support zoom with clamped limits.
5. Keep the Energy Core and playable road in view.
6. Block camera input when the pointer is over UI.

### Phase 3 completion gate

- The camera rotates and zooms cleanly.
- The whole stage can be inspected without clipping beneath the ground.
- A debug sphere can follow every waypoint from Spawn Gate to Energy Core.

## Phase 4 Core Software Architecture 23 to 30 Percent

### 1. Create ScriptableObject data types

Create these data assets:

- TowerDefinition: identity, prefab, price, energy use, range, targeting, Level 1-3 stats, Eco Score.
- EnemyDefinition: prefab, health, speed, core damage, reward, waste amount, resistances.
- WaveDefinition: enemy groups, timing, spawn gate, warning information.
- StageDefinition: scene, waves, slot limit, starting resources, pollution rules.
- UpgradeDefinition: price and stat/effect changes.

Keep tuning values in data assets, not hard-coded inside MonoBehaviours.

### 2. Create game services

Implement small focused services:

- GameFlowController
- WaveController
- BuildController
- EconomyController
- EnergyController
- PollutionController
- SustainabilityController
- StageResultController
- SaveController
- AudioController

Use C# events for state changes so UI listens without polling every frame. Avoid growing the old BuildManager into one large global manager.

### 3. Establish game states

Use explicit states:

- Loading
- BuildPhase
- WaveRunning
- PostWaveReport
- Paused
- Victory
- Defeat

Only allow building and maintenance during the intended states.

### Phase 4 completion gate

- A debug button can move through every game state.
- Data assets can be edited without changing code.
- UI debug text receives state events correctly.

## Phase 5 Vertical Slice Combat Loop 30 to 43 Percent

### 1. Enemy movement and health

1. Implement EnemyController with current waypoint index and movement speed.
2. Rotate ground enemies toward movement direction.
3. Let flying enemies use the same path at a fixed hover height initially.
4. Implement IDamageable and health events.
5. On reaching the Energy Core, apply damage and despawn.
6. Pool enemies instead of repeatedly instantiating and destroying them.

Start with Malware Drone only.

### 2. Energy Core health

1. Add maximum and current health.
2. Add damage events.
3. Drive healthy, warning, and critical visuals from health percentage.
4. Trigger defeat at zero health.
5. Play destruction VFX before opening the result screen.

### 3. Tower placement

1. Click a tower button to enter placement mode.
2. Raycast only against Placement Nodes.
3. Show hover and validity state.
4. Check price, stage slot limit, occupancy, and energy availability.
5. Instantiate the tower at SOCKET_TowerOrigin.
6. Mark the node occupied and deduct resources.
7. Allow cancellation with right click or Escape.
8. Allow tower demolition with a 50 percent refund.

### 4. Solar Turret combat

1. Detect enemies inside range.
2. Select the first enemy along the path as the initial targeting rule.
3. Rotate the yaw pivot horizontally.
4. Rotate the pitch pivot vertically within safe limits.
5. Spawn a pooled projectile at SOCKET_Muzzle.
6. Apply damage on impact.
7. Add fire-rate, damage, range, and projectile-speed stats.

### 5. First wave

1. Create one wave with 8-12 Malware Drones.
2. Show a countdown.
3. Spawn enemies at defined intervals.
4. Complete the wave only after all scheduled enemies are spawned and all living enemies are gone.
5. Display a simple wave-complete panel.

### Phase 5 completion gate

The player can launch the prototype, place a Solar Turret, defeat a complete Malware Drone wave, lose if the Energy Core is destroyed, and restart without errors.

This is the first true playable milestone.

## Phase 6 Digital Waste Pollution and Recycling 43 to 55 Percent

### 1. Digital Waste drops

1. On enemy death, choose one of the three waste variants.
2. Spawn it at SOCKET_DigitalWasteDrop.
3. Store waste value and pollution contribution in data.
4. Pool waste objects.
5. Add a subtle idle glow and collection effect.

### 2. Pollution Meter

Implement the GDD thresholds:

- Below 25 percent: normal operation.
- Level 1 at 25 percent: nearby tower efficiency reduced by 10 percent.
- Level 2 at 50 percent: energy consumption increased by 20 percent.
- Level 3 at 75 percent: bonus enemy spawns become possible.
- Level 4 at 100 percent: city collapse and defeat.

Make pollution increase from unprocessed waste over time. Use a configurable delay so the player has time to react.

### 3. Local pollution influence

1. Give each waste object an influence radius.
2. Track towers inside that radius.
3. Apply local efficiency penalties without searching the whole scene every frame.
4. Show a heat-map overlay or simple colored radius during debugging.

### 4. Recycler Node

1. Detect nearby waste.
2. Pull or process one waste object at a configurable interval.
3. Convert waste into Energy Resource.
4. Award Sustainability Points.
5. Remove the waste through pooling.
6. Show intake and processing VFX using the model sockets.

### 5. Firewall Node

1. Give it a path-adjacent influence volume.
2. Mark enemies passing through the field.
3. Reduce their eventual waste amount by 30 percent, as specified by the GDD.
4. Show a brief shield/filter effect when an enemy is processed.

### Phase 6 completion gate

- Enemies produce visible waste.
- Pollution rises when waste remains.
- Recycler Node removes waste and produces resources.
- Firewall Node reduces affected enemies' waste drops.
- Pollution can cause defeat at 100 percent.

## Phase 7 Energy Sustainability and Utility Systems 55 to 64 Percent

### 1. Energy system

1. Define generation, capacity, and continuous consumption.
2. Make active towers consume energy.
3. When energy is insufficient, pause affected towers instead of deleting them.
4. Make low-energy towers flicker before shutdown.
5. Show production, consumption, and reserve in the HUD.

### 2. Hydro Generator

1. Generate energy continuously.
2. Rotate the turbine while operating.
3. Add a maintenance timer.
4. Reduce output when maintenance is overdue.
5. Allow servicing during BuildPhase.
6. Use the rear hatch and warning material for maintenance feedback.

### 3. Sustainability Meter

1. Increase it from recycling and clean energy.
2. Decrease it from high pollution and ignored Hydro maintenance.
3. Resolve the Heavy Cannon/Solar Turret naming issue before adding any weapon-specific penalty.
4. Use Sustainability as part of the final grade.

### 4. EMP Tower

Define and prototype its role before polishing:

- Recommended role: low damage, area pulse, temporary slow or disable.
- Give resistant enemies reduced effect duration.
- Avoid permanent stun chains by adding diminishing returns or immunity time.

### Phase 7 completion gate

- Energy generation and consumption meaningfully constrain placement.
- Hydro maintenance affects output.
- EMP provides a useful control role without trivializing waves.
- Sustainability changes from player choices.

## Phase 8 Upgrade System and Level 2-3 Art 64 to 72 Percent

### 1. Finalize upgrade matrices

For every tower, define Level 1-3 values and one meaningful behavior improvement per level. Avoid upgrades that only increase every number.

Suggested directions:

- Solar Turret: fire rate, targeting efficiency, piercing or chain-energy option.
- EMP Tower: pulse radius, effect duration, overload pulse.
- Firewall Node: wider field, stronger waste reduction, secondary filtering effect.
- Recycler Node: processing speed, attraction radius, Level 3 auto-pulse and boss interaction.
- Hydro Generator: output, maintenance duration, reserve capacity.

### 2. Implement upgrades

1. Select a placed tower.
2. Display current stats and next-level changes.
3. Validate resource cost.
4. Apply upgraded data without replacing unrelated runtime state.
5. Swap or add visual components.
6. Preserve target, maintenance, and cooldown state where appropriate.

### 3. Build Level 2 and Level 3 models

Only after upgrade behavior is locked:

1. Add identifiable upgrade parts to the Level 1 source files.
2. Preserve sockets and pivots.
3. Make silhouettes readable from the isometric camera.
4. Export separate L2 and L3 FBXs or modular add-on prefabs.
5. Keep material families shared.

### Phase 8 completion gate

- All five towers can reach Level 3.
- Every upgrade changes strategy or function visibly.
- Upgrade visuals match their behavior.

## Phase 9 Full Enemy Roster and Boss 72 to 80 Percent

### 1. Define missing enemy roles

Before creating more models, define a compact roster that tests different strategies. At minimum include roles for:

- Fast low-health enemy.
- Standard enemy.
- Slow armored enemy.
- EMP-resistant or shielded enemy.
- Pollution-focused enemy that drops extra waste.
- Support enemy that buffs or repairs others.

Names, visuals, stage introductions, statistics, and waste values must be added to the GDD before production art.

### 2. Corrupted Robot

1. Add a rigid-part walk animation or proper armature if needed.
2. Give it higher durability than Malware Drone.
3. Add impact and death animations.
4. Confirm its role does not duplicate another enemy.

### 3. Rogue AI Core boss

1. Animate independent orbital rings, crown, shield array, and tendrils.
2. Design explicit phases with clear telegraphs.
3. Implement Core Corruption as a timed boss state.
4. Let Recycler Node Level 3 shorten Core Corruption, as required by the GDD.
5. Ensure the boss remains beatable through offense, balanced, and recycler-heavy strategies.
6. Add checkpoint-safe restart behavior.

### Phase 9 completion gate

- Every enemy has a distinct strategic purpose.
- All enemy introductions are staged and tutorialized.
- The boss works from start to finish without softlocks.
- All three intended strategy paths can defeat it.

## Phase 10 Campaign Stages and Waves 80 to 86 Percent

### 1. Build five stages

Use the modular road and building kits to make five visually distinct layouts. Increase tower slots from four in Stage 1 to eight in Stage 5 as specified by the GDD.

Each stage needs:

- One or more Spawn Gates.
- Valid waypoint paths.
- Energy Core location.
- Placement Nodes matching the slot limit.
- Camera bounds.
- Decorative buildings that do not obstruct readability.
- Stage-specific lighting and background arrangement.

### 2. Build ten waves

1. Start with one enemy type and short groups.
2. Introduce one new pressure or enemy role at a time.
3. Use Early Warning information before special waves.
4. End each stage with a Post-Wave Report.
5. Reserve Stage 5's final wave for Rogue AI Core.

### 3. Balance the three strategies

Test Full Offense, Balanced, and Recycler Heavy separately. Record:

- Energy Core health remaining.
- Maximum pollution reached.
- Resources earned and spent.
- Waste recycled.
- Tower composition and upgrade levels.
- Completion time.

Every path should be viable but create different risks.

### Phase 10 completion gate

- The campaign can be played from Stage 1 through Stage 5.
- Ten waves complete in the intended order.
- No required strategy dominates every test.

## Phase 11 UI Tutorial Saving and Results 86 to 92 Percent

### 1. Main menu

- Start Game
- Continue
- How to Play
- Settings
- Credits
- Exit

### 2. Gameplay HUD

- Energy Core health
- Pollution Meter and threshold state
- Energy production, consumption, and reserve
- Sustainability Meter
- Tower slots used and total
- Current wave and enemies remaining
- Resources
- Build buttons and costs
- Early Warning panel

### 3. Tower interaction UI

- Name and level
- Current statistics
- Upgrade preview and price
- Maintenance status where relevant
- Sell button and refund
- Range display

### 4. Tutorial

Use consequence-based teaching as required by the GDD:

1. Let the player see an initial waste drop.
2. Explain pollution after it begins rising.
3. Introduce Recycler Node as a response.
4. Warn before energy failure.
5. Explain Hydro maintenance when output begins falling.
6. Keep tutorial messages dismissible and concise.

### 5. Post-Wave Report

Show:

- Core damage taken.
- Enemies defeated and leaked.
- Waste created, remaining, and recycled.
- Peak pollution.
- Energy produced and consumed.
- Sustainability change.
- Recommended warning for the next wave.

### 6. Saving

Save campaign progress, unlocked stages, settings, tutorial completion, and best results. Use a versioned save format so fields can be added safely.

### 7. Final results

Calculate Total Score and Grade S/A/B/C from survival, Core health, pollution, recycling, Sustainability, and efficiency. Document the formula and test boundary values.

### Phase 11 completion gate

- A new player can understand and finish Stage 1 without external instructions.
- Saving and loading do not duplicate or lose progress.
- Results and grades match documented formulas.

## Phase 12 Audio VFX Animation and Polish 92 to 96 Percent

### Audio

- Menu and gameplay music.
- Wave start and completion cues.
- Tower firing, EMP pulse, recycling, maintenance, and upgrade sounds.
- Enemy movement, impact, death, and boss sounds.
- Pollution and low-energy warnings.
- UI feedback sounds.

### VFX

- Solar projectile and hit.
- EMP pulse.
- Firewall field/filter effect.
- Waste drop, idle corruption, attraction, and recycling.
- Hydro water/energy flow.
- Energy Core damage and destruction.
- Boss corruption and phase transitions.

### Animation

- Tower aiming and firing.
- Hydro turbine.
- Recycler processing.
- Drone rotors and hover motion.
- Robot walk, hit, attack, and death.
- Boss orbitals, shield petals, tendrils, phases, and death.

### Environment polish

- Streetlights, barriers, planters, energy relays, waste containers, and signs.
- Stage boundaries and distant background city blocks.
- Decals and road variation.
- Light baking or mixed lighting.
- Camera-safe effects and readable silhouettes.

### Phase 12 completion gate

- Every important player action has immediate visual and audio feedback.
- Important warnings remain readable during busy waves.
- The game has a consistent visual and sound identity.

## Phase 13 Testing Optimization and Release 96 to 100 Percent

### 1. Automated tests

Write focused tests for:

- Damage and resistance calculations.
- Pollution threshold effects.
- Waste conversion rewards.
- Energy shutdown and recovery.
- Upgrade cost and level limits.
- 50 percent tower refund.
- Wave completion conditions.
- Score and grade boundaries.
- Save migration and load validation.

### 2. Manual test matrix

Test every stage with:

- Full Offense strategy.
- Balanced strategy.
- Recycler Heavy strategy.
- Minimum and maximum graphics settings.
- Different resolutions and aspect ratios.
- Pause, restart, scene transition, and save/load during every safe state.

### 3. Performance

1. Profile CPU, GPU, memory, and garbage collection in a release build.
2. Pool enemies, projectiles, waste, and repeated VFX.
3. Add LODs to large buildings if needed.
4. Enable static batching or GPU instancing for repeated environment assets.
5. Use object counts and profiler evidence before optimizing.
6. Set a stable PC target, preferably 60 FPS on the team's minimum test machine.

### 4. Accessibility and settings

- Master, music, SFX, and UI volume.
- Resolution, display mode, quality, and frame-rate limit.
- Camera rotation sensitivity and direction.
- Optional screen shake and reduced flashing.
- Color-independent pollution and warning indicators.
- Readable UI scaling.

### 5. Release preparation

1. Remove debug buttons, test scenes, and development-only logs from release flow.
2. Confirm licenses and credits for every external asset and sound.
3. Create the Windows build.
4. Test on a clean machine without Unity installed.
5. Write installation and gameplay instructions.
6. Record the required demonstration video.
7. Prepare screenshots, icon, title image, credits, proposal visuals, and technical documentation.
8. Tag the final source revision and archive the submitted build.

### Final completion gate

ReGenesis is complete when the five-stage, ten-wave campaign can be installed and played from Main Menu to final Results without editor intervention; every intended strategy can win; the pollution, recycling, energy, upgrades, boss, saving, UI, audio, and settings systems work; performance meets the chosen PC target; and the release build passes the full test matrix on a clean machine.

## Immediate Implementation Sprint

Do this next, in order:

1. Clean Git tracking and fix current C# compile errors.
2. Configure URP, Input System, Cinemachine, TextMeshPro, layers, and folders.
3. Create shared Unity materials.
4. Import and prefab the road, Placement Node, Energy Core, Solar Turret, Recycler Node, Malware Drone, and one waste variant.
5. Build Prototype Stage 01 with one path and four nodes.
6. Implement waypoint movement and Energy Core health.
7. Implement placement and one Solar Turret attack.
8. Implement one Malware Drone wave.
9. Implement waste drops, Pollution Meter, and Recycler processing.
10. Add a minimal HUD and win/lose screens.

Stop after this sprint and playtest the complete loop before adding more content.
