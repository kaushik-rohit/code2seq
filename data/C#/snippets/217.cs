public void OverrideOverlayTextureInfo(Texture srcTexture, IntPtr nativePtr, VR.VRNode node)
	{
		int index = (node == VR.VRNode.RightEye) ? 1 : 0;

		if (textures.Length <= index)
			return;
		
		textures[index] = srcTexture;
		cachedTextures[index] = srcTexture;
		texNativePtrs[index] = nativePtr;
	}