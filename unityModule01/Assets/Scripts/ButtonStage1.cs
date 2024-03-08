using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStage1 : MonoBehaviour
{
    private GameObject wall;
    private MeshRenderer wallMR;
    private MeshCollider wallMC;
    private GameObject outlineSphere;
    private MeshRenderer outlineMR;
    private SphereCollider outlineSC;
    // Start is called before the first frame update
    void Start()
    {
        wall = GameObject.Find("WallM");
        wallMR = wall.GetComponent<MeshRenderer>();
        wallMC = wall.GetComponent<MeshCollider>();
        outlineSphere = GameObject.Find("S_" + gameObject.name);
        outlineMR = outlineSphere.GetComponent<MeshRenderer>();
        outlineSC = outlineSphere.GetComponent<SphereCollider>();
    }
    void OnTriggerEnter(Collider collider)
    {
        wallMR.enabled = false;
        wallMC.enabled = false;
        outlineMR.enabled = true;
        outlineSC.enabled = true;
    }
}
