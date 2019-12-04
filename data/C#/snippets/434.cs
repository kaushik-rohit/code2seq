public static ICheckLink<ICheck<float>> IsFinite(this ICheck<float> check)
        {
            ExtensibilityHelper.BeginCheck(check).
                SetSutName("float value").
                FailWhen(float.IsInfinity, "The {0} is an infinite number whereas it must not.").
                OnNegate("The {0} is a finite number whereas it must not.").
                EndCheck();
            return ExtensibilityHelper.BuildCheckLink(check);
        }