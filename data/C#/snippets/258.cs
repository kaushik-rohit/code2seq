[Test]
        [Category("Priority1")]
        public void BedFormatterValidateParseOneLineFormatRangeGroupTextWriter()
        {
            FormatterGeneralTestCases(Constants.OneLineBedNodeName,
                                      AdditionalParameters.RangeGroupTextWriter);
        }