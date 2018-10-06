using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomInput : MonoBehaviour
{
    const float SEND_INTERVAL = 1.0f;

    IWordReceive wordOutput;
    [SerializeField] WordList shareWordData;
    [SerializeField] WordList AngerWordData;
    [SerializeField] WordList specialWordData;

    float intervalTimer = 0;

    //=====================================================
    void Start()
    {
        wordOutput = GetComponent<WordOutput>();
    }
    void Update()
    {
        intervalTimer += Time.deltaTime;

        if(intervalTimer > SEND_INTERVAL)
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
        return shareWordData.words[Random.Range(0, shareWordData.words.Length)];
    }
}
