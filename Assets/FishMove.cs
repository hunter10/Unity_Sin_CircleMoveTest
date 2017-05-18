using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMove : MonoBehaviour {

    // WaveMove
    public float amplitude = 1;    // 진폭
    [HideInInspector]
    public float frequency = 1;    // 1주기
    [HideInInspector]
    public float speed = 0.1f;

    // WaveMove2
    public float horizontalSpeed;
    public float verticalSpeed = 1;
    
    // Circle Move
    [HideInInspector]
    public float width = 2f ;
    [HideInInspector]
    public float height = 2f;
    
    float timeCounter = 0;

    public Vector3 tempPosition;

    private void Start()
    {
        tempPosition = transform.position;
    }

    // Update is called once per frame
    void Update () {
        //WaveMove();
        //CircleMove();
    }

    void WaveMove()
    {
        Vector3 moveZ = new Vector3(0, 0, speed * Time.deltaTime);
        transform.position += amplitude * (Mathf.Sin(2 * Mathf.PI * frequency * Time.time) - Mathf.Sin(2 * Mathf.PI * frequency * (Time.time - Time.deltaTime))) * transform.right;
        transform.position += moveZ;
        
        //print(transform.position);
    }

    void WaveMove2()
    {
        tempPosition.x += horizontalSpeed;
        tempPosition.y = Mathf.Sin(Time.realtimeSinceStartup * verticalSpeed) * amplitude;
        transform.position = tempPosition;
    }

    private void FixedUpdate()
    {
        WaveMove2();
    }

    void CircleMove()
    {
        timeCounter += Time.deltaTime * speed;
        float x = Mathf.Cos(timeCounter) * width;
        float y = Mathf.Sin(timeCounter) * height;
        float z = 0;

        transform.position = new Vector3(x, y, z);
    }
}
