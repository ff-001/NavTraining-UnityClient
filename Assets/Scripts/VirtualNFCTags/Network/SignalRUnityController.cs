using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using uSignalR.Hubs;
using JetBrains.Annotations;
using uTasks;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public class Message{
	public string username {get;set;}
	public string usermessage {get;set;}
}

public class SignalRUnityController : MonoBehaviour {
//	[SerializeField] private Text _resultText;

	public static SignalRUnityController _instance;

	private CancellationTokenSource _tokenSource;
	
	bool useSignalR = true;
	string signalRUrl = "http://perceive.azurewebsites.net/";
	//string signalRUrl = "http://percept.ecs.umass.edu/perceptsiri";
	//string signalRUrl = "http://sis2.ecs.umass.edu/SignalRChat/";
	
	string result = null ;
	
	private HubConnection _hubConnection = null;
	private IHubProxy _hubProxy;

	public Subscription _subscription;
	public Subscription _taskSubscription;
	public Subscription _loginSubscription;
	public Subscription _trainingSubscription;

	public static string Username;
	public static int TrainingId;

	public static string TrainingPosition {get; set;}
	public static int CurrentTask{get; set;}

	void Awake(){
		if (_instance == null)
		{
			_instance = this;
		}
		MainThread.Current = new UnityMainThread();
	}
	
	void Start()
	{
		_tokenSource = new CancellationTokenSource();
		TaskFactory.StartNew(() => StartSignalR(_tokenSource.Token))
			.CompleteWithAction(task =>
			                    {
				if (task.IsCanceled)
				{
					return;
				}
//				Debug.Log(task.ToString());

			});
	}

	public string GetTrainingPosition()
	{
		return TrainingPosition;
	}

	void Update(){
		if(result != null){
			//			_resultText.text = result;
			result = null;
		}

		if (Input.GetKeyDown(KeyCode.S))
		{

		}
	}

	void StartSignalR(CancellationToken token)
	{
		if (_hubConnection == null)
		{
			_hubConnection = new HubConnection(signalRUrl);

			_hubProxy = _hubConnection.CreateProxy("SignalRHub");

			_subscription = _hubProxy.Subscribe("broadcastMessage");
			_taskSubscription = _hubProxy.Subscribe("getTask");
			_loginSubscription = _hubProxy.Subscribe("login");
			_trainingSubscription = _hubProxy.Subscribe("getTraining");

			_loginSubscription.Data += OnLog;
			_trainingSubscription.Data += OnTrainingRecording;
//			_taskSubscription.Data += data =>
//			{
//				Debug.Log("signalR called us back");
//			};
			//_subscription.Data += OnData;
			_hubConnection.Start();
			
			//			_hubProxy.Invoke("PairDevices", groupName);
			//			Tag tag = new Tag() {
			//				Id = "testing123",
			//				DeviceId = groupName
			//			};
			//			_hubProxy.Invoke("ScanTagVirtual",tag);
			//			Message msg = new Message(){
			//				username = "Unity",
			//				usermessage = "hello"
			//			};
			//			_hubProxy.Invoke("send", msg);
			
		}
		else
			Debug.Log("Signalr already connected...");
		
	}

	void OnLog(object[] data)
	{
		string response = data[0].ToString();
		if (response == "Success")
		{
			Username = data[1].ToString();
		}
	}

	void OnTrainingRecording(object[] data)
	{
		Debug.Log("back");
		TrainingId = Convert.ToInt32(data[0].ToString());
		TrainingPosition = data[1].ToString();
		CurrentTask = Convert.ToInt32(data[2].ToString());

	}

	void OnData(object[] data)
	{
		IList collection = (IList)data[0];
		IEnumerable<TaskObject> node = JsonConvert.DeserializeObject<IEnumerable<TaskObject>>(data[0].ToString());
		foreach (TaskObject i in node){
			TaskObject t = i;
		}
		result = data[0]+":"+data[1];
		Debug.Log(data[0]+":"+data[1]);
	} 
	
	public void Send(string message)
	{
		if (!useSignalR)
			return;
		_hubProxy.Invoke("send", "Unity", 
		                 message);
	}

	public void UpdatePosition(string position, int trainingType, long taskID)
	{
		if (!useSignalR)
			return;
		_hubProxy.Invoke("updatepause", Username, trainingType, position, taskID);
	}

	public void TaskRequest()
	{
		if (!useSignalR)
			return;
		_hubProxy.Invoke("taskrequest", TrainingId);
	}

	public void Login(string username, string password)
	{
		if (!useSignalR)
			return;
		_hubProxy.Invoke("userlogin", username, password);
	}

	public void Logout()
	{
		if (!useSignalR)
			return;
		_hubProxy.Invoke("userlogout", Username);
	}

	public void GetTraining(int trainingType)
	{
		if (!useSignalR)
			return;
		_hubProxy.Invoke("gettraining", Username, trainingType);
	}

	public void Finished()
	{
		if (!useSignalR)
			return;
		_hubProxy.Invoke("finish", TrainingId);
	}

	public void FaultRecord(long ct)
	{
		if (!useSignalR)
			return;
		_hubProxy.Invoke("fault", TrainingId, ct);
	}
}

