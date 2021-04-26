using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BossSpawner : MonoBehaviour {
    [SerializeField]
    private GameObject BossEncounterPrefab;
    
    private bool spawning = false;
    
    void Start() {
        DontDestroyOnLoad (gameObject);
        
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if (scene.name == "Battle 1") {
            if (spawning) {
                Instantiate (BossEncounterPrefab);
            }
            SceneManager.sceneLoaded -= OnSceneLoaded;
            Destroy (gameObject);
        }
    }
    
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            spawning = true;
            SceneManager.LoadScene ("Battle 1");
        }
    }
}
