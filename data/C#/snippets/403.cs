private static void toogleStartStop(object sender, EventArgs e) {
			if (m_timer != null) {
				if (startStop.Text != tool + startStr) {
					
					setStartStopTitle(true);
					m_timer.resumeTexture();
				} else {
					
					setStartStopTitle(false);
					m_timer.stopTexture();
				}
			} else {
				setStartStopTitle(true);
				callMakeMultiForm(null, null);
			}
		}