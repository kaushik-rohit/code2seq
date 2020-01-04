public DataSet SelecionaRelatorio(int rea_id, Guid usu_id)
        {
            QuerySelectStoredProcedure qs = new QuerySelectStoredProcedure("NEW_CLS_RelatorioAtendimento_SelecionaRelatorio", _Banco);

            try
            {
                #region Parâmetros

                Param = qs.NewParameter();
                Param.ParameterName = "@rea_id";
                Param.DbType = DbType.Int32;
                Param.Size = 4;
                Param.Value = rea_id;
                qs.Parameters.Add(Param);

                Param = qs.NewParameter();
                Param.ParameterName = "@usu_id";
                Param.DbType = DbType.Guid;
                Param.Size = 16;
                Param.Value = usu_id;
                qs.Parameters.Add(Param);

                #endregion

                return qs.Execute_DataSet();
            }
            finally
            {
                qs.Parameters.Clear();
            }
        }