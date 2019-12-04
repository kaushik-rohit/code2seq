public void Run(AdWordsUser user, long adGroupId)
        {
            using (AdGroupCriterionService adGroupCriterionService =
                (AdGroupCriterionService) user.GetService(AdWordsService.v201802
                    .AdGroupCriterionService))
            {
                List<AdGroupCriterionOperation> operations = new List<AdGroupCriterionOperation>();

                foreach (string keywordText in KEYWORDS)
                {
                    // Create the keyword.
                    Keyword keyword = new Keyword
                    {
                        text = keywordText,
                        matchType = KeywordMatchType.BROAD
                    };

                    // Create the biddable ad group criterion.
                    BiddableAdGroupCriterion keywordCriterion = new BiddableAdGroupCriterion
                    {
                        adGroupId = adGroupId,
                        criterion = keyword,

                        // Optional: Set the user status.
                        userStatus = UserStatus.PAUSED,

                        // Optional: Set the keyword destination url.
                        finalUrls = new UrlList()
                        {
                            urls = new string[]
                            {
                                "http://example.com/mars/cruise/?kw=" +
                                HttpUtility.UrlEncode(keywordText)
                            }
                        }
                    };

                    // Create the operations.
                    AdGroupCriterionOperation operation = new AdGroupCriterionOperation
                    {
                        @operator = Operator.ADD,
                        operand = keywordCriterion
                    };

                    operations.Add(operation);
                }

                try
                {
                    // Create the keywords.
                    AdGroupCriterionReturnValue retVal =
                        adGroupCriterionService.mutate(operations.ToArray());

                    // Display the results.
                    if (retVal != null && retVal.value != null)
                    {
                        foreach (AdGroupCriterion adGroupCriterion in retVal.value)
                        {
                            // If you are adding multiple type of criteria, then you may need to
                            // check for
                            //
                            // if (adGroupCriterion is Keyword) { ... }
                            //
                            // to identify the criterion type.
                            Console.WriteLine(
                                "Keyword with ad group id = '{0}', keyword id = '{1}', text = " +
                                "'{2}' and match type = '{3}' was created.",
                                adGroupCriterion.adGroupId, adGroupCriterion.criterion.id,
                                (adGroupCriterion.criterion as Keyword).text,
                                (adGroupCriterion.criterion as Keyword).matchType);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No keywords were added.");
                    }
                }
                catch (Exception e)
                {
                    throw new System.ApplicationException("Failed to create keywords.", e);
                }
            }
        }