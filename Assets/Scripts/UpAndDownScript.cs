using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAndDownScript : MonoBehaviour
{

    [SerializeField] float speed = 1f;
    [SerializeField] float height = 1f;
    private Vector3 startPos;
    private Vector3 endPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        endPos = new Vector3(transform.position.x, transform.position.y + height, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        float t = Mathf.PingPong(Time.time * speed, 1);
        transform.position = Vector3.Lerp(startPos, endPos, t);
    }
}
