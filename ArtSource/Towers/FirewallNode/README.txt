ReGenesis Firewall Node Level 1

Open ReGenesis_FirewallNode_L01.blend in Blender 4.5 or newer.
The FBX contains only the model hierarchy, without the preview studio.

The GDD defines a passive 30% reduction of digital waste from passing enemies.
The shield emitter and filter cartridges are proposed visual representations.
This asset does not implement a blocking wall, shield mechanic, or gameplay.

TEXTURING
All meshes are separate and named by function: Base, Mount, Shield, Pylon,
Filter and Emblem. Each has a UV_Texture map independently packed in 0-1.
UVs overlap between different objects. Texture each part independently or
repack all intended parts together for a shared atlas before baking.
Materials are editable solid colors and emission, not painted textures.
Duplicate shared materials when changing only one part.

ROOT_FirewallNode_L01 is at ground center. Units: meters, Blender Z up.
ASSEMBLY_Firewall_Emitter groups the upper assembly.
SOCKET_Firewall_FieldOrigin marks the center for future effects.
FBX exports Y up / -Z forward. Unity material setup may be needed.
Export is verified through a Blender reimport, not a Unity runtime test.
No colliders, LODs, animation or gameplay scripts are included.

PREVIEW_STUDIO is hidden in the viewport and enabled for renders.
The preview PNG is an actual Blender render of this model.
