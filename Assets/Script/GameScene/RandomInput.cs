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

    float intervalTimer   =  0;
    int   beforeGoodWard  = -1;
    int   beforeAngerWord = -1;
    //-----------------------------------------------------
    //  プロパティ
    //-----------------------------------------------------
    float SendInterval { get { return INTERVAL_MAX - (INTERVAL_MAX - INTERVAL_MIN) * wordCounter.AchivementRate; } }
    //=====================================================
    void Start()
    {
        wordOutput  = GetComponent<WordOutput>();
        wordCounter = GetComponent<WordCounter>();
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
        wordOutput.WordReceive(RandomWord(), WordType.Normal);
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
        int wordNo = NotMatchNo(beforeGoodWard, goodWords.Length);
        beforeGoodWard = wordNo;

        return goodWords[wordNo];
    }
    /// <summary>
    /// ランダムに怒りコメントを返す
    /// </summary>
    /// <returns></returns>
    string RandomAngerWord()
    {
        int wordNo = NotMatchNo(beforeAngerWord, AngerWordData.words.Length);
        beforeAngerWord = wordNo;

        return AngerWordData.words[wordNo];
    }
    /// <summary>
    /// 配列内の値と一致しない値を返す
    /// </summary>
    int NotMatchNo(int num, int range)
    {
        int no = 0;
        do
        {
            no = Random.Range(0, range);
        } while (num == no);

        return no;
    }
}
