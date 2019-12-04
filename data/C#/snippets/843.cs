[RequireModulePermission("PTNRUSER")]
        public static PartnerEditTDS GetPartnerDetails(Int64 APartnerKey, bool AWithAddressDetails, bool AWithSubscriptions, bool AWithRelationships)
        {
            PartnerEditTDS MainDS = new PartnerEditTDS();

            TDBTransaction Transaction = DBAccess.GDBAccessObj.BeginTransaction(IsolationLevel.Serializable);

            PPartnerAccess.LoadByPrimaryKey(MainDS, APartnerKey, Transaction);

            if (MainDS.PPartner.Rows.Count == 0)
            {
                return null;
            }

            switch (MainDS.PPartner[0].PartnerClass)
            {
                case MPartnerConstants.PARTNERCLASS_FAMILY:
                    PFamilyAccess.LoadByPrimaryKey(MainDS, APartnerKey, Transaction);
                    break;

                case MPartnerConstants.PARTNERCLASS_PERSON:
                    PPersonAccess.LoadByPrimaryKey(MainDS, APartnerKey, Transaction);
                    break;

                case MPartnerConstants.PARTNERCLASS_CHURCH:
                    PChurchAccess.LoadByPrimaryKey(MainDS, APartnerKey, Transaction);
                    break;

                case MPartnerConstants.PARTNERCLASS_ORGANISATION:
                    POrganisationAccess.LoadByPrimaryKey(MainDS, APartnerKey, Transaction);
                    break;
            }

            if (AWithAddressDetails)
            {
                PPartnerLocationAccess.LoadViaPPartner(MainDS, APartnerKey, Transaction);
                PLocationAccess.LoadViaPPartner(MainDS, APartnerKey, Transaction);
            }

            if (AWithRelationships)
            {
                PPartnerRelationshipAccess.LoadViaPPartnerPartnerKey(MainDS, APartnerKey, Transaction);
            }

            if (AWithSubscriptions)
            {
                PSubscriptionAccess.LoadViaPPartnerPartnerKey(MainDS, APartnerKey, Transaction);
            }

            DBAccess.GDBAccessObj.RollbackTransaction();

            return null;
        }