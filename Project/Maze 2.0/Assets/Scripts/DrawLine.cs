﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class DrawLine : MonoBehaviour {

	private LineRenderer line;
	private bool isMousePressed;

	public List<Vector3> pointsList;
	private Vector3 mousePos;
	private Vector2 _offset;

	// Structure for line points
	struct myLine
	{
		public Vector3 StartPoint;
		public Vector3 EndPoint;
	};
	//    -----------------------------------    
	void Awake ()
	{
		// Create line renderer component and set its property
		line = gameObject.AddComponent<LineRenderer> ();
		line.material = new Material (Shader.Find ("Particles/Additive"));
		line.SetVertexCount (0);
		line.SetWidth (0.1f, 0.1f);
		line.SetColors (Color.green, Color.green);
		line.useWorldSpace = true;
		isMousePressed = true;
		pointsList = new List<Vector3> ();
		//        renderer.material.SetTextureOffset(
	}
	//    -----------------------------------  

	void Update ()
	{
		if (GameObject.Find ("Planningmap").GetComponent<Camera> ().enabled == true) {

			//this.transform.position(pare
			// If mouse button down, remove old line and set its color to green
			if (Input.GetMouseButtonDown (0)) {
				//			_offset = eventData.position - new Vector2 (this.transform.position.x, this.transform.position.y);
				//			this.transform.position = eventData.position - _offset;
				isMousePressed = true;
				line.SetVertexCount (0);
				//pointsList.RemoveRange (0, pointsList.Count);
				line.SetColors (Color.green, Color.green);
			}

			if (Input.GetMouseButtonUp (0)) {
				Debug.Log ("mouseup");
				isMousePressed = false;
				line.SetColors (Color.red, Color.red);
			}

			if (Input.GetMouseButtonDown (1)) {
				line.SetVertexCount (0);
				Debug.Log ("right click");
				pointsList.RemoveRange (0, pointsList.Count);
			}

		// Drawing line when mouse is moving(presses)
		else if (isMousePressed) {
				mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				//mousePos = GameObject.FindWithTag("Planningmap")
				//mousePos = GameObject.Find("Planningmap") (Input.mousePosition);
				mousePos.z = -2;
				//mousePos.x = 1;
				//mousePos.y = 1;
				if (!pointsList.Contains (mousePos)) {
					pointsList.Add (mousePos);
					line.SetVertexCount (pointsList.Count);
					line.SetPosition (pointsList.Count - 1, (Vector3)pointsList [pointsList.Count - 1]);
					//				if (isLineCollide ()) {
					//					isMousePressed = false;
					//					line.SetColors (Color.red, Color.red);
					//				}
				}
			}
		}
	}
	//    -----------------------------------    
	// Following method checks is currentLine(line drawn by last two points) collided with line
	//    -----------------------------------    
	//	private bool isLineCollide ()
	//	{
	//		if (pointsList.Count < 2)
	//			return false;
	//		int TotalLines = pointsList.Count - 1;
	//		myLine[] lines = new myLine[TotalLines];
	//		if (TotalLines > 1) {
	//			for (int i=0; i<TotalLines; i++) {
	//				//lines [i].StartPoint = (Vector3)pointsList [i];
	//				//lines [i].EndPoint = (Vector3)pointsList [i + 1];
	//			}
	//		}
	//		for (int i=0; i<TotalLines-1; i++) {
	//			myLine currentLine;
	//			currentLine.StartPoint = (Vector3)pointsList [pointsList.Count - 2];
	//			currentLine.EndPoint = (Vector3)pointsList [pointsList.Count - 1];
	//			if (isLinesIntersect (lines [i], currentLine))
	//				return true;
	//		}
	//		return false;
	//	}
	//    -----------------------------------    
	//    Following method checks whether given two points are same or not
	//    -----------------------------------    
	//	private bool checkPoints (Vector3 pointA, Vector3 pointB)
	//	{
	//		return (pointA.x == pointB.x && pointA.y == pointB.y);
	//	}
	//    -----------------------------------    
	//    Following method checks whether given two line intersect or not
	//    -----------------------------------    
	//	private bool isLinesIntersect (myLine L1, myLine L2)
	//	{
	//		if (checkPoints (L1.StartPoint, L2.StartPoint) ||
	//			checkPoints (L1.StartPoint, L2.EndPoint) ||
	//			checkPoints (L1.EndPoint, L2.StartPoint) ||
	//			checkPoints (L1.EndPoint, L2.EndPoint))
	//			return false;
	//
	//		return((Mathf.Max (L1.StartPoint.x, L1.EndPoint.x) >= Mathf.Min (L2.StartPoint.x, L2.EndPoint.x)) &&
	//			(Mathf.Max (L2.StartPoint.x, L2.EndPoint.x) >= Mathf.Min (L1.StartPoint.x, L1.EndPoint.x)) &&
	//			(Mathf.Max (L1.StartPoint.y, L1.EndPoint.y) >= Mathf.Min (L2.StartPoint.y, L2.EndPoint.y)) &&
	//			(Mathf.Max (L2.StartPoint.y, L2.EndPoint.y) >= Mathf.Min (L1.StartPoint.y, L1.EndPoint.y))
	//		);
	//	}
}