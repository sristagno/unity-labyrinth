using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomScript : MonoBehaviour
{
    [SerializeField] private float speed = 4f;

    [SerializeField] private Transform targetStart;
    [SerializeField] private Transform targetEnd;

    private Transform target;

    private void Start()
    {
        target = targetEnd;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            GameObject.Find("Player").GetComponent<PlayerController>().GameOver();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == target.position)
        {
            target = target == targetEnd ? targetStart : targetEnd;
        }
        transform.Rotate(2f, 2f, 2f);
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        
    }
}
