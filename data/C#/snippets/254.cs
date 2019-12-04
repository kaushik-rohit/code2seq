[Test]
        [Category("Priority1")]
        public void BedFormatterValidateParseSmallSizeFormatRangeGroupTextWriter()
        {
            FormatterGeneralTestCases(Constants.SmallSizeBedNodeName,
                                      AdditionalParameters.ParseRangeGroupTextWriter);
        }