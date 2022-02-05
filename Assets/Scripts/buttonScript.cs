using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class buttonScript : MonoBehaviour
{ 
    public void onButtonPressed() {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        timerScript.inst.startTime = 0f;
        SceneManager.LoadScene("gameMenu");
    }
}
