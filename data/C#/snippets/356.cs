public sealed override void Render(RenderContext context, DeviceContextProxy deviceContext)
        {
            if (PreRender(context, deviceContext))
            {
                OnRender(context, deviceContext);
            }
        }