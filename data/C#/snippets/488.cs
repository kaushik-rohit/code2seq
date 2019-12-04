protected override async ValueTask<Nothing> OnSuspended()
        {
            await base.OnSuspended();
            var lt = _module.QueryView<IModuleLifetime>();
            if (lt != null)
            {
                await lt.SuspendModule();
            }
            return Nothing.Value;
        }