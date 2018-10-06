using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    float timer     = 0;
    float rimitTime = 0;
    bool  isCount   = false;

    //-----------------------------------------------------
    //  プロパティ
    //-----------------------------------------------------
    bool IsFinish { get { return timer > rimitTime; } }
    //=====================================================
    void Update()
    {
        if (!isCount) return;

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
        isCount = false;
    }

    /// <summary>
    /// カウント開始
    /// </summary>
    public void CountStart()
    {
        isCount = true;
    }
    /// <summary>
    /// 進行パーセント
    /// </summary>
    /// <returns></returns>
    public float TimePersent()
    {
        if (!isCount) return 0;
        return Mathf.Min(timer / rimitTime, 1);
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
