public IList<BlogTemplateViewModel> Execute(bool request)
        {
            BlogTemplateViewModel modelAlias = null;
            Layout layoutAlias = null;

            // Get current default template
            var option = optionService.GetDefaultOption();
            System.Guid? selectedTemplateId = null;
            if (option != null && (option.DefaultLayout != null || option.DefaultMasterPage != null))
            {
                selectedTemplateId = option.DefaultLayout != null ? option.DefaultLayout.Id : option.DefaultMasterPage.Id;
            }

            // Load templates
            var templates = UnitOfWork.Session
                .QueryOver(() => layoutAlias)
                .Where(() => !layoutAlias.IsDeleted)
                .SelectList(select => select
                    .Select(() => layoutAlias.Id).WithAlias(() => modelAlias.TemplateId)
                    .Select(() => layoutAlias.Name).WithAlias(() => modelAlias.Title)
                    .Select(() => layoutAlias.PreviewUrl).WithAlias(() => modelAlias.PreviewUrl))
                .TransformUsing(Transformers.AliasToBean<BlogTemplateViewModel>())
                .List<BlogTemplateViewModel>();

            var mainContentIdentifier = BlogModuleConstants.BlogPostMainContentRegionIdentifier.ToLowerInvariant();
            var compatibleLayouts = Repository.AsQueryable<Layout>()
                      .Where(
                          layout =>
                          layout.LayoutRegions.Count(region => !region.IsDeleted && !region.Region.IsDeleted).Equals(1)
                          || layout.LayoutRegions.Any(region => !region.IsDeleted && !region.Region.IsDeleted && region.Region.RegionIdentifier.ToLowerInvariant() == mainContentIdentifier))
                      .Select(layout => layout.Id)
                      .ToList();

            foreach (var id in compatibleLayouts)
            {
                templates
                    .Where(t => t.TemplateId == id)
                    .ToList()
                    .ForEach(t => t.IsCompatible = true);
            }

            var masterPagesQuery = Repository
                .AsQueryable<PageProperties>()
                .Where(page => page.IsMasterPage && !page.IsDeleted);

            if (configuration.Security.AccessControlEnabled)
            {
                var deniedPages = AccessControlService.GetDeniedObjects<PageProperties>();
                foreach (var deniedPageId in deniedPages)
                {
                    var id = deniedPageId;
                    if (id == selectedTemplateId)
                    {
                        continue;
                    }
                    masterPagesQuery = masterPagesQuery.Where(f => f.Id != id);
                }
            }

            masterPagesQuery
                .Select(
                    page =>
                    new BlogTemplateViewModel
                    {
                        TemplateId = page.Id,
                        Title = page.Title,
                        PreviewUrl =
                            page.Image != null
                                ? page.Image.PublicUrl
                                : page.FeaturedImage != null ? page.FeaturedImage.PublicUrl : page.SecondaryImage != null ? page.SecondaryImage.PublicUrl : null,
                        IsMasterPage = true,
                        IsCompatible =
                            page.PageContents.Count(pageContent =>
                                !pageContent.IsDeleted && !pageContent.Content.IsDeleted
                                    && pageContent.Content.ContentRegions.Count(contentRegion => !contentRegion.IsDeleted && !contentRegion.Region.IsDeleted
                                        && contentRegion.Region.RegionIdentifier.ToLowerInvariant() == mainContentIdentifier).Equals(1)
                            ).Equals(1)

                            || page.PageContents.Count(pageContent =>
                                !pageContent.IsDeleted && !pageContent.Content.IsDeleted
                                    && pageContent.Content.ContentRegions.Count(contentRegion => !contentRegion.IsDeleted && !contentRegion.Region.IsDeleted).Equals(1)
                            ).Equals(1)
                    })
                .ToList()
                .ForEach(templates.Add);

            // Select default template.
            if (selectedTemplateId.HasValue)
            {
                var defaultTemplate = templates.FirstOrDefault(t => t.TemplateId == selectedTemplateId);
                if (defaultTemplate != null)
                {
                    defaultTemplate.IsActive = true;
                }
            }

            return templates;
        }