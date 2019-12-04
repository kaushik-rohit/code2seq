[Test]
		public async Task ChoiceDoesNotHaveRefAttribute()
		{
			await Init ();
			Assert.IsFalse(SchemaTestFixtureBase.Contains(choiceAttributes, "ref"),
			               "Attribute ref should not exist.");
		}