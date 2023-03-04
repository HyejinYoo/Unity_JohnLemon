using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void OnClick()
    {
        UnityEngine.Debug.Log("click");
        SceneManager.LoadScene(0);
    }
}
