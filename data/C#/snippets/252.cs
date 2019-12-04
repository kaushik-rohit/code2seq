[Test]
        [Category("Priority1")]
        public void BedFormatterValidateParseSmallSizeFormatRangeGroupFileName()
        {
            FormatterGeneralTestCases(Constants.SmallSizeBedNodeName,
                                      AdditionalParameters.ParseRangeGroup);
        }