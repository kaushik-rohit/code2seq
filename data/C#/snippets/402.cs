public static void setStartStopTitle(bool start) {
			if (start) {
				startStop.Text = tool + startStr;
				startStop.ToolTipText = "Start using the " + name;
				
			} else {
				startStop.Text = tool + stopStr;
				startStop.ToolTipText = "Stop using the " + name;
				
				
			}
		}