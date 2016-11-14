using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;
using UnityEngine;
using KBEngine;
	public class ui_menu:MonoBehaviour
	{
	public Button but_match;
	public Text text_status;
	void Start()
	{
		
		//DontDestroyOnLoad(gameObject.transform);
		//KBEngine.Event.registerOut("onReqAvatarList", this, "onReqAvatarList");
		KBEngine.Event.registerOut("on_match", this, "on_match");
		
		Player account = (Player)KBEngineApp.app.player();
		

	}
	public void on_match()
	{
		print("");
		
	}
	public void on_match_status(bool beSuccess)
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
	void OnDestroy()
	{
		KBEngine.Event.deregisterOut(this);
	}
}

