using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.IO;

public class WordInput : MonoBehaviour
{

    public Text inputText;

    TextAsset csvFile;

    List<string[]> csvDatas = new List<string[]>();

    InputField inputField;

    char[] strArray = { 'a', 'i', 'u', 'e', 'o','-' };

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

        csvFile = Resources.Load("csv/ConverterData") as TextAsset;

        StringReader reader = new StringReader(csvFile.text);

        while (reader.Peek() > -1)
        {
            string line = reader.ReadLine();
            csvDatas.Add(line.Split(','));
        }

        InitInput();
    }

    void Update()
    {
        inputField.ActivateInputField();
    }

    public void InputChange()
    {
        inputText.text = ConVerter();
    }

    /// <summary>
    /// コメント入力終了
    /// </summary>
    public void InputEnd()
    {
        if (iWordReceive == null || inputField.text == "") return;

        inputField.ActivateInputField();
        iWordReceive.WordReceive(ConVerter(), Color.red);

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

    /// <summary>
    /// アルファベットからひらがなへ変換
    /// </summary>
    /// <returns></returns>
    public string ConVerter()
    {
        string tempStr = "";
        string addStr = "";

        string[] tempArray = Split();

        for (int i = 0; i < tempArray.Length; i++)
        {
            if (tempArray[i].Length >= 3)
            {
                if (tempArray[i][0] == tempArray[i][1])
                {
                    addStr += "っ";
                    tempArray[i] = tempArray[i].Remove(0, 1);
                }
                else if (tempArray[i][0] == 'w')
                {
                    addStr += tempArray[i].Substring(0, 1);
                    tempArray[i] = tempArray[i].Remove(0, 1);
                }
            }

            for (int j = 0; j < csvDatas.Count; j++)
            {
                if (tempArray[i] == csvDatas[j][0])
                {
                    tempStr = csvDatas[j][1];
                    break;
                }
                else tempStr = tempArray[i];
            }
            addStr += tempStr;
        }
        return addStr;
    }

    /// <summary>
    /// 分割
    /// </summary>
    /// <returns></returns>
    public string[] Split()
    {
        var list = new List<string>();

        string str = inputField.text;

        int temp = 0;

        while (temp != -1)
        {
            if (str.Length >= 2 && str.Substring(0, 2) == "nn") temp = 1;
            else temp = str.IndexOfAny(strArray);

            if (temp == -1)
            {
                if (str.Length != 0) list.Add(str);
                break;
            }

            list.Add(str.Substring(0, temp + 1));

            str = str.Remove(0, list[list.Count - 1].Length);
        }

        return list.ToArray();
    }
}

