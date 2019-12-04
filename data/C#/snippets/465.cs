public Stream CorrectView(string virtualPath, Stream stream)
        {
            var reader = new StreamReader(stream, Encoding.UTF8);
            var view = reader.ReadToEnd();
            stream.Close();
            var ourStream = new MemoryStream();
            var writer = new StreamWriter(ourStream, Encoding.UTF8);

            var modelString = "";
            var modelPos = view.IndexOf("@model");
            if (modelPos != -1)
            {
                writer.Write(view.Substring(0, modelPos));
                var modelEndPos = view.IndexOfAny(new[] {'\r', '\n'}, modelPos);
                modelString = view.Substring(modelPos, modelEndPos - modelPos);
                view = view.Remove(0, modelEndPos);
            }

            writer.WriteLine("@using System.Web.Mvc");
            writer.WriteLine("@using System.Web.Mvc.Ajax");
            writer.WriteLine("@using System.Web.Mvc.Html");
            writer.WriteLine("@using System.Web.Routing");

            var basePrefix = "@inherits " + WebViewPageClassName;

            if (virtualPath.ToLower().Contains("_viewstart"))
                writer.WriteLine("@inherits System.Web.WebPages.StartPage");
            else if (modelString == "@model object")
                writer.WriteLine(basePrefix + "<dynamic>");
            else if (!string.IsNullOrEmpty(modelString))
                writer.WriteLine(basePrefix + "<" + modelString.Substring(7) + ">");
            else
                writer.WriteLine(basePrefix);

            // partial views should not have a layout
            if (!string.IsNullOrEmpty(LayoutPath) && !virtualPath.Contains("/_"))
            {
                writer.WriteLine(string.Format("@{{ Layout = \"{0}\"; }}", LayoutPath));
            }
            writer.Write(view);
            writer.Flush();
            ourStream.Position = 0;
            return ourStream;
        }