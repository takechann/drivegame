using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class  SpeedTextScript: MonoBehaviour {


	public Text scoreText; 

	public Text alarmText;

	void Start () {
		//scoreText.text = "時速"+"0"+"km";
	}

	// Update is called once per frame
	void Update () {
		float hourSpeed = moveScript.merter;

		scoreText.text = hourSpeed.ToString("0.00") + "km/h";

		float over;
		over = hourSpeed - 60f;

		if (hourSpeed > 60f) {
			alarmText.text = over.ToString ("0.00") + "km/hオーバー！";
		} else {
			alarmText.text="";
		}
		//Debug.Log (hourSpeed);
	}
}
