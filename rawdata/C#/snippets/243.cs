[Test]
        [Category("Priority1")]
        public void BedParserValidateOneLineParseRangeTextReader()
        {
            ParserGeneralTestCases(Constants.OneLineBedNodeName,
                                   AdditionalParameters.RangeTextReader);
        }