using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    public void OnClick()
    {
        UnityEngine.Debug.Log("click");
        Application.Quit();
    }
}
