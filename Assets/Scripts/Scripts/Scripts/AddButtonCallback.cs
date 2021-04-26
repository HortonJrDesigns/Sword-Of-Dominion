using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AddButtonCallback : MonoBehaviour {

	[SerializeField]
	private bool physical;

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Button> ().onClick.AddListener (() => AddCallback());
	}

	private void AddCallback() {
		GameObject playerParty = GameObject.Find ("PlayerParty");
		playerParty.GetComponent<SelectUnit> ().SelectAttack (physical);
	}

}
