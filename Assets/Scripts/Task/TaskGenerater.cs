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
	private string out_in;

	private Path pathClass;

	void Awake(){
		_instance = this;
		pathClass = new Path();
	}

	public Landmark[] SetNewTask(string e, string  t, string  oi){
		Landmark[] taskLandmarks = null;
		this.entrance = pathClass.GetEntranceString(e);
		this.transmitMode = t;
		this.out_in = oi;
		taskLandmarks = NewPath();
		return taskLandmarks;
	}
	
	private Landmark[] NewPath() {
		if(out_in == Out_In.Out){
			taskPathString= entrance+"To"+"RightWaitingLine"+"By"+transmitMode;
		}else{
			taskPathString= entrance+"To"+"LeftWaitingLine"+"By"+transmitMode;
		}
		Debug.Log("Current Task: Entrance545ToRightWaitingLineByStair");
		return pathClass.getPathbyName(taskPathString);
	}
	
}
