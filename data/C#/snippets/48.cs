public virtual void ForceInitialize(T argument)
        {
            Awake();
            PropagateArgument(argument);
            Start();
        }