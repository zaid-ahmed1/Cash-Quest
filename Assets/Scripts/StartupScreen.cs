using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartupScreen : MonoBehaviour
{

    public void NextScene(int sceneIndex) {
        Debug.Log("Move to next scene");
        SceneManager.LoadScene(sceneIndex);
    }

    public void DestroyButton(GameObject g) {

        Debug.Log("Destroy");
        Destroy(g, 1f);

    }


    public void NextScenePurchase(int sceneIndex) {
        Player.balance -= 400;
        Debug.Log("Move to next scene");
        SceneManager.LoadScene(sceneIndex);
    }

}
