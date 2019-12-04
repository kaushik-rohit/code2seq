public void Undo()
        {
            ICommand command = commandsList[currentCommandIndex] as ICommand;
            command.Undo();
            currentCommandIndex -= 1;
            SetUndoRedoMessages();
        }