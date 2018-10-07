using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundChanger : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    [SerializeField] GameTimer gameTimer;
    [SerializeField] Sprite[]  backgroundList;
    [SerializeField] float     changeInterval;
    int count = 0;

    //=====================================================
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (!GameManager.instance.IsPlay) return;

        CheckTimer();
    }
    //=====================================================
    /// <summary>
    /// 時間の確認
    /// </summary>
    void CheckTimer()
    {
        // 20秒ごとに実行
        if (changeInterval > gameTimer.CountTime - (changeInterval * count)) return;

        ChangeBackground();
    }
    /// <summary>
    /// 背景変更
    /// </summary>
    void ChangeBackground()
    {
        ++count;
        spriteRenderer.sprite = backgroundList[count % backgroundList.Length];
    }
}
