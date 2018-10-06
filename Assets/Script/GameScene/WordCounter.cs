using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordCounter : MonoBehaviour
{
    string  _correctWord;    // 入力してほしいワード
    int     _clearNum;       // クリアまでの入力数

    //-----------------------------------------------------
    //  プロパティ
    //-----------------------------------------------------
    public int WordCount { get; private set; }
    public float AchivementRate { get { return Mathf.Min((float)WordCount / _clearNum, 1); } }
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
        _correctWord = GameManager.instance.CorrectWord;
        _clearNum    = GameManager.instance.ClearNum;
        WordCount    = 0;
    }
    /// <summary>
    /// 文字の確認
    /// </summary>
    /// <param name="word">確認ワード</param>
    public void CheckWord(string word)
    {
        if (_correctWord != word) return;

        WordCount++;
        CheckClear();
    }
    /// <summary>
    /// クリア確認
    /// </summary>
    void CheckClear()
    {
        if (_clearNum > WordCount) return;

        GameManager.instance.GameClear();
    }
}
