protected virtual void UpdateView()
		{
			#if UNITY_5_2 || UNITY_5_3 || UNITY_5_4
			UpdateMaterial();
			#else
			UpdateViewReal();
			#endif
		}