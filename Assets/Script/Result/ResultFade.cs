using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultFade : MonoBehaviour {

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "GameClear") AudioManager.Instance.PlayBGM("bgm_GameClear");
        else if (SceneManager.GetActiveScene().name == "GameOver") AudioManager.Instance.PlayBGM("bgm_GameOver");
    }

    public void OnButtonDown()
    {
        FadeManager.Instance.LoadScene("TitleScene");
    }
}
