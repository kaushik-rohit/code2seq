[Test]
        [Category("Priority1")]
        public void BedParserValidateThreeChromosomeParseRangeFileName()
        {
            ParserGeneralTestCases(Constants.ThreeChromoBedNodeName,
                                   AdditionalParameters.RangeFileName);
        }