using UnityEngine;
using System.Collections;

public class Make : MonoBehaviour {

	public GameObject friend;

	public GameObject enemy1;
	public GameObject enemy2;

	public GameObject green1;
	public GameObject green2;

	int border = 1000;
	int enemyBorder = 100;

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

		if (Random.Range (0, 6) ==0) {
			Instantiate (friend, new Vector3 (0f, 0f, enemyBorder + 80f), friend.transform.rotation);
		}
		if (Random.Range (0, 4) == 0) {
			Instantiate (enemy1, new Vector3 (3f, 0f, enemyBorder + 100f), enemy1.transform.rotation);
		}
		else if (Random.Range (0, 5) == 0) {
			Instantiate (enemy2, new Vector3 (6f, 0f, enemyBorder + 80f), enemy2.transform.rotation);
		}
		enemyBorder += 80;
	}
}