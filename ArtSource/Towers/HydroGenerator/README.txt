ReGenesis Hydro Generator Level 1

Open ReGenesis_HydroGenerator_L01.blend in Blender 4.5 or newer.
The FBX contains the model hierarchy without the preview studio.

DESIGN
The GDD defines Hydro Generator as an energy utility with a maintenance cycle.
The exposed turbine, blue water pipes, base water fittings and rear service
hatch are a proposed visual interpretation. Base fittings imply an external
water supply and discharge; this does not imply a self-powered closed loop.
No water simulation, generation gameplay or maintenance behavior is included.

PARTS AND TEXTURING
Base, Housing, Turbine, Rotor, WaterPipe, Valve, Maintenance and Generator parts
are separate named meshes. Each has UV_Texture packed independently in 0-1.
UVs overlap between DIFFERENT objects. Texture parts separately or repack
all intended meshes together before baking a shared atlas.
Materials are editable colors and emission, not painted textures.
Duplicate shared materials to customize only one component.

ROOT_HydroGenerator_L01 is at ground center. Blender: meters, Z up, front -Y.
PIVOT_TurbineRotor_Y rotates the hub and blades around local Y.
SOCKET_Hydro_EnergyOutput marks the roof connection for future effects.
FBX exports Y up / -Z forward. Unity emission materials may need setup.
FBX reimport verifies mesh count, UVs, materials and energy socket.
No Unity runtime test, colliders, LODs or animation clips included.

PREVIEW_STUDIO is hidden in the viewport but enabled for rendering.
The PNG is an actual Blender render of this model.
