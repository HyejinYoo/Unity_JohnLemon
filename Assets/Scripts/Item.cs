using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public GameObject player;
    public GameObject item;
    public float ItemSpeedAdd = (float)0.5;
    public AudioSource getItem;

    void OnTriggerEnter(Collider other)
    {
        if (other.transform == player.transform)
        {
            getItem.Play();
            player.GetComponent<PlayerMovement>().m_MoveSpeed += ItemSpeedAdd;
            item.SetActive(false);
        }
    }

}
