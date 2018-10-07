using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WordManager : MonoBehaviour
{
    const float WORD_START_X = 11.0f;
    const float HEIGHT_MIN = -2.0f;
    const float HEIGHT_MAX = 4.5f;
    const float WORD_SIZE = 1.0f;

    public class Range
    {
        public float position;
        public float size;
    }

    List<WordMover> commentList = new List<WordMover>();

    /// <summary>
    /// コメントの追加
    /// </summary>
    /// <param name="comment"></param>
    public void AddComment(WordMover comment)
    {
        commentList.Add(comment);
    }
    public Vector3 AdjustmentPosition(WordType type)
    {
        return new Vector3(
            WORD_START_X,
            AdjustmentHeight(),
            WordImage.TypeToDepth(type)
            );
    }
    /// <summary>
    /// 高さの平均
    /// </summary>
    /// <returns></returns>
    public float AverageHeight()
    {
        if (commentList.Count == 0) return 0;
        CheckCommentList();

        float average = commentList.
            Select(value => value.PositionHeight).
            Average();

        if (average > 0) return Random.Range(0, HEIGHT_MAX);
        else return Random.Range(HEIGHT_MIN, 0);
    }
    /// <summary>
    /// 調整した高さを返す
    /// </summary>
    public float AdjustmentHeight()
    {
        if (commentList.Count == 0) return AverageHeight();
        CheckCommentList();

        // 生成ラインと被っているコメントの昇順配列
        WordMover[] array = OrderByRangeComment(commentList);

        // 例外処理
        if (array.Length == 0) return AverageHeight();

        // 空いてる範囲の配列
        Range[] spaceRangeArray = GetSpaceRangeArray(array);

        foreach(Range range in spaceRangeArray)
        {
            Debug.Log("pos" + range.position + ",size" + range.size);
        }

        // スペースがあるかどうか
        if (!IsSpace(spaceRangeArray)) {
            Debug.Log("NoSpace");
            return AverageHeight();
        }
        Debug.Log("Space");
        // 最も空いている空間を取得
        Range space = GetMostSpaceRange(spaceRangeArray);
        Debug.Log("mose:pos" + space.position + ",size" + space.size);

        return space.position + (Random.Range(0, space.size - WORD_SIZE)) + WORD_SIZE * 0.5f;
    }
    /// <summary>
    /// Listの中身を確認する
    /// </summary>
    void CheckCommentList()
    {
        commentList = commentList.Where(value => value != null).ToList();
    }
    /// <summary>
    /// 出現位置に被っているコメントを昇順で返す
    /// </summary>
    WordMover[] OrderByRangeComment(List<WordMover> comments)
    {
        return comments.
            Where(value => value.WordEndX > WORD_START_X).
            OrderBy(value => value.PositionHeight).
            ToArray();
    }
    /// <summary>
    /// 空いている範囲
    /// </summary>
    Range[] GetSpaceRangeArray(WordMover[] comments)
    {
        List<Range> rangeList = new List<Range>();
        float firstSize = (HEIGHT_MIN >= comments.First().GetRect.position.y) ? 0 : comments[0].GetRect.position.y - HEIGHT_MIN;
        rangeList.Add(new Range { position = HEIGHT_MIN, size = firstSize });

        for(int i = 0; i < comments.Length - 1; ++i)
        {
            if (comments[i].IsCollision(comments[i + 1].GetRect)) continue;

            float pos = comments[i].GetRect.position.y + comments[i].GetRect.size.y;
            float range = comments[i + 1].GetRect.position.y - pos;
            rangeList.Add(new Range { position = pos, size = range });
        }

        if(rangeList[rangeList.Count - 1].position + rangeList[rangeList.Count - 1].size < HEIGHT_MAX)
        {
            float pos = comments[comments.Length - 1].GetRect.position.y + WORD_SIZE;
            rangeList.Add(new Range { position = pos, size = HEIGHT_MAX - pos });
        }

        return rangeList.ToArray();
    }

    ///// <summary>
    ///// コメントを差し込む隙間があるかどうか
    ///// </summary>
    bool IsSpace(Range[] array)
    {
        return array.
            Any(value => value.size >= WORD_SIZE);
    }
    /// <summary>
    /// 最もスペースの空いている空間
    /// </summary>
    /// <param name="array"></param>
    /// <returns></returns>
    Range GetMostSpaceRange(Range[] array)
    {
        return array.
            Where(value => value.size >= WORD_SIZE).
            OrderByDescending(value => value.size).
            First();
    }
}
