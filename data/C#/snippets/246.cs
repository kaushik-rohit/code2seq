[Test]
        [Category("Priority1")]
        public void BedParserValidateOneLineParseRangeGroupFileName()
        {
            ParserGeneralTestCases(Constants.OneLineBedNodeName,
                                   AdditionalParameters.RangeGroupFileName);
        }