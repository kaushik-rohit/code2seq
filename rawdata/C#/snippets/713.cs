public override string ToString()
		{
			StringBuilder bdr = new StringBuilder();
			//bdr.AppendLine("Average roundtrip time: " + NetTime.ToReadable(m_connection.m_averageRoundtripTime));
			bdr.AppendLine("Current MTU: " + m_connection.m_currentMTU);
			bdr.AppendLine("Sent " + m_sentBytes + " bytes in " + m_sentMessages + " messages in " + m_sentPackets + " packets");
			bdr.AppendLine("Received " + m_receivedBytes + " bytes in " + m_receivedMessages + " messages (of which " + m_receivedFragments + " fragments) in " + m_receivedPackets + " packets");

			if (m_resentMessagesDueToDelay > 0)
				bdr.AppendLine("Resent messages (delay): " + m_resentMessagesDueToDelay);
			if (m_resentMessagesDueToDelay > 0)
				bdr.AppendLine("Resent messages (holes): " + m_resentMessagesDueToHole);

			int numUnsent = 0;
			int numStored = 0;
			foreach (NetSenderChannelBase sendChan in m_connection.m_sendChannels)
			{
				if (sendChan == null)
					continue;
				numUnsent += sendChan.m_queuedSends.Count;

				var relSendChan = sendChan as NetReliableSenderChannel;
				if (relSendChan != null)
				{
					for (int i = 0; i < relSendChan.m_storedMessages.Length; i++)
						if (relSendChan.m_storedMessages[i].Message != null)
							numStored++;
				}
			}

			int numWithheld = 0;
			foreach (NetReceiverChannelBase recChan in m_connection.m_receiveChannels)
			{
				var relRecChan = recChan as NetReliableOrderedReceiver;
				if (relRecChan != null)
				{
					for (int i = 0; i < relRecChan.m_withheldMessages.Length; i++)
						if (relRecChan.m_withheldMessages[i] != null)
							numWithheld++;
				}
			}

			bdr.AppendLine("Unsent messages: " + numUnsent);
			bdr.AppendLine("Stored messages: " + numStored);
			bdr.AppendLine("Withheld messages: " + numWithheld);

			return bdr.ToString();
		}