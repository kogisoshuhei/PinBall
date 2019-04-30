using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreController : MonoBehaviour {

	//スコア表示用のテキスト
	public Text scoreText;

	//スコアの初期値
	private int score = 0; 

	// Use this for initialization
	void Start () {

		score = 0;
		SetScore();

	}

	//衝突時に呼ばれる関数
	void OnCollisionEnter(Collision collision) {

		if (collision.gameObject.tag == "SmallStarTag") {
			score += 10;
			Debug.Log ("小さい星に当たった。" + score);

		} else if (collision.gameObject.tag == "LargeStarTag") {
			score += 20;
			Debug.Log ("大きい星に当たった。" + score);

		} else if (collision.gameObject.tag == "SmallCloudTag" || collision.gameObject.tag == "LargeCloudTag") {
			score += 5;
			Debug.Log ("雲に当たった。" + score);
		}

		SetScore();

	}

	void SetScore(){

		scoreText.text = string.Format ("Score:{0}", score);

	}
}
