public static IMaxNode Create(object baseNode)
      {
         Throw.IfNull(baseNode, "baseNode");

         if (Factories != null)
         {
            foreach (IMaxNodeFactory factory in Factories)
            {
               IMaxNode node = factory.CreateMaxNode(baseNode);
               if (node != null)
                  return node;
            }
         }

         throw new NotSupportedException("Cannot create a wrapper for object of type " + baseNode.GetType().Name);         
      }