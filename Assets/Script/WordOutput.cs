using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordOutput : MonoBehaviour, IWordReceive
{
    [SerializeField] WordManager wordManager;
    [SerializeField] WordMover   wordPre;

    float beforeHeight = 0;

    /// <summary>
    /// 文字オブジェクトの出力
    /// </summary>
    /// <param name="word">表示する文字列</param>
    public void WordReceive(string word, Color color)
    {
        WordMover wordObj = Instantiate(wordPre, WordOutputPosition(), Quaternion.identity);
        wordObj.Initialize(word, color);
        wordManager.AddComment(wordObj);
    }

    /// <summary>
    /// 文字を出す位置
    /// </summary>
    /// <returns></returns>
    Vector3 WordOutputPosition()
    {
        const float WORD_START_X = 11.0f;
        return new Vector3(WORD_START_X, RandomHeight(), 0);
    }
    /// <summary>
    /// ランダムな高さを返す
    /// </summary>
    /// <returns></returns>
    float RandomHeight()
    {
        const float HEIGHT_MIN     = -2.0f;
        const float HEIGHT_MAX     =  4.5f;
        const float AVERAGE_BORDER =  3.0f;
        const float WORD_SIZE      =  1.0f;

        float height = 0;

        do
        {
            height = Random.Range(HEIGHT_MIN, HEIGHT_MAX);
            if (Mathf.Abs(wordManager.AverageHeight()) > AVERAGE_BORDER)
            {
                height = Mathf.Clamp(height - wordManager.AverageHeight(), HEIGHT_MIN, HEIGHT_MIN);
            }

            if (beforeHeight == 0) break;
        } while (Mathf.Abs(beforeHeight - height) < WORD_SIZE);

        beforeHeight = height;
        return height;
    }
}
