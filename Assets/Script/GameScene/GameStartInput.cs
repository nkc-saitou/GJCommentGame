using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartInput : MonoBehaviour
{
    const float INPUT_TIME = 1.5f;

    IWordReceive wordOutput;

    [SerializeField] string startWord;
    [SerializeField] int    wordNum;

    float timer;
    float interval;
    int   count;

    //=====================================================
    void Start()
    {
        wordOutput = GetComponent<IWordReceive>();
        timer = 0;
        count = 0;
        interval = INPUT_TIME / wordNum;
    }
    void Update()
    {
        if (wordNum <= count) return;

        timer += Time.deltaTime;

        if(interval < timer)
        {
            wordOutput.WordReceive(startWord, WordType.Normal);

            ++count;
            timer = 0;
        }
    }
    //=====================================================
    [ContextMenu("TestComment")]
    void TestComment()
    {
        wordOutput.WordReceive(startWord, WordType.Normal);
    }
}
