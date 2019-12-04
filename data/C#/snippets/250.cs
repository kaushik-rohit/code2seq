[Test]
        [Category("Priority1")]
        public void BedFormatterValidateParseOneLineFormatRangeFileName()
        {
            FormatterGeneralTestCases(Constants.OneLineBedNodeName,
                                      AdditionalParameters.ParseRange);
        }