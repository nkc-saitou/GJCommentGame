using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordMover : MonoBehaviour
{
    const float MOVE_SPEED = 3.0f;

    Transform transformCache;
    [SerializeField] TextMesh textMeshCache;

    [SerializeField] string testWord;
    bool isMove = false;

    //=====================================================
    void Start()
    {
        transformCache = transform;
    }
    void Update()
    {
        Move();
    }
    //=====================================================

    /// <summary>
    /// 初期化処理
    /// </summary>
    /// <param name="word">表示する文字列</param>
    public void Initialize(string word)
    {
        if (textMeshCache == null) return;
        textMeshCache.text = word;
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
	
    [ContextMenu("TestMove")]
    void TestMove()
    {
        if (testWord == "") return;
        Initialize(testWord);
    }
}
