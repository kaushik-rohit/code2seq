public override void ReadXml(XmlReader reader)
        {
            reader.MoveToContent();

            var sigmoid = Ject.FindType(reader.GetAttribute("LogisticFunction"));
            this.LogisticFunction = (IFunction)Activator.CreateInstance(sigmoid);

            reader.ReadStartElement();

            this.Descriptor = Xml.Read<Descriptor>(reader);
            this.Theta = Xml.Read<Vector>(reader);
            this.PolynomialFeatures = Xml.Read<int>(reader);
        }