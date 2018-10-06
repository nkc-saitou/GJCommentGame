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

    int[] beforeGoodWards  = new int[3];
    int[] beforeAngerWords = new int[3];
    //-----------------------------------------------------
    //  プロパティ
    //-----------------------------------------------------
    float SendInterval { get { return INTERVAL_MAX - (INTERVAL_MAX - INTERVAL_MIN) * wordCounter.AchivementRate; } }
    //=====================================================
    void Start()
    {
        wordOutput  = GetComponent<WordOutput>();
        wordCounter = GetComponent<WordCounter>();

        beforeGoodWards = beforeGoodWards.Select(value => -1).ToArray();
        beforeAngerWords = beforeAngerWords.Select(value => -1).ToArray();

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
        int wordNo = ArrayNotMatchNo(beforeGoodWards, goodWords.Length);

        return goodWords[wordNo];
    }
    /// <summary>
    /// ランダムに怒りコメントを返す
    /// </summary>
    /// <returns></returns>
    string RandomAngerWord()
    {
        int wordNo = ArrayNotMatchNo(beforeAngerWords, AngerWordData.words.Length);

        return AngerWordData.words[wordNo];
    }
    /// <summary>
    /// 配列内の値と一致しない値を返す
    /// </summary>
    int ArrayNotMatchNo(int[] array, int range)
    {
        int no = 0;
        do
        {
            no = Random.Range(0, range);
        } while (array.Any(value => value == no));

        return no;
    }

    //int[] ArrayPush(int[] array, int no)
    //{
    //    return array.
    //        Concat(new int[] { no }).

    //}
}
