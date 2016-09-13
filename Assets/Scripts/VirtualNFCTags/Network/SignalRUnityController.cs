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

public class Message{
	public string username {get;set;}
	public string usermessage {get;set;}
}

public class SignalRUnityController : MonoBehaviour {
//	[SerializeField] private Text _resultText;

	private CancellationTokenSource _tokenSource;
	
	bool useSignalR = true;
	string signalRUrl = "http://perceiveserver.azurewebsites.net";
	//string signalRUrl = "http://percept.ecs.umass.edu/perceptsiri";
	//string signalRUrl = "http://sis2.ecs.umass.edu/SignalRChat/";
	
	string result = null ;
	
	private HubConnection _hubConnection = null;
	private IHubProxy _hubProxy;
	
	public Subscription _subscription;
	public Subscription _taskSubscription;

	void Awake(){
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

	void Update(){
		if(result != null){
			//			_resultText.text = result;
			result = null;
		}

		if (Input.GetKeyDown(KeyCode.S))
		{
			UpdatePosition("HaoD", 1, "x = 7", 3);
		}
	}

	void StartSignalR(CancellationToken token)
	{
		if (_hubConnection == null)
		{
			_hubConnection = new HubConnection(signalRUrl);
			
			//			_hubProxy = _hubConnection.CreateProxy("SmartphoneHub");
			//			_subscription = _hubProxy.Subscribe("test");
			_hubProxy = _hubConnection.CreateProxy("SignalRHub");
			_subscription = _hubProxy.Subscribe("broadcastMessage");
			_taskSubscription = _hubProxy.Subscribe("getTask");
			_taskSubscription.Data += data =>
			{
				Debug.Log("signalR called us back");
			};
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

	public void UpdatePosition(string username, int trainingID, string position, long taskID)
	{
		if (!useSignalR)
			return;
		if (trainingID == 2)
		{
			taskID = -1;
		}
		_hubProxy.Invoke("updatepause", username, trainingID, position, taskID);
	}

	public void TaskRequest(long TrainingId)
	{
		if (!useSignalR)
			return;
		_hubProxy.Invoke("taskrequest", 9);
	}
	
}

