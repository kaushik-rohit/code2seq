public void LoadScene(string sceneName)
        {
            
            SceneInfo sceneInfo = new SceneInfo(sceneName);
            LoadScene(sceneInfo);
            GameMgr.Singleton.CurrentState.SceneInfo.LoadSubscene(sceneName);

        }