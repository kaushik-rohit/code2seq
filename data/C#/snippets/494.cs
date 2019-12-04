internal static void ToWave(this OpenTK.NVector3 glVector3, out Vector3 waveVector)
        {
            waveVector.X = glVector3.X;
            waveVector.Y = glVector3.Y;
            waveVector.Z = glVector3.Z;
        }