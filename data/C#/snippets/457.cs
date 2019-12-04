public void Redo()
        {
            ICommand command = commandsList[++currentCommandIndex] as ICommand;
            command.Redo();
            SetUndoRedoMessages();
        }