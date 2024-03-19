﻿using System;

namespace Assets.Game.StartArcheticture.SerializableStructure {
    [Serializable]
    public class Vector3 {
        public float X;
        public float Y;
        public float Z;

        public Vector3(float x, float y, float z) {
            X = x;
            Y = y;
            Z = z;
        }
    }
}