[Test]
        [Category("Priority1")]
        public void BedFormatterValidateParseOneLineFormatRangeTextWriter()
        {
            FormatterGeneralTestCases(Constants.OneLineBedNodeName,
                                      AdditionalParameters.RangeTextWriter);
        }