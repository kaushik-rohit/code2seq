public void Add(ICommand command)
        {
            if (commandsList.Count > 0 && currentCommandIndex != commandsList.Count - 1)
            {   // remove all the commands after current
                if(currentCommandIndex == -1)
                {
                    commandsList.RemoveRange(0, commandsList.Count);
                }
                else
                {
                    commandsList.RemoveRange(currentCommandIndex + 1,
                        commandsList.Count - (currentCommandIndex == -1 ? 0 : currentCommandIndex) - 1);
                }   
            }

            // add command to a list and increment index
            commandsList.Add(command);
            currentCommandIndex += 1;
            SetUndoRedoMessages();
        }