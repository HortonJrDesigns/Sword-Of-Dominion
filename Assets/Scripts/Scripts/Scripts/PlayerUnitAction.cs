using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerUnitAction : MonoBehaviour {

	[SerializeField]
	private GameObject physicalAttackPrefab;

	[SerializeField]
	private GameObject magicalAttackPrefab;

	private GameObject currentAttack;
    private GameObject physicalAttack;
    private GameObject magicalAttack;

	[SerializeField]
	private Sprite faceSprite;

	void Awake () {
		physicalAttack = Instantiate (physicalAttackPrefab, transform);
		magicalAttack = Instantiate (magicalAttackPrefab, transform);

		physicalAttack.GetComponent<AttackTarget> ().owner = gameObject;
		magicalAttack.GetComponent<AttackTarget> ().owner = gameObject;

		currentAttack = physicalAttack;
	}

	public void SelectAttack(bool physical) {
		currentAttack = (physical) ? physicalAttack : magicalAttack;
	}

	public void Act(GameObject target) {
		currentAttack.GetComponent<AttackTarget> ().Hit (target);
	}

	public void UpdateHUD() {
		GameObject playerUnitFace = GameObject.Find ("PlayerUnitFace");
		playerUnitFace.GetComponent<Image> ().sprite = faceSprite;

		GameObject playerUnitHealthBar = GameObject.Find ("PlayerUnitHealthBar");
		playerUnitHealthBar.GetComponent<ShowUnitHealth> ().ChangeUnit (gameObject);

		GameObject playerUnitManaBar = GameObject.Find ("PlayerUnitManaBar");
		playerUnitManaBar.GetComponent<ShowUnitMana> ().ChangeUnit (gameObject);
	}
}
