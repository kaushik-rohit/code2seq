protected override void OnPaint(PaintEventArgs e)
        {
            if(waveStream != null)
            {
                waveStream.Position = 0;
                int bytesRead;
                byte[] waveData = new byte[samplesPerPixel*bytesPerSample];
                waveStream.Position = startPosition + (e.ClipRectangle.Left * bytesPerSample * samplesPerPixel);
                
                for(float x = e.ClipRectangle.X; x < e.ClipRectangle.Right; x+=1)
                {
                    short low = 0;
                    short high = 0;
                    bytesRead = waveStream.Read(waveData, 0, samplesPerPixel * bytesPerSample);
                    if(bytesRead == 0)
                        break;
                    for(int n = 0; n < bytesRead; n+=2)
                    {
                        short sample = BitConverter.ToInt16(waveData, n);
                        if(sample < low) low = sample;
                        if(sample > high) high = sample;
                    }
                    float lowPercent = ((((float) low) - short.MinValue) / ushort.MaxValue);
                    float highPercent = ((((float) high) - short.MinValue) / ushort.MaxValue);
                    e.Graphics.DrawLine(Pens.Black,x,this.Height * lowPercent,x,this.Height * highPercent);					
                } 
            }

            base.OnPaint (e);
        }