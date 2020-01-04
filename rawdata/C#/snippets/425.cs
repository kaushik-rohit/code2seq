private bool IsWithinSuitcaseTree(UUID principalID, UUID folderID)
        {
            XInventoryFolder suitcase = GetSuitcaseXFolder(principalID);

            if (suitcase == null)
            {
                m_log.WarnFormat("[HG SUITCASE INVENTORY SERVICE]: User {0} does not have a Suitcase folder", principalID);
                return false;
            }

            List<XInventoryFolder> tree = new List<XInventoryFolder>();
            tree.Add(suitcase); // Warp! the tree is the real root folder plus the children of the suitcase folder
            tree.AddRange(GetFolderTree(principalID, suitcase.folderID));

            // Also add the Current Outfit folder to the list of available folders
            XInventoryFolder folder = GetCurrentOutfitXFolder(principalID);
            if (folder != null)
                tree.Add(folder);

            XInventoryFolder f = tree.Find(delegate(XInventoryFolder fl)
            {
                return (fl.folderID == folderID);
            });

            return (f != null);
        }