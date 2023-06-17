using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChange : MonoBehaviour
{
    public Action<int> Switched;

    private void OnEnable()
    {
        Switched += ChangePositionX;
    }

    private void OnDisable()
    {
        Switched -= ChangePositionX;
    }

    public void ChangePositionX(int xPos)
    {
        transform.position = new Vector3(xPos, -1.77f, 0f);
        Debug.Log("Trocoulis");
    }

    private void Start()
    {
        Switched?.Invoke(7);
    }
}
