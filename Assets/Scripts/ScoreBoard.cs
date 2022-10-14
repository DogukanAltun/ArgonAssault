using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    private int TotalPoint = 0;
    private TMP_Text TMP;

    private void Start()
    {
        TMP = GetComponent<TMP_Text>();
        TMP.text = "Start";
    }
    public void IncreasedPoint (int PointForPerHit)
    {
        TotalPoint += PointForPerHit;
        TMP.text = TotalPoint.ToString();
        Debug.Log("Total Point is" + TotalPoint);
    }
}
