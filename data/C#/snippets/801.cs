[Transactional(TransactionalTypes.TransactionScope)]
        protected void DataPortal_Delete(int continent_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
                using (var cmd = new SqlCommand("DeleteE02_Continent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID", continent_ID).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd, continent_ID);
                    OnDeletePre(args);
                    cmd.ExecuteNonQuery();
                    OnDeletePost(args);
                }
            }
            // removes all previous references to children
            LoadProperty(E03_Continent_SingleObjectProperty, DataPortal.CreateChild<E03_Continent_Child>());
            LoadProperty(E03_Continent_ASingleObjectProperty, DataPortal.CreateChild<E03_Continent_ReChild>());
            LoadProperty(E03_SubContinentObjectsProperty, DataPortal.CreateChild<E03_SubContinentColl>());
        }