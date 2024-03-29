﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KBEngine;
using System;
using UnityEngine.SceneManagement;

public class ui_login : MonoBehaviour {

	public InputField if_userName;
	public InputField if_passWord;
	public Text text_status;
	// Use this for initialization
	void Start () {
		KBEngine.Event.registerOut("onConnectStatus", this, "onConnectStatus");
		KBEngine.Event.registerOut("onLoginFailed", this, "onLoginFailed");
		KBEngine.Event.registerOut("onLoginSuccessfully", this, "onLoginSuccessfully");
		KBEngine.Event.registerOut("onCreateAccountResult", this, "onCreateAccountResult");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnDestroy()
	{
		KBEngine.Event.deregisterOut(this);
	}
	public void onConnectStatus(bool beSuccess)
	{
		if (beSuccess)
		{
			print("连接成功，正在登陆");
			text_status.text = "连接成功，正在登陆";
		}
		else
		{
			text_status.text = "连接错误";
		}
	}
	public void onLoginFailed(UInt16 errorCode)
	{
		text_status.text = "登陆失败" + KBEngineApp.app.serverErr(errorCode);
	}
	public void onLoginSuccessfully(UInt64 uuuid, Int32 id, Player player)
	{
		if (player != null)
		{
			text_status.text = "登录成功";
			//跳转场景
			//Application.LoadLevel("selectAvatar");
			SceneManager.LoadScene("scene_menu");
		}
	}
	public void onLogin()
	{
		print("connect to server...(连接到服务端...)");
		text_status.text = "连接到服务端...";
		KBEngine.Event.fireIn("login", if_userName.text, if_passWord.text, System.Text.Encoding.UTF8.GetBytes("castle_game"));
	}
	public void onRegister()
	{
		text_status.text = "连接到服务端...";
		KBEngine.Event.fireIn("createAccount", if_userName.text, if_passWord.text, System.Text.Encoding.UTF8.GetBytes("castle_game"));
	}
	public void onCreateAccountResult(UInt16 retcode, byte[] datas)
	{
		if (retcode != 0)
		{
			print("(注册账号错误)! err=" + KBEngineApp.app.serverErr(retcode));
			text_status.text = "(注册账号错误)! err=" + KBEngineApp.app.serverErr(retcode);
			return;
		}
		text_status.text = "注册账号成功! 请点击登录进入游戏";
	}
	
	public void onClose()
	{
		Application.Quit();
	}
}
