[STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Skin manager--AUTO
            if (File.Exists(Application.StartupPath + "\\Common\\Themes\\color.ini") == false)
            {
                File.CreateText(Application.StartupPath + "\\Common\\Themes\\color.ini");
                File.WriteAllText(Application.StartupPath + "\\Common\\Themes\\color.ini", "blue");
                Application.Restart();
            }
            if (Properties.Settings.Default.dev_theme == "")
            {
                MaterialSkinManager skinmgr = MaterialSkinManager.Instance;
                skinmgr.Theme = MaterialSkinManager.Themes.LIGHT;
                skinmgr.ColorScheme = new ColorScheme(Primary.Blue800, Primary.Blue900, Primary.Blue500, Accent.Blue200, TextShade.WHITE);
            }
            if (File.ReadAllText(Application.StartupPath + "\\Common\\Themes\\" + Properties.Settings.Default.dev_theme + "\\color.ini") == "blue")
            {
                MaterialSkinManager skinmgr = MaterialSkinManager.Instance;
                skinmgr.Theme = MaterialSkinManager.Themes.LIGHT;
                skinmgr.ColorScheme = new ColorScheme(Primary.Blue800, Primary.Blue900, Primary.Blue500, Accent.Blue200, TextShade.WHITE);
            }
            if (File.ReadAllText(Application.StartupPath + "\\Common\\Themes\\" + Properties.Settings.Default.dev_theme + "\\color.ini") == "red")
            {
                MaterialSkinManager skinmgr = MaterialSkinManager.Instance;
                skinmgr.Theme = MaterialSkinManager.Themes.LIGHT;
                skinmgr.ColorScheme = new ColorScheme(Primary.Red800, Primary.Red900, Primary.Red500, Accent.Red200, TextShade.WHITE);
            }
            if (File.ReadAllText(Application.StartupPath + "\\Common\\Themes\\" + Properties.Settings.Default.dev_theme + "\\color.ini") == "orange")
            {
                MaterialSkinManager skinmgr = MaterialSkinManager.Instance;
                skinmgr.Theme = MaterialSkinManager.Themes.LIGHT;
                skinmgr.ColorScheme = new ColorScheme(Primary.Orange800, Primary.Orange900, Primary.Orange500, Accent.Orange200, TextShade.WHITE);
            }
            if (File.ReadAllText(Application.StartupPath + "\\Common\\Themes\\" + Properties.Settings.Default.dev_theme + "\\color.ini") == "brown")
            {
                MaterialSkinManager skinmgr = MaterialSkinManager.Instance;
                skinmgr.Theme = MaterialSkinManager.Themes.LIGHT;
                skinmgr.ColorScheme = new ColorScheme(Primary.Brown800, Primary.Brown900, Primary.Brown500, Accent.Blue200, TextShade.WHITE);
            }
            if (File.ReadAllText(Application.StartupPath + "\\Common\\Themes\\" + Properties.Settings.Default.dev_theme + "\\color.ini") == "purple")
            {
                MaterialSkinManager skinmgr = MaterialSkinManager.Instance;
                skinmgr.Theme = MaterialSkinManager.Themes.LIGHT;
                skinmgr.ColorScheme = new ColorScheme(Primary.Purple800, Primary.Purple900, Primary.Purple500, Accent.Purple200, TextShade.WHITE);
            }
            if (File.ReadAllText(Application.StartupPath + "\\Common\\Themes\\" + Properties.Settings.Default.dev_theme + "\\color.ini") == "pink")
            {
                MaterialSkinManager skinmgr = MaterialSkinManager.Instance;
                skinmgr.Theme = MaterialSkinManager.Themes.LIGHT;
                skinmgr.ColorScheme = new ColorScheme(Primary.Pink800, Primary.Pink900, Primary.Pink500, Accent.Pink200, TextShade.WHITE);
            }
            if (File.ReadAllText(Application.StartupPath + "\\Common\\Themes\\" + Properties.Settings.Default.dev_theme + "\\color.ini") == "yellow")
            {
                MaterialSkinManager skinmgr = MaterialSkinManager.Instance;
                skinmgr.Theme = MaterialSkinManager.Themes.LIGHT;
                skinmgr.ColorScheme = new ColorScheme(Primary.Yellow800, Primary.Yellow900, Primary.Yellow500, Accent.Yellow200, TextShade.WHITE);
            }
            if (File.ReadAllText(Application.StartupPath + "\\Common\\Themes\\" + Properties.Settings.Default.dev_theme + "\\color.ini") == "grey")
            {
                MaterialSkinManager skinmgr = MaterialSkinManager.Instance;
                skinmgr.Theme = MaterialSkinManager.Themes.LIGHT;
                skinmgr.ColorScheme = new ColorScheme(Primary.Grey800, Primary.Grey900, Primary.Grey500, Accent.Green200, TextShade.WHITE);
            }
            if (File.ReadAllText(Application.StartupPath + "\\Common\\Themes\\" + Properties.Settings.Default.dev_theme + "\\color.ini") == "green")
            {
                MaterialSkinManager skinmgr = MaterialSkinManager.Instance;
                skinmgr.Theme = MaterialSkinManager.Themes.LIGHT;
                skinmgr.ColorScheme = new ColorScheme(Primary.Green800, Primary.Green900, Primary.Green500, Accent.Green200, TextShade.WHITE);
            }
            if (File.ReadAllText(Application.StartupPath + "\\Common\\Themes\\" + Properties.Settings.Default.dev_theme + "\\color.ini") == "blue_red")
            {
                MaterialSkinManager skinmgr = MaterialSkinManager.Instance;
                skinmgr.Theme = MaterialSkinManager.Themes.LIGHT;
                skinmgr.ColorScheme = new ColorScheme(Primary.Red900, Primary.Blue900, Primary.Red500, Accent.Red200, TextShade.WHITE);
            }
            if (File.ReadAllText(Application.StartupPath + "\\Common\\Themes\\" + Properties.Settings.Default.dev_theme + "\\color.ini") == "blue_grey")
            {
                MaterialSkinManager skinmgr = MaterialSkinManager.Instance;
                skinmgr.Theme = MaterialSkinManager.Themes.LIGHT;
                skinmgr.ColorScheme = new ColorScheme(Primary.Grey800, Primary.Blue900, Primary.Grey500, Accent.Blue200, TextShade.WHITE);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }