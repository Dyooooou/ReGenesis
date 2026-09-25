ReGenesis Modular Smart City Road Kit

GRID AND ORIENTATION
All modules use a 4 x 4 meter grid and export with their ROOT at world origin.
Blender uses meters and Z up. FBX exports Y up and -Z forward.
Snap module roots to 4-meter increments in Unity. Rotate modules in 90-degree
increments to obtain mirrored corners and differently oriented junctions.

FBX MODULES
Road_Straight_4m: standard path section.
Road_Corner_4m: enters local south and exits local east.
Road_TJunction_4m: three-way junction.
Road_Cross_4m: four-way junction.
Road_SpawnGate_4m: straight path with enemy spawn arch and socket.
Road_CoreConnector_4m: path endpoint and Energy Core plaza connection.

TEXTURING
Ground, road, curbs, structures and lights are separate named meshes.
Each mesh has its own UV_Texture packed into 0-1. UVs overlap between different
objects. Texture individually or repack a module for a shared atlas.
Materials are editable colors and emission; painted textures are not included.

SOCKET_PathCenter is included in every module as a path-authoring reference.
SpawnGate includes SOCKET_EnemySpawn. CoreConnector includes SOCKET_EnergyCore.
The overview Blender file arranges modules for inspection; individual FBX roots
were exported at origin before that arrangement. No navmesh, waypoints, pathfinding,
colliders, prefabs or gameplay code are included.
