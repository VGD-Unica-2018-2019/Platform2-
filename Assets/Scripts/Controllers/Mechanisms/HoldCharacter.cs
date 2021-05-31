using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldCharacter : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.parent = transform;
        }
        else if (other.transform.root.CompareTag("Player"))
        {
            other.transform.parent = transform.root;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.transform.root.CompareTag("Player"))
        {
            other.transform.parent = null;
        }
    }
}
