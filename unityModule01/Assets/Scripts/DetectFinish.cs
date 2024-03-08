using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectFinish : MonoBehaviour
{
    private GameObject outlineSphere;
    private MeshRenderer outlineMR;
    private SphereCollider outlineSC;
    private DetectFinish finishThomas;
    private DetectFinish finishJohn;
    private DetectFinish finishClaire;
    public bool finished = false;
    void Start()
    {
        finished = false;
        outlineSphere = GameObject.Find("S" + gameObject.name);
        outlineMR = outlineSphere.GetComponent<MeshRenderer>();
        outlineSC = outlineSphere.GetComponent<SphereCollider>();
        finishThomas = GameObject.Find("F_Thomas").GetComponent<DetectFinish>();
        finishJohn = GameObject.Find("F_John").GetComponent<DetectFinish>();
        finishClaire = GameObject.Find("F_Claire").GetComponent<DetectFinish>();
    }

    void Update()
    {
        if (finishThomas.finished == true && finishJohn.finished == true && finishClaire.finished == true && gameObject.name == "F_Thomas")
        {
            print("Level Finished!");
            if (SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                else
                    SceneManager.LoadScene(0);
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if ("F_" + collider.gameObject.name == gameObject.name)
        {
            finished = true;
            outlineMR.enabled = true;
            outlineSC.enabled = true;
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if ("F_" + collider.gameObject.name == gameObject.name)
        {
            finished = false;
            outlineMR.enabled = false;
            outlineSC.enabled = false;
        }
    }
}
