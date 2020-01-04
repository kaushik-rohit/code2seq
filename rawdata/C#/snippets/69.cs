public static void CreateAudioReverb(SharpDX.ComObject apoOut) {
            unsafe {
                IntPtr apoOut_ = IntPtr.Zero;
                SharpDX.Result __result__;
                __result__= 
                    CreateAudioReverb_(&apoOut_);		
                ((SharpDX.ComObject)apoOut).NativePointer = apoOut_;
                __result__.CheckError();
            }
        }