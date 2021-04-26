using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MoveSceneTrigger : MonoBehaviour
{

    public Image loadingBarImage;
    public TMP_Text loadingText;
    public GameObject loadingBar;
    public GameObject backgroundImage;
    
    [SerializeField]
    private string loadLevel;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            backgroundImage.SetActive(true);
            loadingBar.SetActive(true);
            //SceneManager.LoadScene(loadLevel);
            StartCoroutine(LoadingScene());
            
        }
    }
    private IEnumerator LoadingScene()
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(loadLevel);
            while (!operation.isDone)
            {
                float progress = Mathf.Clamp01(operation.progress / 3f);
                loadingBarImage.fillAmount = progress;
                loadingText.text = "Loading... " + (int) (progress * 100) + "%";
                yield return new WaitForSeconds(.5f);
            }
            
        }
}

