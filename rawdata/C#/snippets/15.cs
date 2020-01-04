public void BuildEntityList()
            {
                EntityList.DisposeAllChildren();

                var storagelist = StorageEntity.StoredEntities;

                foreach (var entityuid in storagelist)
                {
                    var entity = IoCManager.Resolve<IEntityManager>().GetEntity(entityuid.Key);

                    var button = new EntityButton()
                    {
                        EntityuID = entityuid.Key
                    };
                    var container = button.GetChild("HBoxContainer");
                    button.ActualButton.OnToggled += OnItemButtonToggled;
                    //Name and Size labels set
                    container.GetChild<Label>("Name").Text = entity.Name;
                    container.GetChild<Control>("Control").GetChild<Label>("Size").Text = string.Format("{0}", entityuid.Value);

                    //Gets entity sprite and assigns it to button texture
                    if (entity.TryGetComponent(out ISpriteComponent sprite))
                    {
                        var view = container.GetChild<SpriteView>("SpriteView");
                        view.Sprite = sprite;
                    }

                    EntityList.AddChild(button);
                }

                //Sets information about entire storage container current capacity
                if (StorageEntity.StorageCapacityMax != 0)
                {
                    Information.Text = String.Format("Items: {0}, Stored: {1}/{2}", storagelist.Count, StorageEntity.StorageSizeUsed, StorageEntity.StorageCapacityMax);
                }
                else
                {
                    Information.Text = String.Format("Items: {0}", storagelist.Count);
                }
            }