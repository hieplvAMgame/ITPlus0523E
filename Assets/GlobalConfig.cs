using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalConfig : Singleton<GlobalConfig>
{
    public List<CharacterScriptableObj> characterDatas = new List<CharacterScriptableObj>();
    public List<int> formularValueAttribute = new List<int>();
    private void Awake()
    {
        //SceneLoader.Instance.LoadScene("Level1", ()=>GameManager.Instance.GamePrepare());
    }
}
