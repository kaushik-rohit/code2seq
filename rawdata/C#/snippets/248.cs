[Test]
        [Category("Priority1")]
        public void BedFormatterValidateParseSmallSizeFormatRangeFileName()
        {
            FormatterGeneralTestCases(Constants.SmallSizeBedNodeName,
                                      AdditionalParameters.ParseRange);
        }