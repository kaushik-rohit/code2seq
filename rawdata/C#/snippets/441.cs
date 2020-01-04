public static bool Init()
        {
            if (m_instance != null)
            {
                Debug.LogError("Second initialisation not allowed");
                return false;
            }
            else
            {
                m_instance = new SceneMgr();
                return m_instance.open();
            }
        }