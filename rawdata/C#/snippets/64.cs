public static void XAudio2Create(SharpDX.XAudio2.XAudio2 xAudio2Out, int flags, int xAudio2Processor) {
            unsafe {
                IntPtr xAudio2Out_ = IntPtr.Zero;
                SharpDX.Result __result__;
                __result__= 
                    XAudio2Create_(&xAudio2Out_, flags, xAudio2Processor);		
                ((SharpDX.XAudio2.XAudio2)xAudio2Out).NativePointer = xAudio2Out_;
                __result__.CheckError();
            }
        }