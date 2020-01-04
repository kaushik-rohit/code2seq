[RequireModulePermission("PTNRUSER")]
        public static bool SavePartner(PartnerEditTDS AMainDS, out TVerificationResultCollection AVerificationResult)
        {
            if (!PAcquisitionAccess.Exists(MPartnerConstants.PARTNERIMPORT_AQUISITION_DEFAULT, null))
            {
                PAcquisitionTable AcqTable = new PAcquisitionTable();
                PAcquisitionRow row = AcqTable.NewRowTyped();
                row.AcquisitionCode = MPartnerConstants.PARTNERIMPORT_AQUISITION_DEFAULT;
                row.AcquisitionDescription = Catalog.GetString("Imported Data");
                AcqTable.Rows.Add(row);

                TVerificationResultCollection VerificationResult;
                TDBTransaction Transaction = DBAccess.GDBAccessObj.BeginTransaction(IsolationLevel.Serializable);

                PAcquisitionAccess.SubmitChanges(AcqTable, Transaction, out VerificationResult);

                DBAccess.GDBAccessObj.CommitTransaction();
            }

            return PartnerEditTDSAccess.SubmitChanges(AMainDS, out AVerificationResult) == TSubmitChangesResult.scrOK;
        }