protected override async ValueTask<Nothing> OnDispose()
        {
            var lt = _module.QueryView<IModuleLifetime>();
            if (lt != null)
            {
                await lt.DisposeModule();
            }
            await base.OnDispose();
            return Nothing.Value;
        }