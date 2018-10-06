using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordOutput : MonoBehaviour, IWordReceive
{
    [SerializeField] WordMover wordPre;
    [SerializeField] string    outputWord;

    /// <summary>
    /// 文字オブジェクトの出力
    /// </summary>
    /// <param name="word">表示する文字列</param>
    public void WordReceive(string word, Color color)
    {
        WordMover wordObj = Instantiate(wordPre, new Vector3(12, Random.Range(-4, 4), 0), Quaternion.identity);
        wordObj.Initialize(word, color);
    }

    float RandomHeight(float min, float max)
    {
        return Random.Range(min, max);
    }

    [ContextMenu("出力")]
    void TestOutput()
    {
        WordReceive(outputWord, Color.red);
    }
}
