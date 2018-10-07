﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneFade : MonoBehaviour,IWordReceive {

	// Use this for initialization
	void Start () {
        AudioManager.Instance.PlayBGM("bgm_StartScene");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// 文字オブジェクトの出力
    /// </summary>
    /// <param name="word">表示する文字列</param>
    public void WordReceive(string word, Color color)
    {
        switch(word)
        {
            case "ぴーまん": FadeManager.Instance.LoadScene("PimanStage"); break;
            case "なっとう": FadeManager.Instance.LoadScene("NattoStage"); break;
            case "ちょこみんと": FadeManager.Instance.LoadScene("ChocomintStage"); break;
            case "そうさほうほう": FadeManager.Instance.LoadScene("OperationScene"); break;
        }
    }
}
