public static void Reload()
		{
			m_FileIndex = new FileIndex("Anim.idx", "Anim.mul", 0x40000, 6);
			m_FileIndex2 = new FileIndex("Anim2.idx", "Anim2.mul", 0x10000, -1);
			m_FileIndex3 = new FileIndex("Anim3.idx", "Anim3.mul", 0x20000, -1);
			m_FileIndex4 = new FileIndex("Anim4.idx", "Anim4.mul", 0x20000, -1);
			m_FileIndex5 = new FileIndex("Anim5.idx", "Anim5.mul", 0x20000, -1);

			BodyConverter.Initialize();
			BodyTable.Initialize();
		}