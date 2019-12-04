public static void makeMultiForm(brushData data) {
		
			UI.MultiForm form = UI.MultiForm.makeMultiForm();
		
			if (data != null)
				form.setData(data);
			
			if (DialogResult.OK == form.ShowDialog() && form.data != null) {
					
				drawPolygon.Enabled = false;
				if (form.data.mode == paintmode.paint) {
					debugOut("brush!");
					tool = "Brush";
				} else if (form.data.mode == paintmode.eyedrop) {
					debugOut("eyedrop");
					tool = "Eyedrop tool";
				} else if (form.data.mode == paintmode.polygon) {
					debugOut("Polygon");
					tool = "Polygon paint";
					drawPolygon.Enabled = true;
				} else {
					throw new Exception("Error wrong paint mode");
				}
			//	setStartStopTitle(true);
				
				if (!form.stopSystem) {
					if (m_timer != null) {
						m_timer.setNewData(form.data);
						m_timer.resumeTexture();	
					} else {
						m_timer = new IntervalTimer(form.data);
						m_timer.startTexture();
					} 
					setStartStopTitle(true);
				}
				else {
					
					if (m_timer != null) {
						m_timer.stopTexture();
						setStartStopTitle(false);
					}
				}
			}
			
			if (form.data == null) {
				setStartStopTitle(false);
			}
		}