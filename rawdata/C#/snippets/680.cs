private void HandleEndElement( XmlReader reader )
        {
            Debug.Assert( reader != null );

            EntityContainerAssociationSetEnd end = new EntityContainerAssociationSetEnd( this );
            end.Parse( reader );

            if ( end.Role == null  )
            {
                // we will resolve the role name later and put it in the 
                // normal _relationshipEnds dictionary
                _rolelessEnds.Add( end );
                return;
            }

            if ( HasEnd( end.Role ) )
            {
                end.AddError( ErrorCode.InvalidName, EdmSchemaErrorSeverity.Error, reader,
                    System.Data.Entity.Strings.DuplicateEndName(end.Name ) );
                return;
            }

            _relationshipEnds.Add( end.Role, end );
        }