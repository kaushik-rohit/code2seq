private static void drawPolygonMethod(object sender, EventArgs e) {
			// In both cases we must call setStartStopTitle with true, so it might as well go outside
			setStartStopTitle(true);
			
			if (m_timer != null) {
				m_timer.drawPolygon();
			} else {
				callMakeMultiForm(null, null);
			}
		}