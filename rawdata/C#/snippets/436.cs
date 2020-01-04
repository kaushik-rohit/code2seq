public static ICheckLink<ICheck<float>> IsCloseTo(this ICheck<float> check, Double expected, Double within)
        {
            var range = new RangeBlock(expected, within);
            ExtensibilityHelper.BeginCheck(check).
                FailWhen((sut) => !range.IsInRange(sut), "The {0} is outside the expected value range.").
                DefineExpectedValue(range).
                OnNegate("The {0} is within the expected range, whereas it must not.").
                EndCheck();
            return ExtensibilityHelper.BuildCheckLink(check);
        }