using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordCounter : MonoBehaviour
{
    string  correctWord;    // 入力してほしいワード
    int     clearNum;       // クリアまでの入力数
    int     wordCount;      // 入力された数

    //-----------------------------------------------------
    //  プロパティ
    //-----------------------------------------------------
    public float AchivementRate { get { return wordCount / clearNum; } }
    //=====================================================
    void Start()
    {
        Initialize();
    }
    //=====================================================
    /// <summary>
    /// 初期化
    /// </summary>
    public void Initialize()
    {
        correctWord = GameManager.instance.CorrectWord;
        clearNum = GameManager.instance.ClearNum;
        wordCount = 0;
    }
    /// <summary>
    /// 文字の確認
    /// </summary>
    /// <param name="word">確認ワード</param>
    public void CheckWord(string word)
    {
        if (correctWord != word) return;

        wordCount++;
        CheckClear();
    }
    /// <summary>
    /// クリア確認
    /// </summary>
    void CheckClear()
    {
        if (clearNum > wordCount) return;

        GameManager.instance.GameClear();
    }
}
