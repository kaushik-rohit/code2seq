static void SetInstanceParamVaryBetweenGroupsBehaviour(
      Document doc,
      Guid guid,
      bool allowVaryBetweenGroups = true )
    {
      try // last resort
      {
        SharedParameterElement sp
          = SharedParameterElement.Lookup( doc, guid );

        // Should never happen as we will call 
        // this only for *existing* shared param.

        if( null == sp ) return;

        InternalDefinition def = sp.GetDefinition();

        if( def.VariesAcrossGroups != allowVaryBetweenGroups )
        {
          // Must be within an outer transaction!

          def.SetAllowVaryBetweenGroups( doc, allowVaryBetweenGroups );
        }
      }
      catch { } // ideally, should report something to log...
    }