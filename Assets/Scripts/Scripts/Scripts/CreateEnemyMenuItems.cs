using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CreateEnemyMenuItems : MonoBehaviour {

	[SerializeField]
	private GameObject targetEnemyUnitPrefab;

	[SerializeField]
	private Sprite menuItemSprite;

	[SerializeField]
    private Vector2 initialPosition;
    
    [SerializeField]
    private Vector2 itemDimensions;

	[SerializeField]
	private KillEnemy killEnemyScript;

	// Use this for initialization
	void Awake () {
		GameObject enemyUnitsMenu = GameObject.Find ("EnemyUnitsMenu");

		GameObject[] existingItems = GameObject.FindGameObjectsWithTag ("EnemyUnit");
		Vector2 nextPosition = new Vector2 (initialPosition.x + (existingItems.Length * itemDimensions.x), initialPosition.y);

		GameObject targetEnemyUnit = Instantiate (targetEnemyUnitPrefab, enemyUnitsMenu.transform) as GameObject;
		targetEnemyUnit.name = "Target" + gameObject.name;
		targetEnemyUnit.transform.localPosition = nextPosition;
		targetEnemyUnit.transform.localScale = new Vector2 (0.7f, 0.7f);
		targetEnemyUnit.GetComponent<Button> ().onClick.AddListener (() => SelectEnemyTarget());
		targetEnemyUnit.GetComponent<Image> ().sprite = menuItemSprite;

		killEnemyScript.menuItem = targetEnemyUnit;
	}

	public void SelectEnemyTarget() {
		GameObject partyData = GameObject.Find ("PlayerParty");
		partyData.GetComponent<SelectUnit> ().AttackEnemyTarget (gameObject);
	}

}
