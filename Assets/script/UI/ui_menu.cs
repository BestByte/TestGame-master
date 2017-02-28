using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;
using UnityEngine;
using KBEngine;
using UnityEngine.SceneManagement;
	public class ui_menu:MonoBehaviour
	{
	public Button but_match;
	public Text text_status;
	void Start()
	{
		
		//DontDestroyOnLoad(gameObject.transform);
		//KBEngine.Event.registerOut("onReqAvatarList", this, "onReqAvatarList");
		KBEngine.Event.registerOut("on_req_match", this, "on_req_match");
		KBEngine.Event.registerOut("on_match_success", this, "on_match_success");

		
		

	}
	public void on_match_success(string msg)
	{
		if (msg != null)
		{
			print("匹配成功.");
			text_status.text = "匹配成功...";
			SceneManager.LoadScene("scene_room");
		}
		else
		{
			text_status.text = "连接错误";
		}
	}
	public void req_match()
	{
		Player player = (Player)KBEngineApp.app.player();

		if (player != null)
		{
			player.req_match();
			print("player.req_match();");
		}
	} 
	public void on_req_match(string msg)
	{
		if (msg !=null)
		{
			print("正在匹配...");
			text_status.text = "正在匹配...";
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

