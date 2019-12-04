protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            WindowConfig winConfig = new WindowConfig();
            winConfig.ConfigureMainWindow(this);

            Universal.Default.GameHasRunBefore = true;
        }