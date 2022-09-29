using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiffcultyManager : MonoBehaviour
{

    private void Awake()
    {
        PlayerPrefs.SetInt("Diff", 0);
    }
    public void SetDiffculty(int Diffculty)
    {
        PlayerPrefs.SetInt("Diff", Diffculty);
    }
}
