using UnityEngine;
using System.Collections;

public abstract class ShowUnitStat : MonoBehaviour {

	[SerializeField]
	protected GameObject unit;

	[SerializeField]
	private float maxValue;

	private Vector2 initialScale;

	void Start() {
		initialScale = gameObject.transform.localScale;
	}

	void Update() {
		if (unit != null) {
			float newValue = NewStatValue ();
			float newScale = (initialScale.x * newValue) / maxValue;
			gameObject.transform.localScale = new Vector2(newScale, initialScale.y);
		}
	}

	public void ChangeUnit(GameObject newUnit) {
		unit = newUnit;
	}

	abstract protected float NewStatValue();
}
