using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using LitJson;

public class WordInput : MonoBehaviour
{

    InputField inputField;

    public Text inputText;

    string str;

    IWordReceive iWordReceive;

    const string APPLICATION_ID = "d29e1994f8c499eebdda5997b21f8bfccc889167168c032c0d7282c6e77e2c11";

    const string HIRAGANA_API = "https://labs.goo.ne.jp/api/hiragana";

    string m_hiragana;

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

    public void InputChange()
    {
        str = inputField.text;
    }

    /// <summary>
    /// コメント入力終了
    /// </summary>
    public void InputEnd()
    {
        if (iWordReceive == null || inputField.text == "") return;

        StartCoroutine(HiraganaPostRequest(inputField.text, 1));

        //Word = inputField.text;
    }

    /// <summary>
    /// Input初期化用メソッド
    /// </summary>
    void InitInput()
    {
        inputField.text = "";

        inputField.ActivateInputField();
    }

    public IEnumerator HiraganaPostRequest(string Sentence,int ConvertType)
    {
        // JsonDataの作成.
        JsonData data = new JsonData();

        // アプリケーションID.
        data["app_id"] = APPLICATION_ID;

        // 対象文字列.
        data["sentence"] = Sentence;

        // 変換タイプ（ひらがな、カタカナ）.
        switch (ConvertType)
        {
            case 1:
                data["output_type"] = "hiragana";
                break;
            case 2:
                data["output_type"] = "katakana";
                break;
        }

        string postJsonStr = data.ToJson();

        Debug.Log("send post json: " + postJsonStr);

        // bodyを作成.
        byte[] postBytes = Encoding.Default.GetBytes(postJsonStr);

        // ヘッダー.
        Dictionary<string, string> headers = new Dictionary<string, string>();
        headers["Content-Type"] = "application/json; charaset-UTF8";

        Debug.Log("send post json: " + postJsonStr);

        // リクエストを送信.
        WWW result = new WWW(HIRAGANA_API, postBytes, headers);
        yield return result;

        if (result.error != null)
        {
            Debug.Log("Post Failure…");
            Debug.Log(result.text);
        }
        else
        {
            Debug.Log("Post Success!");
            Debug.Log("result: " + result.text);

            JsonData jsonParser = JsonMapper.ToObject(result.text);

            // パース.
            m_hiragana = jsonParser["converted"].ToString();

            Debug.Log(m_hiragana);

            Word = m_hiragana;

            iWordReceive.WordReceive(Word, Color.red);

            InitInput();
        }
    }
}
