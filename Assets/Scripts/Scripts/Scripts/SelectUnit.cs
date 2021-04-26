using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SelectUnit : MonoBehaviour {

	private GameObject currentUnit;

    private GameObject actionsMenu;
    private GameObject enemyUnitsMenu;

	void Awake() {
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if ((scene.name == "Battle 1") || (scene.name == "Battle"))
        {
			actionsMenu = GameObject.Find ("ActionsMenu");
			enemyUnitsMenu = GameObject.Find ("EnemyUnitsMenu");
        }
       
    }
    
    

	public void SelectCurrentUnit(GameObject unit) {
		currentUnit = unit;

		actionsMenu.SetActive (true);

		currentUnit.GetComponent<PlayerUnitAction> ().UpdateHUD ();
	}

	public void SelectAttack(bool physical) {
		currentUnit.GetComponent<PlayerUnitAction> ().SelectAttack (physical);

		actionsMenu.SetActive (false);
		enemyUnitsMenu.SetActive (true);
	}

	public void AttackEnemyTarget(GameObject target) {
		actionsMenu.SetActive (false);
		enemyUnitsMenu.SetActive (false);

		currentUnit.GetComponent<PlayerUnitAction>().Act (target);
	}
}

