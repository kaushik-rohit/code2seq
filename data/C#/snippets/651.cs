internal string Update(IMAP_SelectedFolder folder)
        {
            StringBuilder retVal = new StringBuilder();
            long maxUID = MessageUidNext - 1;

            long countExists = Messages.Count;
            long countRecent = RecentCount;

            // Add new messages
            for (int i = folder.Messages.Count - 1; i >= 0; i--)//FIX
            {
                IMAP_Message message = folder.Messages[i];
                // New message
                if (message.UID > maxUID)
                {
                    m_pMessages.Add(message.ID, message.UID, message.InternalDate, message.Size, message.Flags);
                }
                    // New messages ended
                else
                {
                    break;
                }
            }

            // Remove deleted messages
            for (int i = 0; i < m_pMessages.Count; i++)
            {
                IMAP_Message message = m_pMessages[i];

                if (!folder.m_pMessages.ContainsUID(message.UID))
                {
                    retVal.Append("* " + message.SequenceNo + " EXPUNGE\r\n");
                    m_pMessages.Remove(message);
                    i--;
                }
            }

            if (countExists != Messages.Count)
            {
                retVal.Append("* " + Messages.Count + " EXISTS\r\n");
            }
            if (countRecent != RecentCount)
            {
                retVal.Append("* " + RecentCount + " RECENT\r\n");
            }

            return retVal.ToString();
        }