using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : Singleton<SceneLoader>
{
    public GameObject loaderUI;
    public Slider progressImage;
    public Text txtValueProcess;
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    private void Start()
    {
        LoadScene("Home",()=> { });
    }
    public void LoadScene(string sceneName, System.Action callback = null)
    {
        loaderUI.SetActive(true);
        StartCoroutine(LoadSceneCoroutine(sceneName, callback));
    }

    private IEnumerator LoadSceneCoroutine(string sceneName, System.Action callback = null)
    {
        txtValueProcess.text = "0%";
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        asyncOperation.allowSceneActivation = false;
        float val = 0 ;
        while (!asyncOperation.isDone)
        {
            val = asyncOperation.progress / 2;
            progressImage.value = val;
            txtValueProcess.text = ((int)(val * 100)).ToString()+"%";
            yield return null;
            if (asyncOperation.progress >=.9f)
            {
                asyncOperation.allowSceneActivation = true;
            }
        }
        float timeLoad = 1f;
        while (timeLoad > 0)
        {
            timeLoad -= Time.fixedDeltaTime;
            val+= Time.fixedDeltaTime;
            progressImage.value = val;
            txtValueProcess.text = ((int)(progressImage.value * 100)).ToString()+"%";
            yield return new WaitForFixedUpdate();
        }
        progressImage.value = 1;
        txtValueProcess.text = "100%";
        yield return new WaitForSeconds(.2f);
        loaderUI.SetActive(false);
        callback.Invoke();
    }
}
