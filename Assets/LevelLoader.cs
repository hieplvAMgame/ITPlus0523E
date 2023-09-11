using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : Singleton<LevelLoader>
{
    private void Awake()
    {
        LoadScene(1);
    }
    public void LoadScene(int indexLevel)
    {
        SceneManager.LoadScene(indexLevel);
    }
}
