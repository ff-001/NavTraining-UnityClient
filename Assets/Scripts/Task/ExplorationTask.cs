using UnityEngine;
using System.Collections;

/* Define a data structure of task and its properties. */
public class ExplorationTask {

	public bool TriggerState{get; set;}
	public bool TriggerWaiting{get; set;}
	public string Instruction{get; set;}
	public Vector3 BeginPosition{get; set;}
	public Landmark Id{get; set;}
	public long remoteID {get; set;}

	public ExplorationTask(bool triggerState, bool triggerWaiting, string instruction){
		this.TriggerState = triggerState;
		this.TriggerWaiting = triggerWaiting;
		this.Instruction = instruction;
	}

	public ExplorationTask(bool triggerWaiting, string instruction){
		this.TriggerState = false;
		this.TriggerWaiting = triggerWaiting;
		this.Instruction = instruction;
	}

	public ExplorationTask(string instruction, Landmark id, long remoteID){
		this.Id = id;
		this.TriggerState = false;
		this.TriggerWaiting = false;
		this.Instruction = instruction;
		this.BeginPosition = Id.position;
		this.remoteID = remoteID;
	}

	public void ReadInstruction(){
		Debug.Log(Instruction);
		System.Diagnostics.Process.Start("say", (Instruction));
	}

	public void TriggerTask(){
		if(TriggerWaiting){
			this.TriggerState = true;
			this.TriggerWaiting = false;
			Debug.Log("This task is finished");
		}else{
			Debug.LogError("Can't Trigger, Task is not active now");
		}
	}
}
