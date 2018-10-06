using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordInput : MonoBehaviour
{

    InputField inputField;

    IWordReceive iWordReceive;

    /// <summary>
    /// 入力されたコメントを渡す
    /// </summary>
    public string Word { get; private set; }

	// Use this for initialization
	void Start ()
    {
        inputField = FindObjectOfType<InputField>();

        iWordReceive = FindObjectOfInterfaces<IWordReceive>();

        InitInput();
    }

    /// <summary>
    /// コメント入力終了
    /// </summary>
    public void InputEnd()
    {
        if (iWordReceive == null) return;
        Word = inputField.text;

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

    public T FindObjectOfInterfaces<T>() where T : class
    {
        List<T> list = new List<T>();

        foreach(var n in FindObjectsOfType<Component>())
        {
            var component = n as T;

            if(component != null)
            {
                return component;
            }
        }

        return null;
    }
}
