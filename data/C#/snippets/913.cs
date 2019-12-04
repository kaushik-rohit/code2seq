public DataTable SelecionaPendenciasPorTurmaPeriodo(int tpc_id, long tur_id, long tud_id)
        {
            QuerySelectStoredProcedure qs = new QuerySelectStoredProcedure("NEW_CLS_RelatorioAtendimento_SelecionaPendenciasPorTurmaPeriodo", _Banco);

            try
            {
                Param = qs.NewParameter();
                Param.ParameterName = "@tpc_id";
                Param.DbType = DbType.Int32;
                Param.Size = 4;
                Param.Value = tpc_id;
                qs.Parameters.Add(Param);

                Param = qs.NewParameter();
                Param.ParameterName = "@tur_id";
                Param.DbType = DbType.Int64;
                Param.Size = 8;
                Param.Value = tur_id;
                qs.Parameters.Add(Param);

                Param = qs.NewParameter();
                Param.ParameterName = "@tud_id";
                Param.DbType = DbType.Int64;
                Param.Size = 8;
                Param.Value = tud_id;
                qs.Parameters.Add(Param);

                qs.Execute();

                return qs.Return;
            }
            finally
            {
                qs.Parameters.Clear();
            }
        }