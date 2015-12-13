using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

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
    public GameObject DisplayText;
    public GameObject WonText;

    private string[] texts = { "LOVE", "TOGETHER", "UNIVERSE", "UNITY", "CARE", "HUG", "KISS", "BEAUTY", "WARMTH"};
    private string[] hints = { "LOVE HINT", "TOGETHER HINT", "UNIVERSE HINT", "GAME ENGINE", "CARE HINT", "HUG HINT", "KISS HINT", "BEAUTY HINT", "WARMTH HINT" };

    private static System.Random random = new System.Random();

    private string validText;
    private string currentText;
    private GameObject activeCube;
    private GameObject lastGateEntered;
    private bool isRotating;
    private float initialRotation;
    private float currentRotation;
    private System.Collections.Generic.List<PathItem> fullPath;
    private List<TextMesh> gateTexts;

    // Use this for initialization
    void Start ()
    {
        fullPath = new System.Collections.Generic.List<PathItem>();
        int randomTextIndex = random.Next(0, texts.Length);
        validText = texts[randomTextIndex];
        currentText = "";

        gateTexts = new List<TextMesh>();
        AppendTextMeshes(gateTexts, "Gate1");
        AppendTextMeshes(gateTexts, "Gate2");
        AppendTextMeshes(gateTexts, "Gate3");
        AppendTextMeshes(gateTexts, "Gate4");

        int start = 65;
        int end = 90;
        foreach (var item in gateTexts)
        {
            item.text = ((char)random.Next(start, end)).ToString();
        }

        WonText.SetActive(false);
        DisplayText.GetComponent<UnityEngine.UI.Text>().text = hints[randomTextIndex];
        Debug.Log(validText);
    }

    private static void AppendTextMeshes(List<TextMesh> gateTexts, string tag)
    {
        foreach (var item in GameObject.FindGameObjectsWithTag(tag))
        {
            TextMesh textMesh = item.GetComponent<TextMesh>();
            if (textMesh != null)
                gateTexts.Add(textMesh);
        }
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

        foreach (TextMesh textMesh in gateTexts)
        {
            int start = 65;
            int end = 90;
            if(textMesh.transform.parent.gameObject == activeCube)
            {
                textMesh.text = ((char)random.Next(start, end)).ToString();
            }
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

    internal void SetActiveCube(GameObject newActiveCube)
    {
        activeCube = newActiveCube;
    }

    internal void SetGateEntered(GameObject gateLabel)
    {
        if (lastGateEntered != null)
        {
            lastGateEntered = null;
            return;
        }

        lastGateEntered = gateLabel;
        string cubeName = gateLabel.transform.parent.gameObject.name;
        string gateName = gateLabel.name;
        string gateText = gateLabel.GetComponent<TextMesh>().text;
        PathItem pathItem = new PathItem(cubeName, gateName, gateText);
        fullPath.Add(pathItem);

        if (currentText.Length < validText.Length &&
            pathItem.GateText == validText[currentText.Length].ToString())
        {
            currentText += pathItem.GateText;
            DisplayText.GetComponent<UnityEngine.UI.Text>().text = currentText;

            if(currentText == validText)
            {
                SetYouWin();
            }
        }
    }

    private void SetYouWin()
    {
        WonText.SetActive(true);
        Debug.Log("YUO WIN");
    }
}
