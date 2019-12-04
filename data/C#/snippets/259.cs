[Test]
        [Category("Priority1")]
        public void BedFormatterValidateParseThreeChromosomeFormatRangeFileName()
        {
            FormatterGeneralTestCases(Constants.ThreeChromoBedNodeName,
                                      AdditionalParameters.ParseRange);
        }