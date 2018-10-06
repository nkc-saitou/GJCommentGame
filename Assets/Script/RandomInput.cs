using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RandomInput : MonoBehaviour
{
    const float INTERVAL_MAX = 3.0f;
    const float INTERVAL_MIN = 0.5f;

    IWordReceive wordOutput;
    WordCounter  wordCounter;

    [SerializeField] WordList shareWordData;
    [SerializeField] WordList AngerWordData;
    [SerializeField] WordList specialWordData;

    float intervalTimer = 0;
    int[] beforeWards = new int[3];
    //-----------------------------------------------------
    //  プロパティ
    //-----------------------------------------------------
    float SendInterval { get { return INTERVAL_MAX - (INTERVAL_MAX - INTERVAL_MIN) * wordCounter.AchivementRate; } }
    //=====================================================
    void Start()
    {
        wordOutput  = GetComponent<WordOutput>();
        wordCounter = GetComponent<WordCounter>();

        wordOutput.WordReceive("うぽつ～～", Color.white);
    }
    void Update()
    {
        intervalTimer += Time.deltaTime;

        if(intervalTimer > SendInterval)
        {
            RandomWordSend();
            intervalTimer = 0;
        }
    }
    //=====================================================
    /// <summary>
    /// ランダムな文字列を送る
    /// </summary>
    void RandomWordSend()
    {
        wordOutput.WordReceive(RandomWord(), Color.white);
    }
    
    /// <summary>
    /// 文字データの中の文字列をランダムで返す
    /// </summary>
    /// <returns></returns>
    string RandomWord()
    {
        if (wordCounter.WordCount == 0) return RandomGoodWord();

        Debug.Log("達成数" + wordCounter.WordCount + ",達成率" + wordCounter.AchivementRate);

        if (Random.Range(0.0f, 1.0f) > wordCounter.AchivementRate) return RandomGoodWord();

        return RandomAngerWord();
    }
    /// <summary>
    /// ランダムに褒め言葉を返す
    /// </summary>
    /// <returns></returns>
    string RandomGoodWord()
    {
        string[] goodWords = shareWordData.words.
            Concat(specialWordData.words).ToArray();

        return goodWords[Random.Range(0, goodWords.Length)];
    }
    /// <summary>
    /// ランダムに怒りコメントを返す
    /// </summary>
    /// <returns></returns>
    string RandomAngerWord()
    {
        return AngerWordData.words[Random.Range(0, AngerWordData.words.Length)];
    }
}
