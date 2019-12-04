protected override unsafe void ProcessFilter( UnmanagedImage image, Rectangle rect )
        {
            int pixelSize = ( image.PixelFormat == PixelFormat.Format8bppIndexed ) ? 1 : 3;

            int width   = rect.Width;
            int height  = rect.Height;

            // processing start and stop X,Y positions
            int startY  = rect.Top;
            int stopY   = startY + height;
            int startX  = rect.Left;
            int stopX   = startX + width;
            int startXInBytes = startX * pixelSize;
            int stopXInBytes  = stopX * pixelSize;

            int stride = image.Stride;

            // perform Y mirroring
            if ( mirrorY )
            {
                // first pointer - points to the first pixel in line
                byte* ptr1 = (byte*) image.ImageData.ToPointer( );
                ptr1 += ( startY * stride + startX * pixelSize );
                // second pointer - points to the last pixel in line
                byte* ptr2 = (byte*) image.ImageData.ToPointer( );
                ptr2 += ( startY * stride + ( stopX - 1 ) * pixelSize );

                // offsets
                int offset1 = stride - ( width >> 1 ) * pixelSize;
                int offset2 = stride + ( width >> 1 ) * pixelSize;

                // temporary value for swapping
                byte v;

                if ( image.PixelFormat == PixelFormat.Format8bppIndexed )
                {
                    // grayscale mirroring

                    // for each line
                    for ( int y = startY; y < stopY; y++ )
                    {
                        // for each pixel
                        for ( int x = startX, halfStopX = startX + ( width >> 1 ); x < halfStopX; x++, ptr1++, ptr2-- )
                        {
                            // swap values
                            v = *ptr1;
                            *ptr1 = *ptr2;
                            *ptr2 = v;
                        }
                        ptr1 += offset1;
                        ptr2 += offset2;
                    }
                }
                else
                {
                    // color mirroring

                    // for each line
                    for ( int y = startY; y < stopY; y++ )
                    {
                        // for each pixel
                        for ( int x = startX, halfStopX = startX + ( width >> 1 ); x < halfStopX; x++, ptr1 += 3, ptr2 -= 3 )
                        {
                            // swap Red
                            v = ptr1[RGB.R];
                            ptr1[RGB.R] = ptr2[RGB.R];
                            ptr2[RGB.R] = v;

                            // swap Green
                            v = ptr1[RGB.G];
                            ptr1[RGB.G] = ptr2[RGB.G];
                            ptr2[RGB.G] = v;

                            // swap Blue
                            v = ptr1[RGB.B];
                            ptr1[RGB.B] = ptr2[RGB.B];
                            ptr2[RGB.B] = v;
                        }
                        ptr1 += offset1;
                        ptr2 += offset2;
                    }
                }
            }

            // perform X mirroring
            if ( mirrorX )
            {
                int offset = stride - rect.Width * pixelSize;

                // first pointer - points to the first line
                byte* ptr1 = (byte*) image.ImageData.ToPointer( );
                ptr1 += ( startY * stride + startX * pixelSize );
                // second pointer - points to the last line
                byte* ptr2 = (byte*) image.ImageData.ToPointer( );
                ptr2 += ( ( stopY - 1 ) * stride + startX * pixelSize );

                // temporary value for swapping
                byte v;

                // for each line
                for ( int y = startY, halfStopY = startY + ( height >> 1 ); y < halfStopY; y++ )
                {
                    // for each pixel
                    for ( int x = startXInBytes; x < stopXInBytes; x++, ptr1++, ptr2++ )
                    {
                        // swap values
                        v = *ptr1;
                        *ptr1 = *ptr2;
                        *ptr2 = v;
                    }
                    ptr1 += offset;
                    ptr2 += offset - stride - stride;
                }
            }
        }