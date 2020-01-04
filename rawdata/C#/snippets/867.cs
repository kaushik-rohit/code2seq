private void CheckTimeEnd()
		{
			if (IsTimelimited)
			{
				if (GetRemainTime() <= 0)
				{
					Terminate();
				}
			}
		}