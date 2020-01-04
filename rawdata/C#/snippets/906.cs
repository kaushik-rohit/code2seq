public DataTable SelecionaRelatoriosRPDisciplina(Guid usu_id, long alu_id, long tud_id, bool apenasComPreenchimento)
        {
            QuerySelectStoredProcedure qs = new QuerySelectStoredProcedure("NEW_CLS_RelatorioAtendimento_SelecionaRelatoriosRPDisciplina", _Banco);

            try
            {
                #region Parâmetro

                Param = qs.NewParameter();
                Param.ParameterName = "@usu_id";
                Param.DbType = DbType.Guid;
                Param.Size = 16;
                Param.Value = usu_id;
                qs.Parameters.Add(Param);

                Param = qs.NewParameter();
                Param.ParameterName = "@alu_id";
                Param.DbType = DbType.Int64;
                Param.Size = 8;
                Param.Value = alu_id;
                qs.Parameters.Add(Param);

                Param = qs.NewParameter();
                Param.ParameterName = "@tud_id";
                Param.DbType = DbType.Int64;
                Param.Size = 8;
                Param.Value = tud_id;
                qs.Parameters.Add(Param);

                Param = qs.NewParameter();
                Param.ParameterName = "@apenasComPreenchimento";
                Param.DbType = DbType.Boolean;
                Param.Size = 1;
                Param.Value = apenasComPreenchimento;
                qs.Parameters.Add(Param);

                #endregion

                qs.Execute();

                return qs.Return;
            }
            finally
            {
                qs.Parameters.Clear();
            }
        }