using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinScript : MonoBehaviour
{
    public float turnSpeed = 90f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "viking") {
            return;
        }

        Destroy(gameObject);
        GameManager.inst.incrementScore();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }
}
