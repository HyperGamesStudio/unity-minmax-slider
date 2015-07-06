using UnityEngine;
using System.Collections;

public class MinMaxSliderTester : MonoBehaviour {

	[MinMaxSliderAttribute(0,100)]
	public Vector2 test = new Vector2(25,75);

}
