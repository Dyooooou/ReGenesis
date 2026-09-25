ReGenesis Recycler Node Level 1

Open ReGenesis_RecyclerNode_L01.blend in Blender 4.5 or newer.
The FBX contains the model and hierarchy, without the preview studio.

DESIGN
The GDD defines Recycler Node as a non-attacking utility tower that converts
Digital Waste into Energy Resource and Sustainability Points. The intake,
processing vessel and recovery cartridges are a proposed visual interpretation.
Mint-green processing lights distinguish recycling from the cyan combat towers.
No waste objects, processing animations or gameplay behavior are implemented.

PARTS AND TEXTURING
Meshes are named Base, Chamber, Intake, Processor, Recovery and Badge.
Armor, feeder rollers, vessel bands, cartridges and lights are separate meshes.
Each mesh has UV_Texture packed independently in 0-1; UV layouts overlap
between different objects. Texture parts separately or repack all meshes
together before baking a shared atlas. Materials are editable solid colors
and emission; painted textures are not included.

ROOT_RecyclerNode_L01 is at ground center. Blender units: meters, Z up.
ASSEMBLY_Recycler_Processor groups the upper machine.
SOCKET_Recycler_WasteIntake marks the front intake; EnergyOutput marks the top.
FBX exports Y up / -Z forward. Material emission may need setup in Unity.
FBX reimport verifies named parts, UV maps, material assignments and intake.
No Unity runtime test, colliders, LODs, rig or animation clips included.

PREVIEW_STUDIO is hidden in the viewport but enabled for rendering.
The PNG is an actual Blender render of this model.
