using UnityEngine;
using System.Collections;
using Leap;

public class Toshi : MonoBehaviour {

	Controller controller = new Controller(); 
	//指の数をカウント
	private int FingerCount;
	private GameObject[] FingerObjects;
	public static float Goo; // どのくらい握っているか
	public static float LaneChange;
	public static bool Recog; //手を認識したら

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		Frame frame = controller.Frame();
		FingerCount = frame.Fingers.Count;
		//指が有効であればInteractionBoxオブジェクトを使ってLeapMotionの座標系をディスプレイ座標系に変換する
		InteractionBox interactionBox = frame.InteractionBox;

		Hand RightHand = frame.Hands.Rightmost; //右手の情報
		Goo = RightHand.GrabStrength; //どのくらい握っているか

		LaneChange = RightHand.PalmPosition.x;
		Recog = !frame.Hands.IsEmpty;

		//Debug.Log (Recog);

	}
}
