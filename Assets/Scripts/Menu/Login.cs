using UnityEngine;
using System.Collections;
using UnityEditor;

public class Login : MonoBehaviour {

	public UIInput usernameInput;
	public UIInput passwordInput;
	public UIButton loginButton;

	bool loginSuccess = false;
	bool loginFail = false;
	// Use this for initialization
	void Start () {
		EventDelegate.Set(loginButton.onClick, DoLogin);
	}

	void DoLogin ()
	{
		Debug.Log("Logging in as " + usernameInput.value + ", pass " + passwordInput.value);
		SignalRUnityController._instance._loginSubscription.Data += OnLogin;
		SignalRUnityController._instance.Login(usernameInput.value, passwordInput.value);
	}

	void OnLogin(object[] data)
	{
		string response = data[0].ToString();
		Debug.Log(response);
		if (response == "Success")
		{
			loginSuccess = true;
		} 
		else if (response == "Fail")
		{
			loginFail = true;
		}
	}

	// Update is called once per frame
	void Update () {
		if (loginSuccess)
		{
			Application.LoadLevel("StartScene");
		}
		if (loginFail)
		{
			if (EditorUtility.DisplayDialog("Login Failed", "No match for username and password?", "Try Again"))
			{
				loginFail = false;
			}
		}
	}
}
