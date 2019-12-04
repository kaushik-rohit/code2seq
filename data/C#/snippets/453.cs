public override bool AreAnyAttributesSet()
        {
            return enableCullFace.HasValue ||
                cullFaceMode.HasValue ||
                enableSmooth.HasValue ||
                frontFaceMode.HasValue ||
                polygonMode.HasValue ||
                offsetFactor.HasValue ||
                offsetBias.HasValue ||
                enableOffsetPoint.HasValue ||
                enableOffsetLine.HasValue ||
                enableOffsetFill.HasValue;
        }