using UnityEngine;
using System.Collections;

public class KillEnemy : MonoBehaviour {

	public GameObject menuItem;

	void OnDestroy() {
		Destroy (menuItem);
	}
}
