ReGenesis Corrupted Robot

Open ReGenesis_CorruptedRobot_L01.blend in Blender 4.5 or newer.
The FBX contains the enemy model and hierarchical rigid-part joint pivots.

DESIGN
The GDD names Corrupted Robot as a cyber-physical enemy. This proposes a
bipedal robot matching the Malware Drone's dark armor and magenta signals.
Combat stats, attack behavior and weapons have not been invented or implemented.

PARTS AND TEXTURING
Separate named parts: Pelvis, Spine, Torso, Head, Arm, Hand, Leg and Foot.
Every mesh has UV_Texture independently packed in 0-1. UVs overlap between
different objects; texture individually or repack all intended meshes together
before baking a shared atlas. Materials are colors and emission, not textures.

ANIMATION PREPARATION
Root at ground center. Blender units: meters, Z up, forward -Y.
Pelvis -> Torso -> Head and Shoulder -> Elbow -> Wrist pivot chains.
Pelvis -> Hip -> Knee -> Ankle pivot chains. Joint names include L/R.
This is a hierarchy for rigid-part animation, not a skinned armature or Humanoid
rig. No walk cycles, IK, joint constraints, colliders or gameplay included.
SOCKET_Impact is on chest; SOCKET_DigitalWasteDrop is at ground root.

FBX exports Y up / -Z forward. Verify axes and emission materials in Unity.
Export reimport checked in Blender; no Unity runtime testing performed.
PREVIEW_STUDIO is hidden in viewport and enabled for rendering.
The PNG is an actual Blender render of the model.
