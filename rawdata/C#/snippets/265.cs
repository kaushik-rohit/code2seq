[Test]
        [Category("Priority1")]
        public void BedFormatterValidateParseLongStartEndFormatRangeGroupFileName()
        {
            FormatterGeneralTestCases(Constants.LongStartEndBedNodeName,
                                      AdditionalParameters.ParseRangeGroup);
        }