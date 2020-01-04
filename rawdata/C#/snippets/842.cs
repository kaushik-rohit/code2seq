[RequireModulePermission("PTNRUSER")]
        public static Int64 NewPartnerKey(Int64 AFieldPartnerKey)
        {
            Int64 NewPartnerKey = TNewPartnerKey.GetNewPartnerKey(AFieldPartnerKey);

            TNewPartnerKey.SubmitNewPartnerKey(NewPartnerKey - NewPartnerKey % 1000000, NewPartnerKey, ref NewPartnerKey);
            return NewPartnerKey;
        }