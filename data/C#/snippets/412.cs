[Test]
		public async Task ChoiceDoesNotHaveNameAttribute()
		{
			await Init ();
			Assert.IsFalse(SchemaTestFixtureBase.Contains(choiceAttributes, "name"),
			               "Attribute name should not exist.");
		}