using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePointCapturer : MonoBehaviour {

    public static List<List<Vector2>> lines = new List<List<Vector2>>();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            lines.Add(new List<Vector2>());
        }
        if (Input.GetMouseButton(0) && lines.Count > 0)
        {
            Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lines[lines.Count - 1].Add(point);
        }
	}
}
