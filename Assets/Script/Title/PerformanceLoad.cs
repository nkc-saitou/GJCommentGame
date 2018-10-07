using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerformanceLoad : MonoBehaviour {

    GameStage stage;

    public Text gameGoalText;

    public Text countText;

    public Image bar;

    string keyword;
    string keywordCount;

    float time = 0;

    // Use this for initialization
    void Start () {

        stage = GameType.Instance.Stage;

        switch(stage)
        {
            case GameStage._piman:
                keyword = "にっがｗ";
                keywordCount = "30";
                break;

            case GameStage._natto:
                keyword = "ねばねばうざい";
                keywordCount = "20";
                break;

            case GameStage._choco:
                keyword = "はみがきこやん";
                keywordCount = "30";
                break;
        }

        gameGoalText.text = "「" + keyword + "」を60秒以内に" + keywordCount + "回打て！";

    }
	
	// Update is called once per frame
	void Update ()
    {
        time += Time.deltaTime;

        bar.fillAmount = time / 10.0f;

        countText.text = "広告 00:00:" + (Mathf.FloorToInt(time).ToString());

        if (time > 2.0f && time <= 10.0f)
        {
            if (Input.GetKeyDown(KeyCode.Return)) OnButtonDown();
        }
        else if (time > 10.0f)
        {
            OnButtonDown();
        }
    }

    public void OnButtonDown()
    {
        string sceneName = "";

        switch (stage)
        {
            case GameStage._piman:
                sceneName = "PimanStage";
                break;

            case GameStage._natto:
                sceneName = "NattoStage";
                break;

            case GameStage._choco:
                sceneName = "ChocomintStage";
                break;
        }

        if(sceneName != "") FadeManager.Instance.LoadScene(sceneName,0);
    }
}
