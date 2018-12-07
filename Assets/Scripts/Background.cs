using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSize;

    Vector3 startPosition;

    void Awake()
    {
        //DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSize);
        transform.position = startPosition + Vector3.down * newPosition;

        if (Score.score >= 300 && Score.score < 500) scrollSpeed = 3;
        if (Score.score >= 500 && Score.score < 700) scrollSpeed = 7;
        if (Score.score >= 700) scrollSpeed = 11;
    }
}
