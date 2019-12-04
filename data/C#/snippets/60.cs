protected override void InvokeEventHandler(Delegate genericHandler, object genericTarget)
        {
            KeyEventHandler handler = (KeyEventHandler) genericHandler;
            
            handler(genericTarget, this);
        }