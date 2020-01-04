public bool GetPosition(out ulong position, out ulong qpcPosition)
        {
            var hr = audioClockClientInterface.GetPosition(out position, out qpcPosition);
            if (hr == -1) return false;
            Marshal.ThrowExceptionForHR(hr);
            return true;
        }