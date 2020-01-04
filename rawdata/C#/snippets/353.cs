protected virtual bool OnAttachBuffers(DeviceContextProxy context, ref int vertStartSlot)
        {
            if(GeometryBuffer.AttachBuffers(context, ref vertStartSlot, EffectTechnique.EffectsManager))
            {
                InstanceBuffer?.AttachBuffer(context, ref vertStartSlot);
                return true;
            }
            else
            {
                return false;
            }
        }