using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField] Transform pointPrefab;
    [SerializeField, Range(10, 100)] int resolution = 10;

    private Transform[] points;

    private void Awake()
    {
        // initiating points with x in range [-1, 1]
        points = new Transform[resolution];
        float step = 2f / resolution;
        Vector3 position = Vector3.zero;
        var scale = Vector3.one * step;
        for (int i = 0; i < points.Length; i++)
        {
            var point = points[i] = Instantiate(pointPrefab, transform, false);
            position.x = (i + 0.5f) * step - 1f;
            point.localPosition = position;
            point.localScale = scale;
        }
    }

    private void Update()
    {
        float time = Time.time;
        foreach (var p in points)
        {
            Vector3 position = p.position;
            position.y = Mathf.Cos(Mathf.PI * (position.x + time));
            p.localPosition = position;
        }
    }
}