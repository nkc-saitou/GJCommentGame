using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordInput : MonoBehaviour {

    InputField inputField;

    /// <summary>
    /// 入力されたコメントを渡す
    /// </summary>
    public string Word { get; private set; }

	// Use this for initialization
	void Start ()
    {
        inputField = FindObjectOfType<InputField>();

        InitInput();
    }

    /// <summary>
    /// コメント入力終了
    /// </summary>
    public void InputEnd()
    {
        Word = inputField.text;

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
