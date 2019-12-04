public void ToEPL(TextWriter writer)
        {
            writer.Write("create");
            if (TypeDefinition != null)
            {
                TypeDefinition.Value.Write(writer);
            }
            writer.Write(" schema ");
            writer.Write(SchemaName);
            writer.Write(" as ");
            if ((Types != null) && (Types.IsNotEmpty())) {
                String delimiter = "";
                foreach (String type in Types) {
                    writer.Write(delimiter);
                    writer.Write(type);
                    delimiter = ", ";
                }
            }
            else {
                writer.Write("(");
                String delimiter = "";
                foreach (SchemaColumnDesc col in Columns) {
                    writer.Write(delimiter);
                    col.ToEPL(writer);
                    delimiter = ", ";
                }
                writer.Write(")");
            }
    
            if ((Inherits != null) && (Inherits.IsNotEmpty())) {
                writer.Write(" inherits ");
                String delimiter = "";
                foreach (String name in Inherits) {
                    writer.Write(delimiter);
                    writer.Write(name);
                    delimiter = ", ";
                }
            }
    
            if (StartTimestampPropertyName != null) {
                writer.Write(" starttimestamp ");
                writer.Write(StartTimestampPropertyName);
            }
            if (EndTimestampPropertyName != null) {
                writer.Write(" endtimestamp ");
                writer.Write(EndTimestampPropertyName);
            }
    
            if ((CopyFrom != null) && (CopyFrom.IsNotEmpty())) {
                writer.Write(" copyFrom ");
                String delimiter = "";
                foreach (String name in CopyFrom) {
                    writer.Write(delimiter);
                    writer.Write(name);
                    delimiter = ", ";
                }
            }
        }