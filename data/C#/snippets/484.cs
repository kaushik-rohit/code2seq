protected override async ValueTask<Nothing> OnInitialize(IModuleProvider moduleProvider)
        {
            await base.OnInitialize(moduleProvider);
            var lt = _module.QueryView<IModuleLifetime>();
            if (lt != null)
            {
                await lt.InitializeModule(moduleProvider);
            }
            return Nothing.Value;
        }