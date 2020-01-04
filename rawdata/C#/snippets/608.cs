[TestMethod()]
        [TestCategory(TestUtilities.UnitTestCategory)]
        public void MarkedSpanStart_IXliffDataProvider_GetXliffAttributes()
        {
            for (int i = 0; i < 2; i++)
            {
                IEnumerable<IAttributeDataProvider> attributes;
                bool refEquals;

                switch (i)
                {
                    case 0:
                        Console.WriteLine("Test with default element.");
                        break;

                    case 1:
                        Console.WriteLine("Test with modified element.");
                        this._element.FormatStyle = FormatStyleValue.Anchor;
                        this._element.Id = "id";
                        this._element.Reference = "ref";
                        this._element.SizeRestriction = "sizeRestriction";
                        this._element.StorageRestriction = "storageRestriction";
                        this._element.SubFormatStyle.Add("format", "style");
                        this._element.Translate = false;
                        this._element.Type = "type";
                        this._element.Value = "value";
                        break;

                    default:
                        Assert.Fail("Iteration not expected.");
                        break;
                }

                attributes = this._provider.GetXliffAttributes();
                Assert.IsNotNull(attributes, "Attributes are null.");
                Assert.AreEqual(9, attributes.Count(), "Number of attributes is incorrect.");

                Assert.AreEqual(this._element.Id,
                                attributes.First((a) => a.LocalName == AttributeNames.Id).Value,
                                "Id is incorrect.");
                Assert.AreEqual(this._element.FormatStyle,
                                attributes.First((a) => a.LocalName == FsXmlNames.AttributeNames.FormatStyle).Value,
                                "FormatStyle is incorrect.");
                Assert.AreEqual(this._element.Reference,
                                attributes.First((a) => a.LocalName == AttributeNames.ReferenceAbbreviated).Value,
                                "Reference is incorrect.");
                Assert.AreEqual(this._element.SizeRestriction,
                                attributes.First((a) => a.LocalName == SizeXmlNames.AttributeNames.SizeRestriction).Value,
                                "SizeRestriction is incorrect.");
                Assert.AreEqual(this._element.StorageRestriction,
                                attributes.First((a) => a.LocalName == SizeXmlNames.AttributeNames.StorageRestriction).Value,
                                "StorageRestriction is incorrect.");
                refEquals = object.ReferenceEquals(this._element.SubFormatStyle,
                                                   attributes.First((a) => a.LocalName == FsXmlNames.AttributeNames.SubFormatStyle).Value);
                Assert.IsTrue(refEquals, "SubFormatStyle is incorrect.");
                Assert.AreEqual(this._element.Translate,
                                attributes.First((a) => a.LocalName == AttributeNames.Translate).Value,
                                "Translate is incorrect.");
                Assert.AreEqual(this._element.Type,
                                attributes.First((a) => a.LocalName == AttributeNames.Type).Value,
                                "Type is incorrect.");
                Assert.AreEqual(this._element.Value,
                                attributes.First((a) => a.LocalName == AttributeNames.Value).Value,
                                "Value is incorrect.");
            }
        }