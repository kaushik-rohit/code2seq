internal static void ToWave(this OpenTK.NMatrix3 glMatrix, out Matrix waveMatrix)
        {
            waveMatrix.M11 = glMatrix.R0C0;
            waveMatrix.M12 = glMatrix.R1C0;
            waveMatrix.M13 = glMatrix.R2C0;
            waveMatrix.M14 = 0;
            waveMatrix.M21 = glMatrix.R0C1;
            waveMatrix.M22 = glMatrix.R1C1;
            waveMatrix.M23 = glMatrix.R2C1;
            waveMatrix.M24 = 0;
            waveMatrix.M31 = glMatrix.R0C2;
            waveMatrix.M32 = glMatrix.R1C2;
            waveMatrix.M33 = glMatrix.R2C2;
            waveMatrix.M34 = 0;
            waveMatrix.M41 = 0;
            waveMatrix.M42 = 0;
            waveMatrix.M43 = 0;
            waveMatrix.M44 = 0;
        }