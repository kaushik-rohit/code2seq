[TestMethod]
        public void GetAllReusableContentTitles_WhenGetAllOOTBTitles_ShouldReturn3Titles()
        {
            // Arrange
            using (var testScope = SiteTestScope.PublishingSite())
            {
                var site = testScope.SiteCollection;

                using (var injectionScope = IntegrationTestServiceLocator.BeginLifetimeScope(site))
                {
                    var reusableContentHelper = injectionScope.Resolve<IReusableContentHelper>();

                    // Act
                    var allOOTBTitles = reusableContentHelper.GetAllReusableContentTitles(site);

                    // Assert
                    Assert.AreEqual(3, allOOTBTitles.Count());
                    Assert.IsTrue(allOOTBTitles.Contains("Copyright"));
                }
            }
        }