public override bool PrepareExit()
		{
			// if task is running, the component cannot exit
			if (_task != null && _task.IsRunning)
			{
				if (_task.SupportsCancel && !_task.CancelRequestPending)
				{
					if (this.Host.DesktopWindow.ShowMessageBox(SR.MessageConfirmCancelTask, MessageBoxActions.OkCancel) == DialogBoxAction.Ok)
					{
						_task.RequestCancel();
						_autoClose = true;

						// even though the user has cancelled the task, we don't return true
						// because we don't want to allow this component to exit until the _task 
						// has actually stopped
					}
				}

				// Don't allow the dialog to close until the task stop running or is properly cancelled
				return false;
			}

			return true;
		}