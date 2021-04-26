using UnityEngine;
using System.Collections;

public class AttackTarget : MonoBehaviour {

	public GameObject owner;

	[SerializeField]
	private string attackAnimation;

	[SerializeField]
	private bool magicAttack;

	[SerializeField]
	private float manaCost;

	[SerializeField]
	private float minAttackMultiplier;

	[SerializeField]
	private float maxAttackMultiplier;

	[SerializeField]
	private float minDefenseMultiplier;

	[SerializeField]
	private float maxDefenseMultiplier;
	
	public void Hit(GameObject target) {
		UnitStats ownerStats = owner.GetComponent<UnitStats> ();
		UnitStats targetStats = target.GetComponent<UnitStats> ();
		if (ownerStats.mana >= manaCost) {
			float attackMultiplier = Random.Range(minAttackMultiplier, maxAttackMultiplier);
			float damage = (magicAttack) ? (attackMultiplier * ownerStats.magic) : (attackMultiplier * ownerStats.attack);

			float defenseMultiplier = Random.Range(minDefenseMultiplier, maxDefenseMultiplier);
			damage = Mathf.Max(0, damage - (defenseMultiplier * targetStats.defense));

			owner.GetComponent<Animator> ().Play (attackAnimation);

			targetStats.ReceiveDamage (damage);

			ownerStats.mana -= manaCost;
		}
	}
}
