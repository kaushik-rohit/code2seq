[TestMethod]
        public void GetByTitle_WhenGetForNonExistingTitle_ShouldReturnNull()
        {
            // Arrange
            using (var testScope = SiteTestScope.PublishingSite())
            {
                var site = testScope.SiteCollection;

                using (var injectionScope = IntegrationTestServiceLocator.BeginLifetimeScope(site))
                {
                    var reusableContentHelper = injectionScope.Resolve<IReusableContentHelper>();

                    // Act
                    var copyright = reusableContentHelper.GetByTitle(site, "IDoNotExist");

                    // Assert
                    Assert.IsNull(copyright);
                }
            }
        }