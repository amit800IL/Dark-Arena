using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
   public void GlassArena()
    {
        SceneManager.LoadScene("Glass Arena");
    }

    public void MetalArena()
    {
        SceneManager.LoadScene("Metal Arena");
    }
}
