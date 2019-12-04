internal void SetAsExpression()
    {
      var vm = FeatureSelectionVM;
      vm.WhereClause = GetFormattedExpression(vm.SelectedRow);
    }