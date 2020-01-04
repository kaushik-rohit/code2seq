public override void SendOSCMessage(){
			if(_OSCeArg.Packet is OscMessage)
			{
                ((OscMessage)_OSCeArg.Packet).UpdateDataAt(0, _sliderValue);
			}
			else if(_OSCeArg.Packet is OscBundle)
			{
                foreach (OscMessage m in ((OscBundle)_OSCeArg.Packet).Messages)
                {
                    m.UpdateDataAt(0, _sliderValue);
                }				
			}


			_SendOSCMessage(_OSCeArg);
		}