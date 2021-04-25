using System;
using System.Collections.Generic;
using System.Text;

namespace OcclusionServerLib.structs
{
    public struct PlayerLocation
    {
        public float PosX;
        public float PosY;
        public float PosZ;

        public float Pitch;
        public float Yaw;

        public string World;

        public bool IsSpectator;

        public PlayerLocation(float x, float y, float z, float pitch, float yaw, string world, bool spectator)
        {
            PosX = x;
            PosY = y;
            PosZ = z;

            Pitch = pitch;
            Yaw = yaw;

            World = world;

            IsSpectator = spectator;
        }
    }
}
