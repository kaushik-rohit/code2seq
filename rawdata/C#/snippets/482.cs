public static void SetCommonTags(IDicomAttributeProvider dicomAttributeProvider)
        {
            if (dicomAttributeProvider == null)
				throw new ArgumentNullException("dicomAttributeProvider");

			dicomAttributeProvider[DicomTags.CreationDate].SetNullValue();
			dicomAttributeProvider[DicomTags.PrinterName].SetNullValue();
			dicomAttributeProvider[DicomTags.Originator].SetNullValue();
			dicomAttributeProvider[DicomTags.PrintPriority].SetNullValue();
			dicomAttributeProvider[DicomTags.ExecutionStatus].SetNullValue();
			dicomAttributeProvider[DicomTags.ExecutionStatusInfo].SetNullValue();
        }