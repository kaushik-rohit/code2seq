public void LoadScene(SceneInfo info)
        {
            GameMgr.Singleton.CurrentState.SceneInfo.DestroyScene();
            GameMgr.Singleton.CurrentState.SceneInfo = info;
            GameMgr.Singleton.CurrentState.SceneInfo.ActivateScene();

        }