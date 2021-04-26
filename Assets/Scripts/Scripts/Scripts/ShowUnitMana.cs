using UnityEngine;
using System.Collections;

public class ShowUnitMana : ShowUnitStat {

	override protected float NewStatValue() {
		return unit.GetComponent<UnitStats> ().mana;
	}
}
