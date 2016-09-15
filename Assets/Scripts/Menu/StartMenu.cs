using UnityEngine;
using System.Collections;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System;

public class StartMenu : MonoBehaviour {

	public UIPopupList DisplayTypeList;
	public UIPopupList StartPointList;
	public UIPopupList TransmitTypeList;
	public UIPopupList DestinationPreferList;
	public UIPopupList TrainingModeList;

	public UIButton StartButton;

	string displayType = null;
	string startPoint = null;
	string transmitType = null;
	string destinationPrefer = null;
	string trainingMode = null;

	// Use this for initialization
	void Start () {
		EventDelegate.Add(DisplayTypeList.onChange, SetDisplayType);
		EventDelegate.Add(StartPointList.onChange, SetStartPoint);
		EventDelegate.Add(TransmitTypeList.onChange, SetTransmitType);
		EventDelegate.Add(DestinationPreferList.onChange, SetDestinationPrefer);
		EventDelegate.Add(TrainingModeList.onChange, SetTrainingMode);
		EventDelegate.Add(StartButton.onClick, OnStart);
	}
	
	void SetDisplayType(){
		displayType = DisplayTypeList.value;
	}

	void SetStartPoint(){
		startPoint = StartPointList.value;
	}

	void SetTransmitType(){
		transmitType = TransmitTypeList.value;
	}

	void SetDestinationPrefer(){
		destinationPrefer = DestinationPreferList.value;
	}

	void SetTrainingMode(){
		trainingMode = TrainingModeList.value;
	}

	void OnStart(){
		PlayerPrefs.SetString("DisplayType", displayType);
		PlayerPrefs.SetString("StartPoint", startPoint);
		PlayerPrefs.SetString("TransmitType", transmitType);
		PlayerPrefs.SetString("DestinationPrefer", destinationPrefer);
		PlayerPrefs.SetString("TrainingMode", trainingMode);

		Application.LoadLevel("MainScene");
	}
	
		

}
