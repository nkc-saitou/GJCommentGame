using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStage
{
    _other = 0,
    _piman,
    _natto,
    _choco
}

public class GameType : SingletonMonoBehaviour<GameType> {

    #region Singleton

    void Awake()
    {
        //インスタンスがない場合
        if (this != Instance)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    #endregion Singleton

    public GameStage Stage { get; set; }
}
