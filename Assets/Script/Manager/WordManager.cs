using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WordManager : MonoBehaviour
{
    List<WordMover> commentList = new List<WordMover>();

    /// <summary>
    /// コメントの追加
    /// </summary>
    /// <param name="comment"></param>
    public void AddComment(WordMover comment)
    {
        commentList.Add(comment);
    }
    /// <summary>
    /// 高さの平均
    /// </summary>
    /// <returns></returns>
    public float AverageHeight()
    {
        if (commentList.Count == 0) return 0;
        CheckCommentList();

        float sum = 0;
        foreach(WordMover comment in commentList) {
            sum += comment.PositionHeight;
        }

        return sum / commentList.Count;
    }
    /// <summary>
    /// Listの中身を確認する
    /// </summary>
    void CheckCommentList()
    {
        commentList = commentList.Where(value => value != null).ToList();
    }
}
