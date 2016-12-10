using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public bool useLoadingText;

    private bool loadScene = false;
    private bool isClicked = false;

    private Scene activeScene;
    [SerializeField]
    private int nextSceneIndex;
    [SerializeField]
    private Text loadingText;

    void Start()
    {
        activeScene = SceneManager.GetActiveScene();
    }

	void Update ()
    {
	    if (isClicked && !loadScene)
        {
            loadScene = true;
            if (useLoadingText)
                loadingText.text = "Loading...";
            StartCoroutine(LoadNewScene());
        }

        if (loadScene)
        {
            if (useLoadingText)
            {
                loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b,
                    Mathf.PingPong(Time.time, 1));
            }
        }
	}

    public void StartGame()
    {
        isClicked = true;
    }

    IEnumerator LoadNewScene()
    {
        // This Line can be deleted. Used for testing purposes only
        if (useLoadingText)
            yield return new WaitForSeconds(3);

        if (nextSceneIndex == activeScene.buildIndex)
            SceneManager.LoadScene(nextSceneIndex, LoadSceneMode.Single);
        else
        {
            AsyncOperation asyncScene = SceneManager.LoadSceneAsync(nextSceneIndex, LoadSceneMode.Single);
            while (!asyncScene.isDone)
                yield return null;
        }
    }
}
