using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class UnitStats : MonoBehaviour, IComparable {

	[SerializeField]
	private Animator animator;

	[SerializeField]
	private GameObject damageTextPrefab;
	[SerializeField]
	private Vector2 damageTextPosition;

	public float health;
	public float mana;
	public float attack;
	public float magic;
	public float defense;
	public float speed;
    public float experience;
    public int nextActTurn;

	private bool dead = false;

	

	void Start() {
		
	}

	public void ReceiveDamage(float damage) {
		health -= damage;
		animator.Play ("Hit");

		GameObject HUDCanvas = GameObject.Find ("HUDCanvas");
        GameObject damageText = Instantiate (damageTextPrefab, HUDCanvas.transform);
		damageText.GetComponent<Text> ().text = "" + Mathf.FloorToInt (damage);
		damageText.transform.localPosition = damageTextPosition;
		damageText.transform.localScale = Vector2.one;
        Destroy (damageText.gameObject, 1f);

		if (health <= 0) {
			dead = true;
			gameObject.tag = "DeadUnit";
			Destroy (gameObject);
		}
        
        GameObject.Find("TurnSystem").GetComponent<TurnSystem>().WaitThenNextTurn();
        
	}

    public void CalculateNextActTurn (int currentTurn) {
		nextActTurn = currentTurn + Mathf.CeilToInt(100f / speed);
	}

	public int CompareTo(object otherStats) {
		return nextActTurn.CompareTo (((UnitStats)otherStats).nextActTurn);
	}

	public bool isDead() {
		return dead;
	}

	public void ReceiveExperience(float newExperience) {
		experience += newExperience;
	}
}
