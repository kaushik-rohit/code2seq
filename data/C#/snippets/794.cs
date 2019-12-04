public override void Update([NotNull] params object[] input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            if (!ValidateUpdateInput(input))
            {
                Enabled = false;
                return;
            }

            var budget = (IBudgetCurrencyContext) input[0];
            var statement = (StatementModel) input[1];
            var filter = (GlobalFilterCriteria) input[2];
            var ledger = (LedgerBook) input[3];

            if (statement == null || budget == null || filter == null || filter.Cleared || filter.BeginDate == null ||
                filter.EndDate == null)
            {
                Enabled = false;
                return;
            }

            Enabled = true;
            var totalMonths = filter.BeginDate.Value.DurationInMonths(filter.EndDate.Value);
            Maximum =
                Convert.ToDouble(budget.Model.Expenses.Where(s => s.Bucket is SavingsCommitmentBucket)
                    .Sum(s => s.Amount)) * totalMonths;

            var savingsToDate = CalculateSavingsToDateWithTrackedLedgers(statement, ledger);

            Value = Convert.ToDouble(savingsToDate);
            ToolTip = string.Format(CultureInfo.CurrentCulture, "You have saved {0:C} of your monthly goal {1:C}",
                savingsToDate, Maximum);

            if ((double) savingsToDate < 0.9 * Maximum)
            {
                ColourStyleName = WidgetWarningStyle;
            }
            else
            {
                ColourStyleName = this.standardStyle;
            }
        }