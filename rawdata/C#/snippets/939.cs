public override void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("LogisticFunction", this.LogisticFunction.GetType().Name);

            Xml.Write<Descriptor>(writer, this.Descriptor);
            Xml.Write<Vector>(writer, this.Theta);
            Xml.Write<int>(writer, this.PolynomialFeatures);
        }