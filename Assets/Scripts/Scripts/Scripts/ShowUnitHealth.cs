using UnityEngine;
using System.Collections;

public class ShowUnitHealth : ShowUnitStat {

	override protected float NewStatValue() {
		return unit.GetComponent<UnitStats> ().health;
	}
}
