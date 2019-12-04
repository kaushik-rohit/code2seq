public static void SoundBeep(int frequency, int duration)
        {
            if (frequency == 0)
                frequency = 523;

            if (duration == 0)
                duration = 150;

            Console.Beep(frequency, duration);
        }