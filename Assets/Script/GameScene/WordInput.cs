using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using UnityEngine.SceneManagement;

public class WordInput : MonoBehaviour
{
    public Text inputText;

    string memoryStr;

    InputField inputField;

    IWordReceive iWordReceive;

    /// <summary>
    /// 入力されたコメントを渡す
    /// </summary>
    public string Word { get; private set; }

    // Use this for initialization
    void Start()
    {
        inputField = FindObjectOfType<InputField>();

        iWordReceive = FindInterface.FindObjectOfInterfaces<IWordReceive>();

        InitInput();

        inputField.ActivateInputField();
    }

    void Update()
    {
        if (Input.anyKeyDown) inputField.ActivateInputField();
    }

    public void InputChange()
    {
        if (inputText.text.Length >= 1 && inputText.text.Length <= memoryStr.Length)
            AudioManager.Instance.PlaySE("se_BackSpace");

        inputText.text = WordConverter.Instance.ConVerter(inputField.text);

        memoryStr = inputText.text;
    }

    /// <summary>
    /// コメント入力終了
    /// </summary>
    public void InputEnd()
    {
        if(SceneManager.GetActiveScene().name == "PimanStage" ||
            SceneManager.GetActiveScene().name == "NattoStage" ||
            SceneManager.GetActiveScene().name == "ChocomintStage")
        {
            if (GameManager.instance == null) return;
            if (GameManager.instance.State == GameState.Finish) return;
        }

        if (iWordReceive == null || inputField.text == "") return;

        inputField.ActivateInputField();

        Word = WordConverter.Instance.ConVerter(inputField.text);

        iWordReceive.WordReceive(Word, WordType.Troll);

        InitInput();
    }

    /// <summary>
    /// Input初期化用メソッド
    /// </summary>
    void InitInput()
    {
        inputField.text = "";

        inputField.ActivateInputField();
    }
}