namespace KBEngine
{ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
	using KBEngine;
	using System;

public class Player : KBEngine.GameObject {
		public override void __init__()
		{
			//player初始化完成之后，就向unity脚本层输出onLoginSuccessfully
			Event.fireOut("onLoginSuccessfully", new object[] { KBEngineApp.app.entity_uuid, id, this });
		}
		// Use this for initialization
		void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		/// <summary>
		///服务端返回方法
		/// </summary>
	public void on_req_match(string msg)
		{
			if (msg!=null)
			{
				//ui event

				Event.fireOut("on_req_match", new object[] { msg });
			}
		}
}
}