using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody _rb;
    private float _elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.AddForce(new Vector3(0, 0, 100f));
    }

    // Update is called once per frame
    void Update()
    {
        _elapsedTime += Time.deltaTime;
        if(_elapsedTime > 5.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
