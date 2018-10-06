using UnityEngine;

public interface IWordReceive
{
    /// <summary>
    /// 文字列の受け取り
    /// </summary>
    /// <param name="word">文字列</param>
    /// <param name="color">文字列の色</param>
    void WordReceive(string word, Color color);
}