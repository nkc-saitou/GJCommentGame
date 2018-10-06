using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region シングルトン

    public static GameManager instance;

    void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }
    void OnDestroy()
    {
        instance = null;
    }

    #endregion
    [SerializeField] GameTimer gameTimer;

    [Header("GameSetting")]
    [SerializeField, Tooltip("制限時間")]               float   _rimitTime = 60.0f;
    [SerializeField, Tooltip("クリアまでのコメント数")] int    _clearNum;
    [SerializeField, Tooltip("正解ワード")]             string _correctWord;


    //=====================================================
    public float  RimitTime { get { return _rimitTime; } }
    public int    ClearNum { get { return _clearNum; } }
    public string CorrectWord { get { return _correctWord; } }
    //=====================================================
    void Start()
    {
        GameStart();
    }
    //=====================================================
    /// <summary>
    /// ゲーム開始
    /// </summary>
    public void GameStart()
    {
        gameTimer.Initialize();
        gameTimer.CountStart();
    }
    /// <summary>
    /// ゲームクリア
    /// </summary>
    public void GameClear()
    {
        Debug.Log("GameClear");
    }
    /// <summary>
    /// ゲーム終了
    /// </summary>
    public void GameOver()
    {
        Debug.Log("GameOver");
    }
}
