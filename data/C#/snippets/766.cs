public override void Start()
		{
			if (_task != null)
			{
				_task.ProgressUpdated += ProgressHandler;
				_task.Terminated += TerminatedHandler;

				if (_task.IsRunning)
					UpdateProgress(_task.LastBackgroundTaskProgress);
				else
					_task.Run();
			}

			base.Start();
		}