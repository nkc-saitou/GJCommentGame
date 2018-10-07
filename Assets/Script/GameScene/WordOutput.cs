using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordOutput : MonoBehaviour, IWordReceive
{
    [SerializeField] WordManager wordManager;
    [SerializeField] WordCounter wordCounter;
    [SerializeField] WordMover   wordPre;

    float beforeHeight = 0;

    /// <summary>
    /// 文字オブジェクトの出力
    /// </summary>
    /// <param name="word">表示する文字列</param>
    public void WordReceive(string word, WordType type)
    {
        WordMover wordObj = Instantiate(wordPre, wordManager.AdjustmentPosition(type), Quaternion.identity);
        wordObj.Initialize(word, WordImage.TypeToColor(type));
        wordManager.AddComment(wordObj);

        if(WordType.Troll == type)
        {
            wordCounter.CheckWord(word);
        }
    }
}
