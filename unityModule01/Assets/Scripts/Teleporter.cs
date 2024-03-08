using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject teleportTarget;
    void OnTriggerEnter(Collider player)
    {
        player.gameObject.transform.position = teleportTarget.transform.position + new Vector3(0, 0.5f, 0);
    }
}
