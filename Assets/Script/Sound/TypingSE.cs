using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TypingSE : MonoBehaviour {

    string sceneName = "";

    void Start()
    {
        SceneManager.activeSceneChanged += OnActiveSceneChanged;

        sceneName = SceneManager.GetActiveScene().name;
        SceneNameSet();
    }
	
	void Update ()
    {

        switch(sceneName)
        {
            case "GameOver": return; 
            case "GameClear": return;
            case "OperationScene": return;
        }

		if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.Return)) AudioManager.Instance.PlaySE("se_Enter");
            else if (Input.GetKey(KeyCode.Backspace)) AudioManager.Instance.PlaySE("se_BackSpace");
            else AudioManager.Instance.PlaySE("se_Imput");
        }
	}

    void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
    {
        SceneNameSet();
    }

    void SceneNameSet()
    {
        sceneName = SceneManager.GetActiveScene().name;
    }
}
