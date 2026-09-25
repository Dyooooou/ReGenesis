ReGenesis Rogue AI Core Boss

Open ReGenesis_RogueAICore_L01.blend in Blender 4.5 or newer.
The FBX contains the boss model, rigid pivots and effect sockets.

DESIGN
The GDD identifies Rogue AI Core as the Stage 5 boss and says Recycler Node
Level 3 can shorten its Core Corruption duration. It does not define boss attacks.
The floating core, shield petals, orbital rings, crown and articulated tendrils
are a proposed visual design. No attack mechanics or invented stats are included.

PARTS AND TEXTURING
Meshes are separately named Core, OrbitRing, ShieldPetal, Tendril and Crown.
Every mesh has UV_Texture independently packed in 0-1. UVs overlap between
different objects. Texture independently or repack all intended meshes together
before baking a shared atlas. Materials are colors and emission only.

ANIMATION PREPARATION
ROOT_RogueAICore is at ground. ASSEMBLY_Boss_Float centers at 1.55m height.
Three PIVOT_OrbitRing objects support independent ring rotation.
PIVOT_ShieldArray_Z rotates all petals; each petal also has a named pivot.
Four tendrils have Upper and Lower pivots plus effect sockets at their tips.
PIVOT_Crown_Z supports crown rotation. These are rigid hierarchies, not bones.
SOCKET_Impact, SOCKET_CoreCorruption and SOCKET_DigitalWasteDrop are included.
No animations, colliders, LODs, AI, combat or boss phases included.

FBX exports Y up / -Z forward. Verify axes and emission materials in Unity.
The FBX was reimported in Blender to verify mesh UV and material data.
PREVIEW_STUDIO is hidden in the viewport and enabled for rendering.
The PNG is an actual Blender render of this model.
