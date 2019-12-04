protected override void OnTextChanged(EventArgs e)
		{
			m_tmrValidator.Stop();
			m_tmrValidator.Start();

			base.OnTextChanged(e);
			m_booUpdatingCode = true;
			ViewModel.Code = Document.TextContent;
			m_booUpdatingCode = false;
		}