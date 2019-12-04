private void OnPlayerDie(uint playerId)
		{
			if (m_mainPlayerId == playerId)
			{
				Pause();

				if (onMainPlayerDie != null)
				{
					onMainPlayerDie();
				}
				else
				{
					this.LogError("OnPlayerDie() onMainPlayerDie == null!");
				}
			}
		}