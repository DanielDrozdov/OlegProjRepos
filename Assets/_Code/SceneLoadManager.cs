using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    public static SceneLoadManager Instance;
    private int _crossesCount = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SetNewCross()
    {
        _crossesCount += 1;
    }

    public void SetMinusCross()
    {
        _crossesCount -= 1;
        if(_crossesCount <= 0)
        {
            StartCoroutine(LoadNextScene());
        }
    }

    private IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(0.5f);
        int buildIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (buildIndex > SceneManager.sceneCountInBuildSettings - 1)
        {
            UI.Instance.ActivateWinScreen();
        }
        else
        {
            SceneManager.LoadScene(buildIndex);
        }
    }
}
