public static T CreateSingleInstanceControl<T>()
			where T: Control
		{
			T control = (T)Activator.CreateInstance<T>();

			FakePage page = new FakePage();
			page.Controls.Add(control);
			control.Page = page;

			page.Items[typeof(T)] = control;

			return control;
		}