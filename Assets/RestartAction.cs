using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RestartAction : MonoBehaviour {

    public void OnRestartClick()
    {
        MainApplication mainApp = GameObject.FindObjectOfType<MainApplication>();
        mainApp.RestartGame();
    }

    public void OnRotateClick()
    {
        MainApplication mainApp = GameObject.FindObjectOfType<MainApplication>();
        mainApp.StartRotateCurrentCube();
    }

    void OnTriggerEnter(Collider other)
    {
        MainApplication mainApp = GameObject.FindObjectOfType<MainApplication>();
        mainApp.SetActiveCube(this.gameObject);
    }
}
