public static IEnumerable<IEnumerable<T>> Segment<T>(this IEnumerable<T> source, Func<T, bool> newSegmentPredicate)
        {
            if (newSegmentPredicate == null) throw new ArgumentNullException(nameof(newSegmentPredicate));

            return Segment(source, (curr, prev, index) => newSegmentPredicate(curr));
        }