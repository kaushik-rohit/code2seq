[Test]
        [Category("Priority1")]
        public void BedFormatterValidateParseLongStartEndFormatRangeFileName()
        {
            FormatterGeneralTestCases(Constants.LongStartEndBedNodeName,
                                      AdditionalParameters.ParseRange);
        }