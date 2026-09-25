ReGenesis EMP Tower Level 1

Open ReGenesis_EMPTower_L01.blend in Blender 4.5 or newer.
The FBX contains the tower only, without the preview studio.

DESIGN
The GDD names EMP Tower but does not define its detailed look or mechanics.
This model proposes an induction-coil silhouette matching the Solar Turret's
white armor, graphite structure and cyan lighting. No gameplay is implemented.

PARTS AND TEXTURING
Base_*: stationary base, armor, power housing and indicator lights.
Core_*: central insulated column and energy channels.
Coil_*: separate conductors, emissive traces and connecting spacers.
Guard_*: protective fins, anchors, cap plates and lights.
Emitter_*: crown, inset lens and pulse ring.
Each mesh has UV_Texture independently packed in the 0-1 tile. Layouts overlap
between DIFFERENT objects. Texture parts individually, or select all meshes
and repack together before baking to one shared atlas.
Materials are editable colors and emission; painted textures are not included.
Duplicate a shared material before changing only one part's appearance.

HIERARCHY AND EXPORT
ROOT_EMPTower_L01 is at ground center. Blender uses meters and Z up.
ASSEMBLY_EMP_Emitter groups the upper parts for editing and future animation.
SOCKET_EMP_PulseOrigin is a marker above the emitter for future effects.
FBX is Y up / -Z forward. Material emission may need setup in Unity.
The FBX was reimported in Blender to verify parts, materials, UVs and socket.
No Unity import or gameplay test was performed. No colliders or LODs included.

PREVIEW_STUDIO is hidden in the Blender viewport and enabled for rendering.
The preview PNG is an actual render of this model.
