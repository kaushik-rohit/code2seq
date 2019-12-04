protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
				if (_mainMenu != null)
				{
					_mainMenu.Dispose();
					_mainMenu = null;
				}

				if (_toolbar != null)
				{
					_toolbar.Dispose();
					_toolbar = null;
				}

				if (_toolStripContainer != null)
				{
					ToolStripSettings.Default.PropertyChanged -= OnToolStripSettingsPropertyChanged;

					_toolStripContainer.Dispose();
					_toolStripContainer = null;
				}

				if (_dockingManager != null)
				{
					_dockingManager.TabControlCreated -= OnDockingManagerTabControlCreated;
					_dockingManager.InnerControl = null;
					_dockingManager.Dispose();
					_dockingManager = null;
				}

				if (_tabbedGroups != null)
				{
					_tabbedGroups.TabControlCreated -= OnTabbedGroupsTabControlCreated;
					_tabbedGroups.Dispose();
					_tabbedGroups = null;
				}
				
				if (_components != null)
					_components.Dispose();
            }
            base.Dispose(disposing);
        }