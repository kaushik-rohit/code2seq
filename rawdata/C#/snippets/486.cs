protected override async ValueTask<Nothing> OnAllInitialized()
        {
            await base.OnAllInitialized();
            var lt = _module.QueryView<IModuleLifetime>();
            if (lt != null)
            {
                await lt.AllModulesInitialized();
            }
            return Nothing.Value;
        }