public static void ConvertToIcon(Image input, Stream output, int size = 16, bool preserveAspectRatio = true)
        {
            var inputBitmap = (Bitmap) input;

            int width = size, height = preserveAspectRatio ? inputBitmap.Height/inputBitmap.Width*size : size;

            var newBitmap = new Bitmap(inputBitmap, new Size(width, height));

            // save the resized png into a memory stream for future use
            using (var memoryStream = new MemoryStream())
            {
                newBitmap.Save(memoryStream, ImageFormat.Png);

                var iconWriter = new BinaryWriter(output);

                // 0-1 reserved, 0
                iconWriter.Write((byte) 0);
                iconWriter.Write((byte) 0);

                // 2-3 image type, 1 = icon, 2 = cursor
                iconWriter.Write((short) 1);

                // 4-5 number of images
                iconWriter.Write((short) 1);

                // image entry 1
                // 0 image width
                iconWriter.Write((byte) width);
                // 1 image height
                iconWriter.Write((byte) height);

                // 2 number of colors
                iconWriter.Write((byte) 0);

                // 3 reserved
                iconWriter.Write((byte) 0);

                // 4-5 color planes
                iconWriter.Write((short) 0);

                // 6-7 bits per pixel
                iconWriter.Write((short) 32);

                // 8-11 size of image data
                iconWriter.Write((int) memoryStream.Length);

                // 12-15 offset of image data
                iconWriter.Write(6 + 16);

                // write image data
                // png data must contain the whole png data file
                iconWriter.Write(memoryStream.ToArray());

                iconWriter.Flush();
            }
        }