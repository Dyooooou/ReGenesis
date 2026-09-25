ReGenesis Tower Placement Node

The node supports tower foundations up to approximately 2.08 meters diameter.
ROOT_TowerPlacementNode is at ground center. SOCKET_TowerOrigin sits at the top
surface and should be used as the instantiated tower position.

VISUAL STATES
Node_06_StatusRing and all Node_StatusLens meshes contain six material slots:
0 Empty Cyan
1 Hover Yellow
2 Selected Blue
3 Occupied Gray
4 Disabled Red
5 Warning Orange

The geometry uses slot 0 by default. A Unity script should swap the renderer
material to show the current state. This avoids overlapping state meshes.
SOCKET_HoverFX is available for an optional projected ring or particle effect.

All armor, status lenses, grid lines, seat and trim are separate named meshes.
Every mesh has an independent UV_Texture map in 0-1. UVs overlap between
different objects; repack them before baking one shared texture atlas.
Materials are editable colors and emission. No painted textures included.

FBX exports Y up and -Z forward. No placement script, collider, occupancy logic,
selection handling or Unity prefab is included.
