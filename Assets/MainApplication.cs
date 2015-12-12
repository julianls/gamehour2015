using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class MainApplication : MonoBehaviour {

    public GameObject Character;
    public GameObject Cube1;
    public GameObject Cube2;
    public GameObject Cube3;
    public GameObject Cube4;
    public GameObject Cube5;
    public GameObject Cube6;
    public GameObject Cube7;
    public GameObject Cube8;
    public GameObject Cube9;

    public GameObject activeCube;
    public string currentText;

    private bool isRotating;
    private float initialRotation;
    private float currentRotation;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	    if(isRotating)
        {
            BeforeRotateCurrentCube();

            currentRotation += 1f;
            if(90f - currentRotation < 5)
            {
                currentRotation = 90f;
                isRotating = false;
            }

            RotateCurrentCube();
        }
	}

    public void RestartGame()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
        activeCube = Cube1;
    }

    public void StartRotateCurrentCube()
    {
        if (isRotating)
            return;
        isRotating = true;
        initialRotation = activeCube.transform.rotation.eulerAngles.y;
        currentRotation = 0.0f;
        if (initialRotation > 250f)
        {
            initialRotation = -initialRotation;
            RotateCurrentCube();
            initialRotation = 0f;
        }
    }

    private void BeforeRotateCurrentCube()
    {
        if (activeCube != null)
        {
            Vector3 position = activeCube.GetComponent<Collider>().bounds.center;
            activeCube.transform.RotateAround(position, Vector3.up, initialRotation - currentRotation);
        }
    }

    private void RotateCurrentCube()
    {
        if (activeCube != null)
        {
            Vector3 position = activeCube.GetComponent<Collider>().bounds.center;
            activeCube.transform.RotateAround(position, Vector3.up, initialRotation + currentRotation);
        }
    }

    internal void SetActiveCube(GameObject gameObject)
    {
        activeCube = gameObject;
    }
}
