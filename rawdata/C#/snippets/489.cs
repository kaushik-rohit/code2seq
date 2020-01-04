protected override async ValueTask<Nothing> OnResumed()
        {
            await base.OnResumed();
            var lt = _module.QueryView<IModuleLifetime>();
            if (lt != null)
            {
                await lt.ResumeModule();
            }
            return Nothing.Value;
        }