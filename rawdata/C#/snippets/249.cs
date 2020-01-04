[Test]
        [Category("Priority1")]
        public void BedFormatterValidateParseSmallSizeFormatRangeTextWriter()
        {
            FormatterGeneralTestCases(Constants.SmallSizeBedNodeName,
                                      AdditionalParameters.ParseRangeTextWriter);
        }