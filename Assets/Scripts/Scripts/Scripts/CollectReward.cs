using UnityEngine;
using System.Collections;

public class CollectReward : MonoBehaviour {

	[SerializeField]
	private float experience;

	public void Start() {
		GameObject turnSystem = GameObject.Find ("TurnSystem");
		turnSystem.GetComponent<TurnSystem> ().enemyEncounter = gameObject;
	}

	public void GetReward() {
		GameObject[] livingPlayerUnits = GameObject.FindGameObjectsWithTag ("PlayerUnit");
		float experiencePerUnit = experience / livingPlayerUnits.Length;
		foreach (GameObject playerUnit in livingPlayerUnits) {
			playerUnit.GetComponent<UnitStats> ().ReceiveExperience (experiencePerUnit);
		}

		Destroy (gameObject);
	}
}
