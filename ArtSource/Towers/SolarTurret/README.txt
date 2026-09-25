ReGenesis Solar Turret Level 1

Open ReGenesis_SolarTurret_L01.blend in Blender 4.5 or newer.
The FBX contains only the tower and its aiming hierarchy, without the studio.

45 separate, named mesh parts; 6,892 triangles total.
Base_* = stationary foundation, armor, bearing and lights.
Yaw_* = rotating neck and cradle.
Head_* = weapon armor, rails, side joints and vents.
Emitter_* = muzzle housing, recess and luminous core.

TEXTURING
Every mesh has a UV_Texture map packed individually into the 0-1 tile.
UVs overlap between DIFFERENT objects by design; these are per-part layouts.
For one shared texture atlas, select all intended meshes and repack their UVs
together before baking. The existing materials are editable solid colors and
emission, not painted texture maps. Material groups: Armor, Structure, Joints,
Energy and Emitter glass. Duplicate a shared material to customize one part.

AIMING
ROOT_SolarTurret_L01 sits at ground center. Blender units are meters.
PIVOT_Yaw_Z rotates the whole upper assembly around local Z.
PIVOT_Pitch_X rotates the weapon around its side-joint axis (local X).
SOCKET_Muzzle marks the projectile spawn point. Weapon faces Blender -Y.
FBX exports with Y up and -Z forward. Verify axes and materials in Unity;
no Unity import or gameplay test has been performed.

PREVIEW
The PREVIEW_STUDIO collection is hidden in the Blender viewport and enabled
for rendering. It contains the camera, lights and floor; not game geometry.
The PNG is an actual Blender render of this mesh.

This is a first editable model based on the approved panel-free concept.
No solar panels, animation clips, colliders, LODs or gameplay scripts included.
