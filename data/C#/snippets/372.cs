public static IIdentityServerBuilder AddValidationKey(this IIdentityServerBuilder builder, X509Certificate2 certificate)
        {
            if (certificate == null) throw new ArgumentNullException(nameof(certificate));

            var key = new X509SecurityKey(certificate);
            return builder.AddValidationKeys(key);
        }