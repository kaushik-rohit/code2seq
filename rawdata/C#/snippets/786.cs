bool CreateSharedParameter(
      Document doc,
      Category cat,
      int nameSuffix,
      bool typeParameter )
    {
      Application app = doc.Application;

      Autodesk.Revit.Creation.Application ca
        = app.Create;

      // get or set the current shared params filename:

      string filename
        = app.SharedParametersFilename;

      if( 0 == filename.Length )
      {
        string path = _filename;
        StreamWriter stream;
        stream = new StreamWriter( path );
        stream.Close();
        app.SharedParametersFilename = path;
        filename = app.SharedParametersFilename;
      }

      // get the current shared params file object:

      DefinitionFile file
        = app.OpenSharedParameterFile();

      if( null == file )
      {
        Util.ErrorMsg(
          "Error getting the shared params file." );

        return false;
      }

      // get or create the shared params group:

      DefinitionGroup group
        = file.Groups.get_Item( _groupname );

      if( null == group )
      {
        group = file.Groups.Create( _groupname );
      }

      if( null == group )
      {
        Util.ErrorMsg(
          "Error getting the shared params group." );

        return false;
      }

      // set visibility of the new parameter:

      // Category.AllowsBoundParameters property
      // indicates if a category can have user-visible
      // shared or project parameters. If it is false,
      // it may not be bound to visible shared params
      // using the BindingMap. Please note that
      // non-user-visible parameters can still be
      // bound to these categories.

      bool visible = cat.AllowsBoundParameters;

      // get or create the shared params definition:

      string defname = _defname + nameSuffix.ToString();

      Definition definition = group.Definitions.get_Item(
        defname );

      if( null == definition )
      {
        //definition = group.Definitions.Create( defname, _deftype, visible ); // 2014

        ExternalDefinitionCreationOptions opt
          = new ExternalDefinitionCreationOptions(
            defname, _deftype );

        opt.Visible = visible;

        definition = group.Definitions.Create( opt ); // 2015
      }
      if( null == definition )
      {
        Util.ErrorMsg(
          "Error creating shared parameter." );

        return false;
      }

      // create the category set containing our category for binding:

      CategorySet catSet = ca.NewCategorySet();
      catSet.Insert( cat );

      // bind the param:

      try
      {
        Binding binding = typeParameter
          ? ca.NewTypeBinding( catSet ) as Binding
          : ca.NewInstanceBinding( catSet ) as Binding;

        // we could check if it is already bound,
        // but it looks like insert will just ignore
        // it in that case:

        doc.ParameterBindings.Insert( definition, binding );

        // we can also specify the parameter group here:

        //doc.ParameterBindings.Insert( definition, binding,
        //  BuiltInParameterGroup.PG_GEOMETRY );

        Debug.Print(
          "Created a shared {0} parameter '{1}' for the {2} category.",
          ( typeParameter ? "type" : "instance" ),
          defname, cat.Name );
      }
      catch( Exception ex )
      {
        Util.ErrorMsg( string.Format(
          "Error binding shared parameter to category {0}: {1}",
          cat.Name, ex.Message ) );
        return false;
      }
      return true;
    }