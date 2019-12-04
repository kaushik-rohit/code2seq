protected override void Execute(RuleContext context)
        {
            var value = (string) context.InputPropertyValues[PrimaryProperty];
            if (string.IsNullOrEmpty(value)) return;

            var newValue = value.Trim();
            var r = new Regex(@"\s+");
            newValue = r.Replace(newValue, @" ");
            context.AddOutValue(PrimaryProperty, newValue);
        }