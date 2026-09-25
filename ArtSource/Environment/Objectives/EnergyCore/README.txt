ReGenesis Energy Core

Open ReGenesis_EnergyCore_L01.blend in Blender 4.5 or newer.
The FBX contains the objective model, ring pivots and effect sockets.

DESIGN
The Energy Core is the city objective defined by the GDD. Enemies pursue it and
the player loses when it is destroyed. The clean chamber, pylons and consoles
match the tower family. No health values or gameplay logic are included.

PARTS AND TEXTURING
Separate named meshes: Base, Chamber, Pylon, EnergyRing, Console and Damage.
Every mesh has UV_Texture independently packed in 0-1. UVs overlap between
different objects. Texture independently or repack the intended meshes together
before baking a shared atlas. Materials are colors and emission only.

DAMAGE STATES
DAMAGE_STATE_PARTS contains WarningLight, CriticalLight and Crack meshes.
These objects are hidden in the Blender viewport and render by default.
They are intended as optional geometry for later Unity prefabs or scripts.
Healthy state uses the normal cyan lights. A destroyed mesh is not included;
destruction should initially use particles, disabled chamber parts and debris.

ANIMATION AND SOCKETS
ROOT_EnergyCore is at ground center. Blender units: meters, Z up.
Three PIVOT_EnergyRing objects can rotate independently.
SOCKET_AttackTarget is the enemy destination/attack point.
SOCKET_EnergyLinks, SOCKET_DestructionFX and SOCKET_CoreCenter are included.
No animation clips, colliders, gameplay, VFX or destruction simulation included.

FBX exports Y up / -Z forward. Verify axes and emission materials in Unity.
Export was reimported in Blender to verify meshes, UVs and materials.
PREVIEW_STUDIO is hidden in viewport and enabled for rendering.
The PNG is an actual Blender render.
