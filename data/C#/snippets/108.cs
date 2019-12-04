public List<SysException> GetByParam(string id, string order, string sort, string search)
        {
            IQueryable<SysException> queryData = repository.DaoChuData(db, order, sort, search);
            
            return queryData.ToList();
        }