protected override void AddEnd( IRelationshipEnd relationshipEnd, EntityContainerEntitySet entitySet )
        {
            Debug.Assert( relationshipEnd != null );
            Debug.Assert( !_relationshipEnds.ContainsKey( relationshipEnd.Name ) );
            // we expect set to be null sometimes

            EntityContainerAssociationSetEnd end = new EntityContainerAssociationSetEnd( this );
            end.Role = relationshipEnd.Name;
            end.RelationshipEnd = relationshipEnd;

            end.EntitySet = entitySet;
            if ( end.EntitySet != null )
            {
                _relationshipEnds.Add( end.Role, end );
            }
        }