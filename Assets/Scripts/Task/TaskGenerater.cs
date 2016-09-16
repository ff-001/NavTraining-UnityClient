using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Tags;

/* Set up new task chain based on the select path. */
public class TaskGenerater : MonoBehaviour {
	[HideInInspector]
	public string taskPathString;
	public static TaskGenerater _instance;

	private string entrance;
	private string transmitMode;
	private string destination;

	private Path pathClass;

	void Awake(){
		_instance = this;
		pathClass = new Path();
	}

	public Landmark[] SetNewTask(string e, string  t, string  d){
		Landmark[] taskLandmarks = null;
		this.entrance = pathClass.GetEntranceString(e);
		this.transmitMode = t;
		this.destination = d;
		taskLandmarks = NewPath();
		return taskLandmarks;
	}
	
	private Landmark[] NewPath() {
		taskPathString= entrance+"To"+destination+"By"+transmitMode;
		Debug.Log("Current Task: " + taskPathString);
		return pathClass.getPathbyName(taskPathString);
	}
	
}
