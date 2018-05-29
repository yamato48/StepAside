﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour {
	//アニメーションするためのコンポーネントを入れる
    private Animator myAnimator;
	//Unityちゃんを移動させるコンポーネントを入れる
    private Rigidbody myRigidbody;
    //前進するための力
    private float forwardForce = 800.0f;
	//左右に移動するための力
    private float turnForce = 500.0f;
    //左右の移動できる範囲
    private float movableRange = 3.4f;
	// Use this for initialization

    void Start()
    {
        //Animatorコンポーネントを取得
        this.myAnimator = GetComponent<Animator>();

        //走るアニメーションを開始
        this.myAnimator.SetFloat("Speed", 1);
         
        //Rigidbodyコンポーネントを取得
        this.myRigidbody = GetComponent<Rigidbody>();
	}
     
	// Update is called once per frame
	void Update () {
		//Unityちゃんに前方向の力を加える
        this.myRigidbody.AddForce(this.transform.forward * this.forwardForce);	
		//Unityちゃんを矢印キーまたはボタンに応じて左右に移動させる
        if (Input.GetKey (KeyCode.LeftArrow)  && -this.movableRange < this.transform.position.x) {
            //左に移動
            this.myRigidbody.AddForce (-this.turnForce, 0, 0);
        } else if (Input.GetKey (KeyCode.RightArrow)  && this.transform.position.x < this.movableRange) {
            //右に移動
            this.myRigidbody.AddForce (this.turnForce, 0, 0);
        } 
	}
}
