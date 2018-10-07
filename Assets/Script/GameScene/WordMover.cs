using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordMover : MonoBehaviour
{
    const float MOVE_SPEED         = 3.0f;
    const float DISPLAY_END_BORDER = -11.0f;
    const float WORD_SIZE          = 1.0f;

    Transform   _transformCache;
    [SerializeField]
    TextMeshPro _textMeshCache;

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
    TextMeshPro TextMeshCache
    {
        get
        {
            return _textMeshCache;
        }
    }
    public float WordEndX { get { return TransformCache.localPosition.x + wordLength * WORD_SIZE; } }
    public float PositionHeight {  get { return TransformCache.localPosition.y; } }
    public Rect GetRect {
        get {
            return new Rect(
                new Vector2(TransformCache.localPosition.x, TransformCache.localPosition.y - (WORD_SIZE * 0.5f)),
                new Vector2(wordLength * WORD_SIZE, WORD_SIZE));
        }
    }

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
    /// <summary>
    /// 当たり判定
    /// </summary>
    /// <returns>当たっている</returns>
    public bool IsCollision(Rect rect)
    {
        return
            GetRect.position.x                  < rect.position.x + rect.size.x &&
            GetRect.position.x + GetRect.size.x > rect.position.x               &&
            GetRect.position.y                  < rect.position.y + rect.size.y &&
            GetRect.position.y + GetRect.size.y > rect.size.y;
    }
}