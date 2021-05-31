using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform: MonoBehaviour
{
    bool isFalling = false;
    float downSpeed = 0;
    public float seconds = 0;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(WaitBeforeFall());
            Destroy(gameObject, 5);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isFalling)
        {
            downSpeed += Time.deltaTime/10;
            transform.position = new Vector3(transform.position.x, transform.position.y - downSpeed, transform.position.z);
        }
    }

    IEnumerator WaitBeforeFall()
    {
        yield return new WaitForSeconds(seconds);
        isFalling = true;
    }
}
