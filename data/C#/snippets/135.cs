static PacketDevice ChooseDevice()
        {
            //Get all available network devices.
            var Devices = LivePacketDevice.AllLocalMachine;

            //Read config if exists to auto choose a device.
            if(File.Exists(ConfigFileName))
            {
                string configDevice = File.ReadAllText(ConfigFileName);
                var device = Devices.Where(x => x.Name.Equals(configDevice));
                if(device.Count() == 1)
                {
                    Console.WriteLine("Automatically choosing device based on config.txt.");
                    Console.WriteLine("Delete that file to reenable manual device choice.");
                    return device.First();
                }else
                {
                    Console.WriteLine("Device from config was not found.");
                    File.Delete(ConfigFileName);
                }
            }

            //Matches some (all?) device descriptions to simplify the strings.
            Regex deviceDescriptionMatcher = new Regex(@"Network adapter '(.*?)' on local host");

            //Halt execution if no devices present.
            if (Devices.Count == 0)
            {
                Exit("No network devices found.");
            }

            //Output all device descriptions (i.e. friendly names)
            for (int i = 0; i < Devices.Count; i++)
            {
                var dev = Devices[i];
                if (dev.Description != null)
                {
                    string desc = dev.Description;

                    //Simplify string if verbose description present.
                    var match = deviceDescriptionMatcher.Match(desc);
                    if(match.Success)
                    {
                        desc = match.Groups[1].Value;
                    }

                    Console.WriteLine("({0}): {1}", i, desc);
                }
            }

            //Let the user choose a device through it's index in the collection.
            Console.Write("Choose device: ");
            var input = Console.ReadLine();
            int index;

            if (!int.TryParse(input, out index) || index < 0 || index >= Devices.Count)
            {
                Exit("Invalid input.");
            }

            if(Ask("Define this device as default?", false))
            {
                if(File.Exists(ConfigFileName))
                {
                    File.Delete(ConfigFileName);
                }
                File.WriteAllText(ConfigFileName, Devices[index].Name);
            }
            return Devices[index];
        }