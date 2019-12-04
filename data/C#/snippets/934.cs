internal void AddToExpression()
    {
      var vm = FeatureSelectionVM;
      if (vm.WhereClause == "")
        vm.WhereClause = GetFormattedExpression(vm.SelectedRow);
      else
        vm.WhereClause += string.Format(" AND {0}", GetFormattedExpression(vm.SelectedRow));
    }