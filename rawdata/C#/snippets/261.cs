[Test]
        [Category("Priority1")]
        public void BedFormatterValidateParseThreeChromosomeFormatRangeGroupFileName()
        {
            FormatterGeneralTestCases(Constants.ThreeChromoBedNodeName,
                                      AdditionalParameters.ParseRangeGroup);
        }