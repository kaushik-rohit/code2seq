internal static void ToWave(this OpenTK.NVector3[] glVectorArray, ref Vector3[] waveVectorArray)
        {
            if (waveVectorArray == null)
            {
                waveVectorArray = new Vector3[glVectorArray.Length];
            }
            else if (glVectorArray.Length != waveVectorArray.Length)
            {
                Array.Resize(ref waveVectorArray, glVectorArray.Length);
            }

            for (int i = 0; i < glVectorArray.Length; i++)
            {
                glVectorArray[i].ToWave(out waveVectorArray[i]);
            }
        }