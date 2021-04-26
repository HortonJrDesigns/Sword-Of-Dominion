using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartBattle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);

		SceneManager.sceneLoaded += OnSceneLoaded;

		gameObject.SetActive (false);
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
		if (scene.name == "Title") {
			SceneManager.sceneLoaded -= OnSceneLoaded;
			Destroy (gameObject);
        }
       // } else{
        //    gameObject.SetActive(scene.name == "Battle");
            //gameObject.SetActive(scene.name == "Boss Battle");
		//}
	//}
    if((scene.name == "Battle") || (scene.name == "Battle 1")){
        gameObject.SetActive(true);
   }
   // if(scene.name == "Boss Battle"){
    //    gameObject.SetActive(true);
  //  }
    }

}
