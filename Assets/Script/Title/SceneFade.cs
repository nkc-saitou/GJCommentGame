using System.Collections;
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
    public void WordReceive(string word, WordType type)
    {
        switch(word)
        {
            case "ぴーまん":
                GameType.Instance.Stage = GameStage._piman;
                break;
            case "なっとう":
                GameType.Instance.Stage = GameStage._natto;
                break;
            case "ちょこみんと":
                GameType.Instance.Stage = GameStage._choco;
                break;
            case "そうさほうほう":
                FadeManager.Instance.LoadScene("OperationScene");
                GameType.Instance.Stage = GameStage._other;
                break;
        }

        if(GameType.Instance.Stage != GameStage._other) FadeManager.Instance.LoadScene("PerformanceLoadScene");
    }
}
