using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InGameUIController : MonoBehaviour
{
    public static TextMeshProUGUI scoreMesh;

    void Start()
    {
        scoreMesh = this.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    public static void SetScore(int score)
    {
        scoreMesh.text = score.ToString();
    }
}
