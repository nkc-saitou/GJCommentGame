using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultFade : MonoBehaviour {

    float time = 0;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "GameClear") AudioManager.Instance.PlayBGM("bgm_GameClear");
        else if (SceneManager.GetActiveScene().name == "GameOver") AudioManager.Instance.PlayBGM("bgm_GameOver");
    }

    void Update()
    {
        time = Mathf.Min(time += Time.deltaTime,2.0f);

        if (time < 2.0f) return;

        if (Input.GetKeyDown(KeyCode.Return)) OnButtonDown();
    }

    public void OnButtonDown()
    {
        AudioManager.Instance.PlaySE("se_Enter");
        FadeManager.Instance.LoadScene("TitleScene");
    }
}
