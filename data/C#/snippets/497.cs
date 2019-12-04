internal static void ToWave(this OpenTK.NMatrix4 glMatrix, out Matrix waveMatrix)
        {
            waveMatrix.M11 = glMatrix.M11;
            waveMatrix.M12 = glMatrix.M21;
            waveMatrix.M13 = glMatrix.M31;
            waveMatrix.M14 = glMatrix.M41;
            waveMatrix.M21 = glMatrix.M12;
            waveMatrix.M22 = glMatrix.M22;
            waveMatrix.M23 = glMatrix.M32;
            waveMatrix.M24 = glMatrix.M42;
            waveMatrix.M31 = glMatrix.M13;
            waveMatrix.M32 = glMatrix.M23;
            waveMatrix.M33 = glMatrix.M33;
            waveMatrix.M34 = glMatrix.M43;
            waveMatrix.M41 = glMatrix.M14;
            waveMatrix.M42 = glMatrix.M24;
            waveMatrix.M43 = glMatrix.M34;
            waveMatrix.M44 = glMatrix.M44;
        }