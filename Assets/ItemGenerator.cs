using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //cornPrefabを入れる
    public GameObject conePrefab;

    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;


    private float unitychanPos;
    private GameObject unitychan;
    private float i;

    float elapsedTime;



    // Use this for initialization
    void Start()
    {
        this.unitychan = GameObject.Find("unitychan");

    }

    // Update is called once per frame
    void Update()
    {
        this.unitychanPos = unitychan.transform.position.z;
        //ユニティちゃんの50メートル先
        this.i = unitychanPos + 50;
        //経過時間
        elapsedTime += Time.deltaTime;

        if(elapsedTime  >= 1.0f) {
            elapsedTime = 0;

                //どのアイテムを出すのかをランダムに設定
                int num = Random.Range(0, 10);
                if (num <= 1)
                {
                    //コーンをx軸方向に一直線に生成
                    for (float j = -1; j <= 1; j += 0.4f)
                    {
                        GameObject cone = Instantiate(conePrefab) as GameObject;
                        cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
                    }
                }
                else
                {

                    //レーンごとにアイテムを生成
                    for (int j = -1; j < 2; j++)
                    {
                        //アイテムの種類を決める
                        int item = Random.Range(1, 11);
                        //アイテムを置くZ座標のオフセットをランダムに設定
                        int offsetZ = Random.Range(-5, 6);
                        //60%コイン配置:30%車配置:10%何もなし
                        if (1 <= item && item <= 6)
                        {
                            //コインを生成
                            GameObject coin = Instantiate(coinPrefab) as GameObject;
                            coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
                        }
                        else if (7 <= item && item <= 9)
                        {
                            //車を生成
                            GameObject car = Instantiate(carPrefab) as GameObject;
                            car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
                        }
                    }
              }
        }
    }
}