[TestMethod()]
        [TestCategory(TestUtilities.UnitTestCategory)]
        public void MarkedSpanStart_Defaults()
        {
            MarkedSpan spanParent;
            Unit unitParent;

            Console.WriteLine("Test with element child of unit with false Translate.");
            unitParent = new Unit();
            unitParent.Translate = false;
            this._element.Parent = unitParent;

            Assert.AreEqual(this._element.Translate,
                            unitParent.Translate,
                            "Translate is incorrect.");

            Console.WriteLine("Test with element child of unit with true Translate.");
            unitParent.Translate = true;

            Assert.AreEqual(this._element.Translate,
                            unitParent.Translate,
                            "Translate is incorrect.");

            Console.WriteLine("Test with element child of mrk with false Translate.");
            spanParent = new MarkedSpan();
            spanParent.Translate = false;
            spanParent.Parent = unitParent;
            this._element.Parent = spanParent;

            Assert.AreEqual(this._element.Translate,
                            spanParent.Translate,
                            "Translate is incorrect.");

            Console.WriteLine("Test with element child of mrk with true Translate.");
            spanParent.Translate = true;

            Assert.AreEqual(this._element.Translate,
                            spanParent.Translate,
                            "Translate is incorrect.");
        }