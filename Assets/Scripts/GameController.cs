using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Tags;

/* Provide an user interface for setting game mode, and initialize the game */

public class GameController : MonoBehaviour {

	// Singleton
	public static GameController _instance;

	public GameObject ScenePlayerPrefab;
	public GameObject OculusPlayerPrefab;
	public GameObject SceneObjects;
	public GameObject OculusObjects;
	public GameObject VirtualTags;

	//Prepare gameobjects for game, includes initial its position and statues
	public delegate void OnInitialEvent(); 
	public event OnInitialEvent OnInitial;

	private GameObject player;
	private PlayerController playerController;
	private Vector3 PlayerStartPosition = Vector3.zero;
	private Landmark[] taskLandmarks;
	
	public string playerType = PlayerType.Scene;
	public string entrance = Entrance.Entrance544;
	public string transmitMode = TransmitMode.Stair;
	public string out_in = Out_In.Out;
	public string trainingMode = TrainingMode.SelfExploration;

	void Awake(){
		_instance = this;
		GetModeSetting();
	}
	// Use this for initialization
	void Start () {
		taskLandmarks = TaskGenerater._instance.SetNewTask(entrance, transmitMode, out_in);
		PlayerStartPosition = taskLandmarks[0].position;
		if(trainingMode == TrainingMode.SelfExploration){
				VirtualTags.SetActive(false);
		}
		else if(trainingMode == TrainingMode.PerceptApp){

		}
		if(playerType == PlayerType.Oculus){
				GameObject oculusgo = Instantiate(OculusPlayerPrefab, PlayerStartPosition, Quaternion.identity) as GameObject;
				oculusgo.transform.parent = GameObject.FindGameObjectWithTag(UnityTag.OculusObjects).transform;
				SceneObjects.SetActive(false);
		}else if(playerType == PlayerType.Scene){
				GameObject scenego = Instantiate(ScenePlayerPrefab,  PlayerStartPosition, Quaternion.identity) as GameObject;
				scenego.transform.parent = GameObject.FindGameObjectWithTag(UnityTag.SceneObjects).transform;
				OculusObjects.SetActive(false);
		}

		this.OnInitial += OnPlayerInitial;
		OnInitial();
	}

//	Initialize user settings.
	void GetModeSetting(){
		playerType = PlayerPrefs.GetString("DisplayType");
		entrance = PlayerPrefs.GetString("StartPoint");
		transmitMode = PlayerPrefs.GetString("TransmitType");
		out_in = PlayerPrefs.GetString("DestinationPrefer");
		trainingMode = PlayerPrefs.GetString("TrainingMode");
	}

//	Initialize tasks for self-exploration mode. Disable tasks for PERCEPT app training mode.
	void OnPlayerInitial(){
		player = GameObject.FindGameObjectWithTag(UnityTag.Player);
		if(trainingMode == TrainingMode.SelfExploration){
			player.GetComponent<TaskEvent>().TaskInitial(taskLandmarks);
		}
		else if(trainingMode == TrainingMode.PerceptApp){
			player.GetComponent<TaskEvent>().enabled = false;
		}

	}
}
