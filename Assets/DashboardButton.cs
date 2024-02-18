using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DashboardButton : MonoBehaviour
{   


    [SerializeField] GameObject panelObject;
    public TMP_Text messageText;

    public void toggleButton () {
        if (panelObject.activeInHierarchy) {
            panelObject.SetActive(false);
            gameObject.SetActive(true);    
            messageText.SetText("Dashboard");

        }
        else {
            panelObject.SetActive(true);
            gameObject.SetActive(false);    
            messageText.SetText("Close");

        }

    }
}
