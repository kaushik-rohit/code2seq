internal void Init(List<Dimension> allDimensions, Dimension dimensionToShow)
        {
            ShowedDimension = dimensionToShow;

            //set dimension
            List<Dimension> temp = new List<Dimension>();
            Dimension emptyDimension = new Dimension("no selection", toTable: "no selection", isEmptyDimension: true);

            temp.Add(emptyDimension);
            temp.AddRange(allDimensions);

            DimensionComboBox.ItemsSource = temp;
            DimensionComboBox.DisplayMemberPath = "Dimensionname";
            DimensionComboBox.SelectedItem = temp[temp.IndexOf(dimensionToShow)];

            //set level
            DimensionLevelComboBox.ItemsSource = dimensionToShow.GetLevel();
            DimensionLevelComboBox.DisplayMemberPath = "Level";
            DimensionLevelComboBox.SelectedIndex = DimensionLevelComboBox.Items.Count - 1;//select highest level by default

            //set aggregation
            temp = new List<Dimension>();
            Dimension emptyLevel = new Dimension("empty level", toTable: "no aggregation", isEmptyDimension: true);

            temp.Add(emptyLevel);
            temp.AddRange(dimensionToShow.GetLevel());

            DimensionAggregationComboBox.Items.Clear();

            //exclude the all level dimension for aggregation level combobox
            foreach (Dimension dim in temp)
            {
                if (dim != temp.Last())
                {
                    DimensionAggregationComboBox.Items.Add(dim);
                }
            }

            DimensionAggregationComboBox.DisplayMemberPath = "Level";
            DimensionAggregationComboBox.SelectedIndex = 0;

            //set content
            var showedLevel = (Dimension)DimensionLevelComboBox.SelectedItem;

            DimensionContentFilter.ItemsSource = showedLevel.DimensionContentsList;
            DimensionContentFilter.DisplayMemberPath = "content";
            DimensionContentFilter.SelectAll();

            DimensionContentSearch.Clear();
        }