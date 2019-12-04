public static void Position(Form form, Control ctrl, Point pos)
            {
                // InvokeRequired required compares the thread ID of the 
                // calling thread to the thread ID of the creating thread. 
                // If these threads are different, it returns true. 
                if (ctrl.InvokeRequired)
                {
                    SetPosCallback d = Position;
                    try
                    {
                        form.Invoke(d, form, ctrl, pos);
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                }
                else
                {
                    ctrl.Location = pos;
                }
            }