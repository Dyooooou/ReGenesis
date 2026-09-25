ReGenesis Digital Waste Variants

Three small scrap clusters are provided: DigitalWaste_A, B and C.
Use them as visual variants when enemies die so repeated drops look less uniform.

Each FBX root is at ground center and includes SOCKET_CollectFX and
SOCKET_GroundContact. Blender uses meters and Z up; FBX exports Y up / -Z forward.
The suggested pickup radius stored on each root is 0.65 meters, but gameplay
values should be chosen in Unity.

Scrap plates, fragments, corrupted data cells and residual charge pieces are
separate named meshes. Every mesh has an independently packed UV_Texture map.
UVs overlap between different objects. Texture each piece separately or repack
a whole variant before baking a shared atlas. Materials are solid colors and
emission; painted textures, collection logic, pollution behavior, animation,
colliders and particle effects are not included.

The overview Blender file arranges all three variants for inspection. Individual
FBX variants were exported at origin before that arrangement.
