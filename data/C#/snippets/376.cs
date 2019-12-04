private void InitOptions()
    {
        // Clear items
        if (drpCategoryType.Items.Count == 0)
        {
            // Add items
            drpCategoryType.Items.Add(new ListItem(GetString("general.selectall"), FILTER_ALL));
            AddItem(OptionCategoryTypeEnum.Products);
            AddItem(OptionCategoryTypeEnum.Attribute);
            AddItem(OptionCategoryTypeEnum.Text);
        }
    }