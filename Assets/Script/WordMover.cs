using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TextMesh))]
public class WordMover : MonoBehaviour
{
    const float MOVE_SPEED = 3.0f;

    Transform transformCache;
    TextMesh textMeshCache;

    bool isMove = false;

    //=====================================================
    void Update()
    {
        Move();
    }
    //=====================================================

    /// <summary>
    /// 初期化処理
    /// </summary>
    /// <param name="word">表示する文字列</param>
    public void Initialize(string word, Color color)
    {
        transformCache = transform;
        textMeshCache = GetComponent<TextMesh>();

        if (textMeshCache == null) return;
        textMeshCache.text = word;
        textMeshCache.color = color;
        isMove = true;
    }
	
    /// <summary>
    /// 移動処理
    /// </summary>
    void Move()
    {
        if (!isMove) return;
        transformCache.localPosition += Vector3.left * MOVE_SPEED * Time.deltaTime;
    }
}
