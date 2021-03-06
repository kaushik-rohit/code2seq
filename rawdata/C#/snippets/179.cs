private void LocalAddNewPrim(UUID ownerid, UUID groupid, Vector3 rayend, Quaternion rot, 
            PrimitiveBaseShape shape, byte bypassraycast, Vector3 raystart, UUID raytargetid, 
            byte rayendisintersection)
        {
            int differenceX = (int)m_virtScene.RegionInfo.RegionLocX - (int)m_rootScene.RegionInfo.RegionLocX;
            int differenceY = (int)m_virtScene.RegionInfo.RegionLocY - (int)m_rootScene.RegionInfo.RegionLocY;
            rayend.X += differenceX * (int)Constants.RegionSize;
            rayend.Y += differenceY * (int)Constants.RegionSize;
            raystart.X += differenceX * (int)Constants.RegionSize;
            raystart.Y += differenceY * (int)Constants.RegionSize;
            m_rootScene.AddNewPrim(ownerid, groupid, rayend, rot, shape, bypassraycast, raystart, raytargetid,
                                   rayendisintersection);
        }