public static ICheckLink<ICheck<float>> IsNaN(this ICheck<float> check)
        {
            ExtensibilityHelper.BeginCheck(check).
                SetSutName("float value").
                FailWhen((sut) => !float.IsNaN(sut), "The {0} is a number whereas it must not.").
                OnNegate("The {0} is not a number (NaN) whereas it must.").
                EndCheck();
            return ExtensibilityHelper.BuildCheckLink(check);
        }