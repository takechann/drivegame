﻿using UnityEngine;
using System.Collections;

public class CritatingScript : MonoBehaviour {

	public GameObject friend;

	public GameObject enemy1;
	public GameObject enemy2;

	public GameObject green1;
	public GameObject green2;

	int border = 1000;
	int enemyBorder = 80;

	void Update ()
	{
		if (transform.position.z > border) {
			CreateMap ();
		}
		if (transform.position.z > enemyBorder) {
			CreateEnemy ();
		}
	}

	void CreateMap(){
		if (green1.transform.position.z < border) {
			border += 2000;
			Vector3 temp = new Vector3 (0,0.05f,border);
			green1.transform.position = temp;
		} else if (green2.transform.position.z < border) {
			border += 2000;
			Vector3 temp = new Vector3 (0,0.05f,border);
			green2.transform.position = temp;
		}
	}

	void CreateEnemy (){
		Instantiate (friend, new Vector3 (0f, 0f, enemyBorder + 50f), friend.transform.rotation);
		Instantiate (enemy1, new Vector3 (0f, 0f, enemyBorder + 50f), friend.transform.rotation);
		Instantiate (enemy2, new Vector3 (0f, 0f, enemyBorder + 50f), friend.transform.rotation);
		enemyBorder += 5;
	}
}