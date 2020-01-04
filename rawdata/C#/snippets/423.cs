[Test]
		[Ignore]
		public async Task MixedAttributeHasValueTrue()
		{
			await Init ();
			Assert.IsTrue(SchemaTestFixtureBase.Contains(mixedAttributeValues, "true"),
			              "Attribute value 'true' missing.");
		}