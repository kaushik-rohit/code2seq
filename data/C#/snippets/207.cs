public WrappedObject<T> CheckOut()
        {
            if (_disposed)
                throw new ObjectDisposedException("ObjectPoolBase");

            // It's key that this CheckOut always, always, uses a pooled object
            // from the oldest available segment. This will help keep the "newer" 
            // segments from being used - which in turn, makes them eligible
            // for deletion.


            lock (_syncRoot)
            {
                ObjectPoolSegment<T> targetSegment = null;

                // find the oldest segment that has items available for checkout
                for (int i = 0; i < _activeSegment; i++)
                {
                    ObjectPoolSegment<T> segment;
                    if (_segments.TryGetValue(i, out segment) == true)
                    {
                        if (segment.AvailableItems > 0)
                        {
                            targetSegment = segment;
                            break;
                        }
                    }
                }

                if (targetSegment == null)
                {
                    // We couldn't find a sigment that had any available space in it,
                    // so it's time to create a new segment.

                    // Before creating the segment, do a GC to make sure the heap 
                    // is compacted.
                    if (_gc) GC.Collect();

                    targetSegment = CreateSegment(true);

                    if (_gc) GC.Collect();

                    _segments.Add(targetSegment.SegmentNumber, targetSegment);
                }

                WrappedObject<T> obj = new WrappedObject<T>(this, targetSegment, targetSegment.CheckOutObject());
                return obj;
            }
        }