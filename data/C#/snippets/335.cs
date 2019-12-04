protected override void Render([NotNull] HtmlTextWriter writer)
        {
            if (!this.Visible || this.DateTime == null)
            {
                return;
            }

            writer.Write(
                this.controlHtml.FormatWith(
                    this.AsDateTime.ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture),
                    this.Get<IDateTime>().Format(this.Format, this.DateTime)));
            writer.WriteLine();
        }