public static void Serialize<T>(Stream stream, T obj, IFormatterResolver resolver)
        {
            if (resolver == null) resolver = DefaultResolver;
            var formatter = resolver.GetFormatterWithVerify<T>();

            var buffer = InternalMemoryPool.GetBuffer();

            var len = formatter.Serialize(ref buffer, 0, obj, resolver);

            // do not need resize.
            stream.Write(buffer, 0, len);
        }