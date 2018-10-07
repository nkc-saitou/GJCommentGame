using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    float timer     = 0;
    float rimitTime = 0;

    //-----------------------------------------------------
    //  プロパティ
    //-----------------------------------------------------
    public float CountTime { get { return timer; } }
    public float TimeRate {
        get {
            if (rimitTime == 0) return 0;
            return Mathf.Min(timer / rimitTime, 1);
        }
    }
    bool IsFinish { get { return timer > rimitTime; } }
    //=====================================================
    void Update()
    {
        if (!GameManager.instance.IsPlay) return;

        TimeCount();
        CheckTime();
    }

    /// <summary>
    /// 初期化
    /// </summary>
    public void Initialize()
    {
        timer = 0;
        rimitTime = GameManager.instance.RimitTime;
    }
    /// <summary>
    /// カウント
    /// </summary>
    void TimeCount()
    {
        timer += Time.deltaTime;
    }
    /// <summary>
    /// カウントチェック
    /// </summary>
    void CheckTime()
    {
        if (!IsFinish) return;
        GameManager.instance.GameOver();
    }
}
