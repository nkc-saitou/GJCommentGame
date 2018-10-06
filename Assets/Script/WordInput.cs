using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordInput : MonoBehaviour
{

    InputField inputField;

    public Text inputText;

    IWordReceive iWordReceive;

    /// <summary>
    /// 入力されたコメントを渡す
    /// </summary>
    public string Word { get; private set; }

	// Use this for initialization
	void Start ()
    {
        inputField = FindObjectOfType<InputField>();

        iWordReceive = FindInterface.FindObjectOfInterfaces<IWordReceive>();

        InitInput();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            inputField.ActivateInputField();
            InputEnd();
        }
    }

    /// <summary>
    /// コメント入力終了
    /// </summary>
    public void InputEnd()
    {
        if (iWordReceive == null || inputText.text == "") return;

        Word = inputText.text;

        iWordReceive.WordReceive(Word, Color.red);

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
