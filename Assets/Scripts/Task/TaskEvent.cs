using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Tags;

/* Will attach to player to trigger the tasks. */
public class TaskEvent : MonoBehaviour {

	TaskLinkedList<ExplorationTask> taskLinkedList;
	public TaskNode<ExplorationTask> currentTask;
	Graph mapGraph;
	List<Edge> testList;
	Vector3 PlayerStartPosition = Vector3.zero;
	private SignalRUnityController signalR;

	bool initial = false;

	Landmark[] taskLandmarks;

	void Awake(){
		taskLinkedList = new TaskLinkedList<ExplorationTask>();
		mapGraph = new Graph();
		signalR = GameObject.FindGameObjectWithTag(UnityTag.SignalR).GetComponent<SignalRUnityController>();
	}

	public void Setup(Landmark[] _taskLandmarks)
	{
		this.taskLandmarks = _taskLandmarks;
		signalR._taskSubscription.Data += OnTaskLoading;
	}

	// Initialize the tasks, get current task.
	public void TaskInitial(){
		signalR.TaskRequest(9);
	}

	void OnTaskLoading(object[] data)
	{
		IEnumerable<TaskObject> node = JsonConvert.DeserializeObject<IEnumerable<TaskObject>>(data[0].ToString());
		foreach (TaskObject t in node){
			mapGraph.LoadingTasks(t); 
		}
		testList = mapGraph.FindWay(taskLandmarks);
		foreach(Edge c in testList){
			taskLinkedList.Add(new ExplorationTask(c.Instruction, c.StartPoint, c.remoteTaskID));
			Debug.Log(c.StartPoint.name);
		}
		currentTask = taskLinkedList.FindNode(1);
		currentTask.Data.TriggerWaiting = true;
		TriggerCurTask();
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			TaskInitial();
		}
		if(Input.GetKeyDown(KeyCode.Escape)){
			BackToPrevTask();
		}
	}

	void TriggerCurTask(){
		if(currentTask.Data.TriggerWaiting){
			currentTask.Data.TriggerTask();

			currentTask.Data.ReadInstruction();
			if(currentTask.Next != null){
				currentTask = currentTask.Next;
				currentTask.Data.TriggerWaiting = true;
			}
		}
	}

	void BackToPrevTask(){
		currentTask = currentTask.Prev;
		this.transform.position = currentTask.Data.BeginPosition;// sent the play to prev task position
		if(currentTask != null){
			currentTask.Data.TriggerWaiting = true;
		}
	}

	void OnTriggerEnter(Collider other){
		if (GameController._instance.trainingMode == TrainingMode.SelfExploration && initial == false && taskLinkedList.Count == 0)
		{
			System.Diagnostics.Process.Start("say", "Are you ready? Please press space button to accept your tasks?");
			initial = true;
		}
		if(currentTask != null){
			if(other.gameObject.name == currentTask.Data.Id.name){
				TriggerCurTask();
			}
		}
	}
}
