public static ArraySegment<byte> SerializeUnsafe<T>(T obj, IFormatterResolver resolver)
        {
            if (resolver == null) resolver = DefaultResolver;
            var formatter = resolver.GetFormatterWithVerify<T>();

            var buffer = InternalMemoryPool.GetBuffer();

            var len = formatter.Serialize(ref buffer, 0, obj, resolver);

            // return raw memory pool, unsafe!
            return new ArraySegment<byte>(buffer, 0, len);
        }