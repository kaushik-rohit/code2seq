[TestMethod]
        public void GetByTitle_WhenGetForOOTBReusableContent_ShouldReturnReusableContent()
        {
            // Arrange
            using (var testScope = SiteTestScope.PublishingSite())
            {
                var site = testScope.SiteCollection;

                using (var injectionScope = IntegrationTestServiceLocator.BeginLifetimeScope(site))
                {
                    var reusableContentHelper = injectionScope.Resolve<IReusableContentHelper>();

                    // Act
                    var copyright = reusableContentHelper.GetByTitle(site, "Copyright");

                    // Assert
                    Assert.IsNotNull(copyright);
                    Assert.AreEqual("None", copyright.Category);
                    Assert.IsTrue(copyright.IsAutomaticUpdate);
                    Assert.IsTrue(copyright.IsShowInRibbon);
                    Assert.IsTrue(copyright.Content.Contains("©"));
                }
            }
        }