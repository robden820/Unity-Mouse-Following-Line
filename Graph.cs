using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    public Transform pointPrefab;
    [Range(10, 100)] public int res = 10;
    private Transform[] points;
    public float speed = 10f;

    void Awake()
    {
        float step = 2f / res;
        Vector3 scale = Vector3.one * step;
        Vector3 position;
        position.y = 0;
        position.z = 0;
        points = new Transform[res];
       for(int i = 0; i < points.Length; i++)
            {
            Transform point = Instantiate(pointPrefab);

            position.x = i * step - 1f;
            point.localPosition = position;
            point.localScale = scale;
            point.SetParent(transform, false);

            points[i] = point;
        }
    }

    void Update()
    {
        for(int i = 0; i < points.Length; i++)
        {
            Transform point = points[i];
            Vector3 position = point.position;
            Vector3 target;
            if (i == 0)
            {
                target = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            }
            else {
                target = points[i-1].position;
            }

            float step = speed * Time.deltaTime * Vector3.Distance(position, target);
            point.position = Vector3.MoveTowards(position, target, step);

        }


    }
}
