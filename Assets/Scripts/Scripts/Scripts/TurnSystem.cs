using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class TurnSystem : MonoBehaviour {
    
    public GameObject GameOverPanel;
    
    public GameObject WinnerPanel;
    
	private List<UnitStats> unitsStats;

	private GameObject playerParty;

	public GameObject enemyEncounter;

	[SerializeField]
	private GameObject actionsMenu, enemyUnitsMenu;

	void Start() {
		//playerParty = GameObject.Find ("PlayerParty");
        WinnerPanel.SetActive (false);
        GameOverPanel.SetActive (false);
        unitsStats = new List<UnitStats> ();
        
        // Add player units to the list.
        GameObject[] playerUnits = GameObject.FindGameObjectsWithTag("PlayerUnit");
		foreach (GameObject playerUnit in playerUnits) {
			UnitStats currentUnitStats = playerUnit.GetComponent<UnitStats> ();
			currentUnitStats.CalculateNextActTurn (0);
			unitsStats.Add (currentUnitStats);
		}
        
        // Add enemy units to the list.
        GameObject[] enemyUnits = GameObject.FindGameObjectsWithTag("EnemyUnit");
		foreach (GameObject enemyUnit in enemyUnits) {
			UnitStats currentUnitStats = enemyUnit.GetComponent<UnitStats> ();
			currentUnitStats.CalculateNextActTurn (0);
			unitsStats.Add (currentUnitStats);
		}
        
        // Sort the list vased on the speeds.
		unitsStats.Sort ();

		actionsMenu.SetActive (false);
		enemyUnitsMenu.SetActive (false);

		NextTurn ();
	}

	public void NextTurn() {
		GameObject[] remainingEnemyUnits = GameObject.FindGameObjectsWithTag ("EnemyUnit");
		if (remainingEnemyUnits.Length == 0) {
			enemyEncounter.GetComponent<CollectReward> ().GetReward ();
            WinnerPanel.SetActive (true);
            SceneManager.LoadScene ("Town");
		}

		GameObject[] remainingPlayerUnits = GameObject.FindGameObjectsWithTag ("PlayerUnit");
		if (remainingPlayerUnits.Length == 0) {
            GameOverPanel.SetActive (true);
			SceneManager.LoadScene("Title");
		}

		UnitStats currentUnitStats = unitsStats [0];
		unitsStats.Remove (currentUnitStats);

		if (!currentUnitStats.isDead ()) {
			GameObject currentUnit = currentUnitStats.gameObject;

			currentUnitStats.CalculateNextActTurn (currentUnitStats.nextActTurn);
			unitsStats.Add (currentUnitStats);
			unitsStats.Sort ();

			if (currentUnit.tag == "PlayerUnit") {
                GameObject.Find("PlayerParty").GetComponent<SelectUnit> ().SelectCurrentUnit (currentUnit.gameObject);
			} else {
				currentUnit.GetComponent<EnemyUnitAction> ().Act ();
			}
		} else {
			NextTurn ();
		}
	}
    
    public void WaitThenNextTurn () {
        StartCoroutine (WaitThenNextTurnRoutine ());
    }
    
    private IEnumerator WaitThenNextTurnRoutine() {
        yield return new WaitForSeconds (1.0f);
        NextTurn();
    }
}
