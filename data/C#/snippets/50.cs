public static void Initialize()
		{
			string path = Files.GetFilePath("bodyconv.def");

			if (path == null)
			{
				return;
			}

			List<int> list1 = new List<int>(), list2 = new List<int>(), list3 = new List<int>(), list4 = new List<int>();
			int max1 = 0, max2 = 0, max3 = 0, max4 = 0;

			using (var ip = new StreamReader(path))
			{
				string line;

				while ((line = ip.ReadLine()) != null)
				{
					if ((line = line.Trim()).Length == 0 || line.StartsWith("#"))
					{
						continue;
					}

					try
					{
						string[] split = line.Split('\t');

						int original = System.Convert.ToInt32(split[0]);
						int anim2 = System.Convert.ToInt32(split[1]);
						int anim3;
						int anim4;
						int anim5;

						try
						{
							anim3 = System.Convert.ToInt32(split[2]);
						}
						catch
						{
							anim3 = -1;
						}

						try
						{
							anim4 = System.Convert.ToInt32(split[3]);
						}
						catch
						{
							anim4 = -1;
						}

						try
						{
							anim5 = System.Convert.ToInt32(split[4]);
						}
						catch
						{
							anim5 = -1;
						}

						if (anim2 != -1)
						{
							if (anim2 == 68)
							{
								anim2 = 122;
							}

							if (original > max1)
							{
								max1 = original;
							}

							list1.Add(original);
							list1.Add(anim2);
						}

						if (anim3 != -1)
						{
							if (original > max2)
							{
								max2 = original;
							}

							list2.Add(original);
							list2.Add(anim3);
						}

						if (anim4 != -1)
						{
							if (original > max3)
							{
								max3 = original;
							}

							list3.Add(original);
							list3.Add(anim4);
						}

						if (anim5 != -1)
						{
							if (original > max4)
							{
								max4 = original;
							}

							list4.Add(original);
							list4.Add(anim5);
						}
					}
					catch
					{ }
				}
			}

			Table1 = new int[max1 + 1];

			for (int i = 0; i < Table1.Length; ++i)
			{
				Table1[i] = -1;
			}

			for (int i = 0; i < list1.Count; i += 2)
			{
				Table1[list1[i]] = list1[i + 1];
			}

			Table2 = new int[max2 + 1];

			for (int i = 0; i < Table2.Length; ++i)
			{
				Table2[i] = -1;
			}

			for (int i = 0; i < list2.Count; i += 2)
			{
				Table2[list2[i]] = list2[i + 1];
			}

			Table3 = new int[max3 + 1];

			for (int i = 0; i < Table3.Length; ++i)
			{
				Table3[i] = -1;
			}

			for (int i = 0; i < list3.Count; i += 2)
			{
				Table3[list3[i]] = list3[i + 1];
			}

			Table4 = new int[max4 + 1];

			for (int i = 0; i < Table4.Length; ++i)
			{
				Table4[i] = -1;
			}

			for (int i = 0; i < list4.Count; i += 2)
			{
				Table4[list4[i]] = list4[i + 1];
			}
		}