using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {

	private HingeJoint myHingeJoint;

	private float defaultAngle = 20;

	private float flickAngle = -20;


	// Use this for initialization
	void Start () {

		this.myHingeJoint = GetComponent<HingeJoint> ();

		SetAngle (this.defaultAngle);
		
	}
	
	// Update is called once per frame
	void Update () {

		//触れている指の本数分繰り返す
		for (int i = 0; i < Input.touchCount; i++) {
			
			int id = Input.touches [i].fingerId;
			Vector2 pos = Input.touches [i].position;

			//タッチ座標を表示
			Debug.LogFormat ("{0} - x:{1}, y:{2}", id, pos.x, pos.y);

			Touch touch = Input.GetTouch(id);

			if ( touch.phase == TouchPhase.Began ) {
				
				if (pos.x > Screen.width * 0.5 && tag == "RightFripperTag") {

					// 右フリッパーをあげる
					SetAngle (this.flickAngle);

				} else if (pos.x < Screen.width * 0.5 && tag == "LeftFripperTag") {

					// 左フリッパーをあげる
					SetAngle (this.flickAngle);

				}

			} else if ( touch.phase == TouchPhase.Ended ) {

				if (tag == "RightFripperTag" || tag == "LeftFripperTag") {

					// 右フリッパーを下げる
					SetAngle (this.defaultAngle);

				}
			}
		}
	}


//		if (Input.GetKeyDown (KeyCode.LeftArrow) && tag == "LeftFripperTag") {
//
//			SetAngle (this.flickAngle);
//		}
//
//		if (Input.GetKeyDown (KeyCode.RightArrow) && tag == "RightFripperTag") {
//
//			SetAngle (this.flickAngle);
//		}
//
//		if (Input.GetKeyUp (KeyCode.LeftArrow) && tag == "LeftFripperTag") {
//
//			SetAngle (this.defaultAngle);
//		}
//
//		if (Input.GetKeyUp (KeyCode.RightArrow) && tag == "RightFripperTag") {
//
//			SetAngle (this.defaultAngle);
//		}

	public void SetAngle (float angle){

		JointSpring jointSpr = this.myHingeJoint.spring;
		jointSpr.targetPosition = angle;
		this.myHingeJoint.spring = jointSpr;

	}
}
