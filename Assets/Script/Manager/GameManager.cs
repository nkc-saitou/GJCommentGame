using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Start,
    Play,
    Finish
}

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
    public GameState State { get; private set; }
    public bool IsPlay { get { return State == GameState.Play; } }
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
        AudioManager.Instance.PlayBGM("bgm_GameScene");
        gameTimer.Initialize();
        State = GameState.Play;
    }
    /// <summary>
    /// ゲームクリア
    /// </summary>
    public void GameClear()
    {
        if (GameState.Finish == State) return;

        FadeManager.Instance.LoadScene("GameClear");
        State = GameState.Finish;
    }
    /// <summary>
    /// ゲーム終了
    /// </summary>
    public void GameOver()
    {
        if (GameState.Finish == State) return;

        FadeManager.Instance.LoadScene("GameOver");
        State = GameState.Finish;
    }
}
