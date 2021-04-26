using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {

	[SerializeField]
	private GameObject enemyEncounterPrefab;
   // private GameObject BossEncounterPrefab;
    
	private bool spawning = false;

	void Start() {
		DontDestroyOnLoad (gameObject);

		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
		if (scene.name == "Battle") {
			if (spawning) {
				Instantiate (enemyEncounterPrefab);
			}
			SceneManager.sceneLoaded -= OnSceneLoaded;
			Destroy (gameObject);
		}
        
    }

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			spawning = true;
			SceneManager.LoadScene ("Battle");
		}
   }
}
