using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class NumberOrderMiniGame : MonoBehaviour
{
    [SerializeField] int nextButton;

    [SerializeField] GameObject collider;
    [SerializeField] GameObject GamePanel;
    [SerializeField] GameObject[] myObjects;

    
    public TMP_Text buttonText;
    
    BoxCollider boxCollider;
    //Use this to change the hierarchy of the GameObject siblings
    void Start()
    {
        nextButton = 0;
        
    }

    public void NextScene(int sceneIndex) {
        Debug.Log("Move to next scene");
        SceneManager.LoadScene(sceneIndex);
    }
    private void OnEnable()  //Gets called when the game object this script is attached to becomes active
    {
        nextButton = 0;
        for (int i = 0; i < myObjects.Length; i++)
        {
            myObjects[i].transform.SetSiblingIndex(Random.Range(0, 2)); 
            //transform.SetSiblingIndex(Random.Range(0, 9)); 
        }
    }   
   
    public void ButtonOrder(int button)
    {
        Debug.Log("Pressed");
        if (button == nextButton)
        {
            nextButton++;
            Debug.Log("Next Button" + nextButton);
            myObjects[button].SetActive(false);
        }
        else
        {
            Debug.Log("Faild");
            Debug.Log("Next Button" + nextButton);
            nextButton = 0;
            myObjects[button].SetActive(true);
            OnEnable();
        }
        if (button == 2 && nextButton == 3)
        {
            Debug.Log("Pass");
            nextButton = 0;
            Player.balance += 300;
            Player.done +=1;
            Debug.Log(Player.balance);

            NextScene(0);

        }
        
    }
    public void ButtonOrderPanelClose() //Set this function to the close button On click in the inspector
    {
        GamePanel.SetActive(false);
        NextScene(0);
    }
    public void ButtonOrderPanelOpen() //Set this function to the Play or Open button On click in the inspector
    {
        GamePanel.SetActive(true);
    }
}