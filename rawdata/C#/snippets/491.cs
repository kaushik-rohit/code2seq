protected override async ValueTask<Nothing> OnAllResumed()
        {
            await base.OnAllResumed();
            var lt = _module.QueryView<IModuleLifetime>();
            if (lt != null)
            {
                await lt.AllModulesResumed();
            }
            return Nothing.Value;
        }