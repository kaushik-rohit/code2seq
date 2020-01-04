public override void SetAttributes(OpenGL gl)
        {
            if (enableCullFace.HasValue) gl.EnableIf(OpenGL.GL_CULL_FACE, enableCullFace.Value);
            if(cullFaceMode.HasValue) gl.CullFace((uint)cullFaceMode.Value);
            if(enableSmooth.HasValue) gl.EnableIf(OpenGL.GL_POLYGON_SMOOTH, enableSmooth.Value);
            if(frontFaceMode.HasValue) gl.FrontFace((uint)frontFaceMode.Value);
            if(polygonMode.HasValue) gl.PolygonMode(OpenGL.GL_FRONT_AND_BACK, (uint)polygonMode.Value);
            if(offsetFactor.HasValue && offsetBias.HasValue) gl.PolygonOffset(offsetFactor.Value, offsetBias.Value);
            if(enableOffsetPoint.HasValue) gl.EnableIf(OpenGL.GL_POLYGON_OFFSET_POINT, enableOffsetPoint.Value);
            if(enableOffsetLine.HasValue) gl.EnableIf(OpenGL.GL_POLYGON_OFFSET_LINE, enableOffsetLine.Value);
            if(enableOffsetFill.HasValue) gl.EnableIf(OpenGL.GL_POLYGON_OFFSET_FILL, enableOffsetFill.Value);
        }