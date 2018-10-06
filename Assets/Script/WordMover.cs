﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TextMesh))]
public class WordMover : MonoBehaviour
{
    const float MOVE_SPEED         = 3.0f;
    const float DISPLAY_END_BORDER = -11.0f;
    const float WORD_SIZE          = 1.0f;

    Transform _transformCache;
    TextMesh  _textMeshCache;

    bool isMove     = false;
    int  wordLength = 0;

    //-----------------------------------------------------
    //  プロパティ
    //-----------------------------------------------------
    Transform TransformCache
    {
        get
        {
            if (_transformCache == null) _transformCache = transform;
            return _transformCache;
        }
    }
    TextMesh TextMeshCache
    {
        get
        {
            if (_textMeshCache == null) _textMeshCache = GetComponent<TextMesh>();
            return _textMeshCache;
        }
    }
    /// <summary>
    /// 文字の終りのX座標
    /// </summary>
    float WordEndX { get { return TransformCache.localPosition.x + wordLength * WORD_SIZE; } }

    //=====================================================
    void Update()
    {
        if (!isMove) return;

        Move();
        CheckDestroy();
    }
    //=====================================================

    /// <summary>
    /// 初期化処理
    /// </summary>
    /// <param name="word">表示する文字列</param>
    public void Initialize(string word, Color color)
    {
        TextMeshCache.text  = word;
        TextMeshCache.color = color;

        isMove     = true;
        wordLength = word.Length;
    }
    /// <summary>
    /// 移動処理
    /// </summary>
    void Move()
    {
        TransformCache.localPosition += Vector3.left * MOVE_SPEED * Time.deltaTime;
    }
    /// <summary>
    /// 削除の確認
    /// </summary>
    void CheckDestroy()
    {
        if (IsDestroy()) Destroy(this.gameObject);
    }
    /// <summary>
    /// 削除するかどうか
    /// </summary>
    bool IsDestroy()
    {
        if (wordLength == 0) return true;
        if (WordEndX < DISPLAY_END_BORDER) return true;
        return false;
    }
}