public void Delete(int country_ID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteC07_Country_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID1", country_ID1).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }