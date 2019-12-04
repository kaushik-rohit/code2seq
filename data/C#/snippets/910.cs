public DataTable PesquisaRelatorioPorTipo(byte rea_tipo, int currentPage, int pageSize, out int totalRecords)
        {
            QuerySelectStoredProcedure qs = new QuerySelectStoredProcedure("NEW_CLS_RelatorioAtendimento_SelecionaPorTipo", _Banco);

            try
            {
                #region Parâmetros

                Param = qs.NewParameter();
                Param.ParameterName = "@rea_tipo";
                Param.DbType = DbType.Byte;
                Param.Size = 2;
                if (rea_tipo > 0)
                {
                    Param.Value = rea_tipo;
                }
                else
                {
                    Param.Value = DBNull.Value;
                }
                qs.Parameters.Add(Param);

                #endregion

                totalRecords = qs.Execute(currentPage, pageSize);

                return qs.Return;
            }
            finally
            {
                qs.Parameters.Clear();
            }
        }