[Test]
        [Category("Priority1")]
        public void BedFormatterValidateParseOneLineFormatRangeGroupFileName()
        {
            FormatterGeneralTestCases(Constants.OneLineBedNodeName,
                                      AdditionalParameters.ParseRangeGroup);
        }