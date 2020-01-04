public static void SoundPlay(string filename, bool wait)
        {
            ErrorLevel = 0;

            if (filename.Length > 1 && filename[0] == '*')
            {
                int n;

                if (!int.TryParse(filename.Substring(1), out n))
                {
                    ErrorLevel = 1;
                    return;
                }

                switch (n)
                {
                    case -1: SystemSounds.Beep.Play(); break;
                    case 16: SystemSounds.Hand.Play(); break;
                    case 32: SystemSounds.Question.Play(); break;
                    case 48: SystemSounds.Exclamation.Play(); break;
                    case 64: SystemSounds.Asterisk.Play(); break;
                    default: ErrorLevel = 1; break;
                }

                return;
            }

            try
            {
                var sound = new SoundPlayer(filename);

                if (wait)
                    sound.PlaySync();
                else
                    sound.Play();
            }
            catch (Exception)
            {
                ErrorLevel = 1;
            }
        }