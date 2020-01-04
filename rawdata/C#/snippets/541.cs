public static IEnumerable<IEnumerable<T>> Segment<T>(this IEnumerable<T> source, Func<T, T, int, bool> newSegmentPredicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (newSegmentPredicate == null) throw new ArgumentNullException(nameof(newSegmentPredicate));

            return _(); IEnumerable<IEnumerable<T>> _()
            {
                var index = -1;
                using (var iter = source.GetEnumerator())
                {
                    var segment = new List<T>();
                    var prevItem = default(T);

                    // ensure that the first item is always part
                    // of the first segment. This is an intentional
                    // behavior. Segmentation always begins with
                    // the second element in the sequence.
                    if (iter.MoveNext())
                    {
                        ++index;
                        segment.Add(iter.Current);
                        prevItem = iter.Current;
                    }

                    while (iter.MoveNext())
                    {
                        ++index;
                        // check if the item represents the start of a new segment
                        var isNewSegment = newSegmentPredicate(iter.Current, prevItem, index);
                        prevItem = iter.Current;

                        if (!isNewSegment)
                        {
                            // if not a new segment, append and continue
                            segment.Add(iter.Current);
                            continue;
                        }
                        yield return segment; // yield the completed segment

                        // start a new segment...
                        segment = new List<T> { iter.Current };
                    }
                    // handle the case of the sequence ending before new segment is detected
                    if (segment.Count > 0)
                        yield return segment;
                }
            }
        }