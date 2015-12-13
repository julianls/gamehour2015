using UnityEngine;
using System.Collections;
using System.Linq;

public class GateColisionScript : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        string labelTag = gameObject.tag;
        GameObject gateLabel = GameObject.FindGameObjectsWithTag(labelTag).SingleOrDefault(
            item => item.transform.parent.gameObject == gameObject.transform.parent.parent.parent.gameObject);
        MainApplication mainApp = GameObject.FindObjectOfType<MainApplication>();
        mainApp.SetGateEntered(gateLabel);
    }
}
