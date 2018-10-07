using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBar : MonoBehaviour
{
    const float BAR_LENGTH = 1660.0f;

    [SerializeField] GameTimer     gameTimer;
    [SerializeField] RectTransform barNob;

    //=====================================================
	void Update ()
    {
        MoveBar();
	}
    //=====================================================

    void MoveBar()
    {
        Vector3 pos = barNob.localPosition;
        pos.x = BAR_LENGTH * gameTimer.TimeRate;
        barNob.localPosition = pos;
    }
}
