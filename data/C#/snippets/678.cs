protected override async Task<bool> OnSketchCompleteAsync(Geometry geometry)
        {
            // Mask the raster based on the geometry.
            MaskRasterVM.MaskRaster(geometry);
            // Pass the call onwards.
            return await base.OnSketchCompleteAsync(geometry);
        }