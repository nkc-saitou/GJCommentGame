using UnityEngine;

public interface IWordReceive
{
    /// <summary>
    /// 文字列の受け取り
    /// </summary>
    /// <param name="word">文字列</param>
    /// <param name="type">文字列の属性</param>
    void WordReceive(string word, WordType type);
}