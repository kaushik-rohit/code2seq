public int GetRemainTime()
		{
			if (m_context.param.mode == GameMode.TimelimitPVE)
			{
				return (int)(m_context.param.limitedTime - m_context.currentFrameIndex * 0.033333333);
			}
			return 0;
		}