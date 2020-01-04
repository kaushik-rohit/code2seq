public void Cancel()
		{
			if (_task != null && _task.IsRunning)
			{
				if (_task.SupportsCancel)
				{
					_task.RequestCancel();
					_autoClose = true;
				}
			}
			else
			{
				this.ExitCode = ApplicationComponentExitCode.None;
				Host.Exit();
			}
		}