[Test]
		public async Task ElementNameAttributeAppearsOnce()
		{
			await Init ();
			int nameAttributeCount = SchemaTestFixtureBase.GetItemCount(elementAttributes, "name");
			Assert.AreEqual(1, nameAttributeCount, "Should be only one name attribute.");
		}