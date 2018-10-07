using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class WordConverter : SingletonMonoBehaviour<WordConverter>
{

    public List<string[]> csvDatas = new List<string[]>();

    TextAsset csvFile;

    void Awake()
    {
        //インスタンスがない場合
        if (this != Instance)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        //CSVファイルを読み込んでセット
        csvFile = Resources.Load("csv/ConverterData") as TextAsset;

        StringReader reader = new StringReader(csvFile.text);

        while (reader.Peek() > -1)
        {
            string line = reader.ReadLine();
            csvDatas.Add(line.Split(','));
        }
    }

    /// <summary>
    /// アルファベットからひらがなへ変換
    /// </summary>
    /// <returns></returns>
    public string ConVerter(string inputWord)
    {

        string tempStr = "";
        string addStr = "";

        string[] tempArray = Split(inputWord);


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
                else if(tempArray[i][0] == 'n')
                {
                    addStr += "ん";
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
    string[] Split(string inputWord)
    {
        var list = new List<string>();

        string str = inputWord;

        char[] strArray = { 'a', 'i', 'u', 'e', 'o', '-' };

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
