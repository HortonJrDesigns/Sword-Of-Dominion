using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RunFromBattle : MonoBehaviour {

	[SerializeField]
	private float runnningChance;

	public void TryRunning() {
		float randomNumber = Random.value;
		if (randomNumber < runnningChance) {
			SceneManager.LoadScene ("Town");
		} else {
			GameObject.Find("TurnSystem").GetComponent<TurnSystem> ().NextTurn ();
		}
	}
}
