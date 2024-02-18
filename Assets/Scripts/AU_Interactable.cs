using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AU_Interactable : MonoBehaviour
{
    [SerializeField] GameObject miniGame;
    GameObject highlight;
    private void OnEnable()
    {
        highlight = transform.gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            highlight.SetActive(true);
            Debug.Log("hi");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            // highlight.SetActive(false);
        }
    }
    public void PlayMiniGame()
    {
        miniGame.SetActive(true);
    }
}