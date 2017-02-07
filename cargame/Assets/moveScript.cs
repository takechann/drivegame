using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class moveScript : MonoBehaviour {

	float speed = 0f;
	float movePower = 0.2f;
	Rigidbody rb;

	public static float merter;

	void Start() {
		rb = GetComponent<Rigidbody>();
	}

	public void FixedUpdate (){
		if (Toshi.Goo > 0.95f && speed < 75f) {
			Accel(); //アクセル
		}
		if (Toshi.LaneChange > 50f && Toshi.Goo > 0.1f) {
			Right(); //右移動
		}
		if (Toshi.LaneChange < -50f && Toshi.Goo > 0.1f) {
			Left(); //左移動
		}
		if (Toshi.Goo>0.1f && Toshi.Goo < 0.90f && Toshi.Recog) {
			Brake();//ブレーキ
		}
		if (Toshi.Goo < 0.1f && Toshi.Recog) {
			MostBrake ();//急ブレーキ
		}
		//減速
		//speed -= 2f;
		//最低速度
		if (speed < 0) {
			speed = 0.00000000f;
		}
		merter = speed;
		Debug.Log(speed);
	}


	void Accel() {
		speed += 0.1f;
		rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed);
	}

	void Right() {
		if (transform.position.x <= 8f) {
			Vector3 temp = new Vector3 (transform.position.x + movePower, transform.position.y, transform.position.z);
			transform.position = temp;
			speed -= 0.08f;
		}
	}

	void Left() {
		if (transform.position.x >= -5f) {
			Vector3 temp = new Vector3 (transform.position.x - movePower, transform.position.y, transform.position.z);
			transform.position = temp;
			speed -= 0.08f;
		}
	}
	void Brake(){
		speed -= 0.05f;//減速
		if (speed > 0) {
			rb.velocity = new Vector3 (rb.velocity.x, rb.velocity.y, speed);
		}
	}
	void MostBrake (){
		speed -= 0.8f;
		if (speed > 0) {
			rb.velocity = new Vector3 (rb.velocity.x, rb.velocity.y, speed);
		}
	}

	/*void OnCollisionEnter (Collision collision){
		if (collision.gameObject.tag == "Enemy") {
			this.speed = 0;
		}
	}*/


	void OnControllerColliderHit(ControllerColliderHit hit){
		if(hit.gameObject.tag=="Player"){
			this.speed = 0f;
			Destroy (hit.gameObject);
		}
	}

}