﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Path{
	
	Dictionary<string, Landmark[]> PathList = new Dictionary<string, Landmark[]>();
	Dictionary<string, string> EntranceDic = new Dictionary<string, string>();
	
	public Path(){
		PathList.Add("LeftWaitingLineToEntrance575_2ByStair", new Landmark[6]{
			FixedLandmark.LeftWaitingLine, 
			FixedLandmark.EnterInBound, 
			FixedLandmark.EndFareGate, 
			FixedLandmark.LeftFareMachine, 
			FixedLandmark.LeftMetalGate, 
			FixedLandmark.Entrance575_2});
		PathList.Add("Entrance544ToRightWaitingLineByStair", new Landmark[7]{
			FixedLandmark.Entrance544, 
			FixedLandmark.Hallway, 
			FixedLandmark.RightMetalGate, 
			FixedLandmark.RightFareMachine, 
			FixedLandmark.EndFareGate, 
			FixedLandmark.EnterOutBound, 
			FixedLandmark.RightWaitingLine});
		PathList.Add("Entrance544ToRightWaitingLineByElevator", new Landmark[8]{
			FixedLandmark.Entrance544, 
			FixedLandmark.Hallway, 
			FixedLandmark.RightMetalGate, 
			FixedLandmark.RightFareMachine, 
			FixedLandmark.EndFareGate,
			FixedLandmark.RightElevator,
			FixedLandmark.EnterOutBound, 
			FixedLandmark.RightWaitingLine});
		PathList.Add("Entrance544ToLeftWaitingLineByStair", new Landmark[7]{
			FixedLandmark.Entrance544, 
			FixedLandmark.Hallway, 
			FixedLandmark.RightMetalGate, 
			FixedLandmark.RightFareMachine, 
			FixedLandmark.EndFareGate, 
			FixedLandmark.EnterInBound, 
			FixedLandmark.LeftWaitingLine});
		PathList.Add("Entrance544ToLeftWaitingLineByElevator", new Landmark[8]{
			FixedLandmark.Entrance544, 
			FixedLandmark.Hallway, 
			FixedLandmark.RightMetalGate, 
			FixedLandmark.RightFareMachine, 
			FixedLandmark.EndFareGate,
			FixedLandmark.LeftElevator,
			FixedLandmark.EnterInBound, 
			FixedLandmark.LeftWaitingLine});
		PathList.Add("Entrance562ToRightWaitingLineByStair", new Landmark[6]{
			FixedLandmark.Entrance562,  
			FixedLandmark.RightMetalGate, 
			FixedLandmark.RightFareMachine, 
			FixedLandmark.EndFareGate, 
			FixedLandmark.EnterOutBound, 
			FixedLandmark.RightWaitingLine});
		PathList.Add("Entrance562ToRightWaitingLineByElevator", new Landmark[7]{
			FixedLandmark.Entrance562, 
			FixedLandmark.RightMetalGate, 
			FixedLandmark.RightFareMachine, 
			FixedLandmark.EndFareGate,
			FixedLandmark.RightElevator,
			FixedLandmark.EnterOutBound, 
			FixedLandmark.RightWaitingLine});
		PathList.Add("Entrance562ToLeftWaitingLineByStair", new Landmark[6]{
			FixedLandmark.Entrance562, 
			FixedLandmark.RightMetalGate, 
			FixedLandmark.RightFareMachine, 
			FixedLandmark.EndFareGate, 
			FixedLandmark.EnterInBound, 
			FixedLandmark.LeftWaitingLine});
		PathList.Add("Entrance562ToLeftWaitingLineByElevator", new Landmark[7]{
			FixedLandmark.Entrance562, 
			FixedLandmark.RightMetalGate, 
			FixedLandmark.RightFareMachine, 
			FixedLandmark.EndFareGate,
			FixedLandmark.LeftElevator,
			FixedLandmark.EnterInBound, 
			FixedLandmark.LeftWaitingLine});
		PathList.Add("Entrance575_1ToRightWaitingLineByStair", new Landmark[6]{
			FixedLandmark.Entrance575_1,  
			FixedLandmark.LeftMetalGate, 
			FixedLandmark.LeftFareMachine, 
			FixedLandmark.EndFareGate, 
			FixedLandmark.EnterOutBound, 
			FixedLandmark.RightWaitingLine});
		PathList.Add("Entrance575_1ToRightWaitingLineByElevator", new Landmark[7]{
			FixedLandmark.Entrance575_1, 
			FixedLandmark.LeftMetalGate, 
			FixedLandmark.LeftFareMachine, 
			FixedLandmark.EndFareGate,
			FixedLandmark.RightElevator,
			FixedLandmark.EnterOutBound, 
			FixedLandmark.RightWaitingLine});
		PathList.Add("Entrance575_1ToLeftWaitingLineByStair", new Landmark[6]{
			FixedLandmark.Entrance575_1, 
			FixedLandmark.LeftMetalGate, 
			FixedLandmark.LeftFareMachine, 
			FixedLandmark.EndFareGate, 
			FixedLandmark.EnterInBound, 
			FixedLandmark.LeftWaitingLine});
		PathList.Add("Entrance575_1ToLeftWaitingLineByElevator", new Landmark[7]{
			FixedLandmark.Entrance575_1, 
			FixedLandmark.LeftMetalGate, 
			FixedLandmark.LeftFareMachine, 
			FixedLandmark.EndFareGate,
			FixedLandmark.LeftElevator,
			FixedLandmark.EnterInBound, 
			FixedLandmark.LeftWaitingLine});
		PathList.Add("Entrance575_2ToRightWaitingLineByStair", new Landmark[6]{
			FixedLandmark.Entrance575_2,  
			FixedLandmark.LeftMetalGate, 
			FixedLandmark.LeftFareMachine, 
			FixedLandmark.EndFareGate, 
			FixedLandmark.EnterOutBound, 
			FixedLandmark.RightWaitingLine});
		PathList.Add("Entrance575_2ToRightWaitingLineByElevator", new Landmark[7]{
			FixedLandmark.Entrance575_2, 
			FixedLandmark.LeftMetalGate, 
			FixedLandmark.LeftFareMachine, 
			FixedLandmark.EndFareGate,
			FixedLandmark.RightElevator,
			FixedLandmark.EnterOutBound, 
			FixedLandmark.RightWaitingLine});
		PathList.Add("Entrance575_2ToLeftWaitingLineByStair", new Landmark[6]{
			FixedLandmark.Entrance575_2, 
			FixedLandmark.LeftMetalGate, 
			FixedLandmark.LeftFareMachine, 
			FixedLandmark.EndFareGate, 
			FixedLandmark.EnterInBound, 
			FixedLandmark.LeftWaitingLine});
		PathList.Add("Entrance575_2ToLeftWaitingLineByElevator", new Landmark[7]{
			FixedLandmark.Entrance575_2, 
			FixedLandmark.LeftMetalGate, 
			FixedLandmark.LeftFareMachine, 
			FixedLandmark.EndFareGate,
			FixedLandmark.LeftElevator,
			FixedLandmark.EnterInBound, 
			FixedLandmark.LeftWaitingLine});
		PathList.Add("Entrance582_1ToRightWaitingLineByStair", new Landmark[6]{
			FixedLandmark.Entrance582_1, 
			FixedLandmark.Entrance582_Lobby,  
			FixedLandmark.LeftFareMachine, 
			FixedLandmark.EndFareGate, 
			FixedLandmark.EnterOutBound, 
			FixedLandmark.RightWaitingLine});
		PathList.Add("Entrance582_1ToRightWaitingLineByElevator", new Landmark[7]{
			FixedLandmark.Entrance582_1, 
			FixedLandmark.Entrance582_Lobby,  
			FixedLandmark.LeftFareMachine, 
			FixedLandmark.EndFareGate,
			FixedLandmark.RightElevator,
			FixedLandmark.EnterOutBound, 
			FixedLandmark.RightWaitingLine});
		PathList.Add("Entrance582_1ToLeftWaitingLineByStair", new Landmark[6]{
			FixedLandmark.Entrance582_1, 
			FixedLandmark.Entrance582_Lobby, 
			FixedLandmark.LeftFareMachine,
			FixedLandmark.EndFareGate, 
			FixedLandmark.EnterInBound, 
			FixedLandmark.LeftWaitingLine});
		PathList.Add("Entrance582_1ToLeftWaitingLineByElevator", new Landmark[7]{
			FixedLandmark.Entrance582_1, 
			FixedLandmark.Entrance582_Lobby,  
			FixedLandmark.LeftFareMachine, 
			FixedLandmark.EndFareGate,
			FixedLandmark.LeftElevator,
			FixedLandmark.EnterInBound, 
			FixedLandmark.LeftWaitingLine});
		PathList.Add("Entrance582_2ToRightWaitingLineByStair", new Landmark[6]{
			FixedLandmark.Entrance582_2, 
			FixedLandmark.Entrance582_Lobby,  
			FixedLandmark.LeftFareMachine, 
			FixedLandmark.EndFareGate, 
			FixedLandmark.EnterOutBound, 
			FixedLandmark.RightWaitingLine});
		PathList.Add("Entrance582_2ToRightWaitingLineByElevator", new Landmark[7]{
			FixedLandmark.Entrance582_2, 
			FixedLandmark.Entrance582_Lobby,  
			FixedLandmark.LeftFareMachine, 
			FixedLandmark.EndFareGate,
			FixedLandmark.RightElevator,
			FixedLandmark.EnterOutBound, 
			FixedLandmark.RightWaitingLine});
		PathList.Add("Entrance582_2ToLeftWaitingLineByStair", new Landmark[6]{
			FixedLandmark.Entrance582_2, 
			FixedLandmark.Entrance582_Lobby, 
			FixedLandmark.LeftFareMachine,
			FixedLandmark.EndFareGate, 
			FixedLandmark.EnterInBound, 
			FixedLandmark.LeftWaitingLine});
		PathList.Add("Entrance582_2ToLeftWaitingLineByElevator", new Landmark[7]{
			FixedLandmark.Entrance582_2, 
			FixedLandmark.Entrance582_Lobby,  
			FixedLandmark.LeftFareMachine, 
			FixedLandmark.EndFareGate,
			FixedLandmark.LeftElevator,
			FixedLandmark.EnterInBound, 
			FixedLandmark.LeftWaitingLine});
		
//		EntranceDic.Add("Entrance 9", "Entrance544");
//		EntranceDic.Add("Entrance 4", "Entrance562");
//		EntranceDic.Add("Entrance 5", "Entrance575_2");
//		EntranceDic.Add("Entrance 6", "Entrance575_1");
//		EntranceDic.Add("Entrance 7", "Entrance582_2");
//		EntranceDic.Add("Entrance 8", "Entrance582_1");
	}
	
	public Landmark[] getPathbyName(string name){
		Landmark[] path;
		PathList.TryGetValue(name, out path);
		return path;
	}
	public string GetEntranceString(string entrance){
		string es = null;
//		EntranceDic.TryGetValue(entrance, out es);
		es = entrance;
		Debug.Log(es);
		return es;
	}
}