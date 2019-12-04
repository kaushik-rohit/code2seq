private static List<CategoryInfo> GetCategoryTree(int parentid, List<CategoryInfo> listcate, int level)
        {
            var listAll = _categories;//这里面从内存读数据，所以不会遍历查库，暂时查库，要不他会将遍历后的值传给_categories
            if (listAll.FindAll(c => !string.IsNullOrEmpty(c.TreeChar)).Count>0) {
                _categories = DatabaseProvider.Instance.GetCategoryList();
                listAll = _categories;
            }
            var treelist = new List<CategoryInfo>();


            foreach (var cate in listcate)
            {
                if (cate.ParentId == parentid)
                {
                    cate.Depth = level;

                    if (level > 0)
                    {
                        for (int i = 0; i < level; i++)
                        {
                            cate.TreeChar += " └ ";//父类的TreeChar加当前的TreeChar
                        }

                    }
                    else
                    {
                        cate.Path = cate.CategoryId.ToString();//当前cateid
                        cate.TreeChar = "";

                    }
                    treelist.Add(cate);
                    //如果它还有子分类 则继续递归
                    var childlist = listAll.FindAll(c => c.ParentId == cate.CategoryId);
                    if (childlist.Count > 0)
                    {
                        foreach (var child in GetCategoryTree(cate.CategoryId, childlist, level + 1))
                        {
                            treelist.Add(child);
                        }
                    }
                }
            }
            return treelist;
        }