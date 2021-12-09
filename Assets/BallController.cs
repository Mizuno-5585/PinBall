using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    //ボールが見える可能性のあるz軸の最小値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    //スコアを表示するテキスト
    private GameObject scoreText;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");

        this.scoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text> ().text = "Game Over";
        }
    }

    //衝突時に呼ばれる関数
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "SmallStarTag")
		{
			this.score += 1;
            Debug.Log("SmallStarCollision!");
		}
        else if (collision.gameObject.tag == "LargeStarTag")
        {
            this.score += 3;
            Debug.Log("LargeStarCollision!");
        }
        else if (collision.gameObject.tag == "SmallCloudTag")
        {
            this.score += 5;
            Debug.Log("SmallCloudCollision!");
        }
        else if (collision.gameObject.tag == "LargeCloudTag")
        {
            this.score += 10;
            Debug.Log("LargeCloudCollision!");
        }

        this.scoreText.GetComponent<Text> ().text = "Score:" + this.score;
    }
}
