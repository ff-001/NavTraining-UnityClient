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
		RecordUserPC();
		Application.LoadLevel(1);
	}
	// Debug
	void RecordUserPC() {
		print("Client IP Address:" + "24.20.152.141");
		print("Date: " + DateTime.Now.Month + "/" + "3" + "/" + DateTime.Now.Year + " - Time: " + DateTime.Now.Hour + ":" + DateTime.Now.Minute);
		print("Last point: " + "x = 12.26382; y = 4.326715; z = 86.3265118");
		print("Last Task: Entrance544ToRightWaitingLineByStair");
	}

	string GetClientIPAddr() {
		string userIp = "";
		NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
		foreach (NetworkInterface adapter in adapters){
			UnicastIPAddressInformationCollection uniCast = adapter.GetIPProperties().UnicastAddresses;
			if (uniCast.Count > 0){
				foreach (UnicastIPAddressInformation uni in uniCast) {
					if (uni.Address.AddressFamily == AddressFamily.InterNetwork) {
						userIp = uni.Address.ToString();
					}
				}
			}
		}
		return userIp;
	}
		

}
