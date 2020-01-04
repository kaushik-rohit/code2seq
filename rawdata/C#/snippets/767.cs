public override void Stop()
		{
			// wait for the background task to stop running
			if (_task != null && _task.IsRunning)
				return;

			_task.ProgressUpdated -= ProgressHandler;
			_task.Terminated -= TerminatedHandler;
			base.Stop();
		}