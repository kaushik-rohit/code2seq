[ActiveEvent (Name = "markdown2html")]
        [ActiveEvent (Name = "p5.markdown.markdown2html")]
        public static void markdown2html (ApplicationContext context, ActiveEventArgs e)
        {
            // Making sure we clean up and remove all arguments passed in after execution
            using (new ArgsRemover (e.Args, false)) {

                // Assumes there's only one document, or creates one result of it.
                var md = XUtil.Single<string> (context, e.Args);

                // Making sure we correctly resolve URLs, if user specified a [root-url] argument.
                var root = e.Args.GetExChildValue ("root-url", context, "");
                CommonMarkSettings settings = CommonMarkSettings.Default;
                if (root != "") {

                    // Unrolling path.
                    root = context.RaiseEvent ("p5.io.unroll-path", new Node ("", root)).Get<string> (context);

                    // To make sure we don't change global settings.
                    settings = settings.Clone ();
                    settings.UriResolver = delegate (string arg) {
                        if (arg.StartsWithEx ("http://") || arg.StartsWithEx ("https://"))
                            return arg;
                        return root + arg.TrimStart ('/');
                    };
                }

                // Doing actual conversion.
                e.Args.Value = CommonMarkConverter.Convert (md, settings);
            }
        }