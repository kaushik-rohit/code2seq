public bool IsAlpha
            (
                char c
            )
        {
            // return Array.IndexOf(_characters, c) >= 0;

            return Array.BinarySearch(_characters, c) >= 0;
        }