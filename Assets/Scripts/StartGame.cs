using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void ChangeScene()
    {
        if (GlobalVariables.SelectedBlade == null)
        {
            Debug.Log("No blade selected");
            return;
        }

        if(GlobalVariables.SelectedBlade == null)
        {
            Debug.Log("No blade selected");
            return;
        }

        if(GlobalVariables.SelectedRatchet == null)
        {
            Debug.Log("No ratchet selected");
            return;
        }   

        SceneManager.LoadScene("JiriTemplateScene");
    }
}
