private void LocalRezObject(IClientAPI remoteclient, UUID itemid, Vector3 rayend, Vector3 raystart, 
            UUID raytargetid, byte bypassraycast, bool rayendisintersection, bool rezselected, bool removeitem, 
            UUID fromtaskid)
        {
            int differenceX = (int)m_virtScene.RegionInfo.RegionLocX - (int)m_rootScene.RegionInfo.RegionLocX;
            int differenceY = (int)m_virtScene.RegionInfo.RegionLocY - (int)m_rootScene.RegionInfo.RegionLocY;
            rayend.X += differenceX * (int)Constants.RegionSize;
            rayend.Y += differenceY * (int)Constants.RegionSize;
            raystart.X += differenceX * (int)Constants.RegionSize;
            raystart.Y += differenceY * (int)Constants.RegionSize;

            m_rootScene.RezObject(remoteclient, itemid, rayend, raystart, raytargetid, bypassraycast,
                                  rayendisintersection, rezselected, removeitem, fromtaskid);
        }