using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    public static Room instance;
    private UnityEngine.GameObject terrian = null;

    private UnityEngine.GameObject terrianPrefab;

    private UnityEngine.GameObject player = null;

    //在unity编辑器内设置这几个怪物的模型，只要在玩家的AOI范围内传过来，就显示
    public UnityEngine.GameObject priceTowerPrefab;

    public UnityEngine.GameObject rabbitPrefab;

    public UnityEngine.GameObject ghostPrefab;

    public UnityEngine.GameObject batPrefab;
    public UnityEngine.GameObject simePrefab;

    static Room()
    {
        UnityEngine.GameObject go = new UnityEngine.GameObject("Room");
        DontDestroyOnLoad(go);
        instance = go.AddComponent<Room>();
        instance.terrianPrefab = (UnityEngine.GameObject)Resources.Load("Terrian");
        instance.priceTowerPrefab = (UnityEngine.GameObject)Resources.Load("Price");
    }
    public void init()
    {

    }

    // Use this for initialization
    void Start()
    {

        KBEngine.Event.registerOut("addSpaceGeometryMapping", this, "addSpaceGeometryMapping");

        KBEngine.Event.registerOut("onEnterWorld", this, "onEnterWorld");
        KBEngine.Event.registerOut("onLeaveWorld", this, "onLeaveWorld");
    }

    public void onEnterWorld(KBEngine.Entity entity)
    {
        if (entity.isPlayer())
        {
            return;
        }
        //思路就是通过怪物的modelID来加载怪物的模型
        //通过onenterworld实现加载丰富多彩的游戏世界，


    }
    public void onLeaveWorld(KBEngine.Entity entity)
    {

    }
    public void addSpaceGeometryMapping(string respath)
    {
        Debug.Log("loading scen (" + respath + ")...");
        print("scene(" + respath + "), spaceID=" + KBEngine.KBEngineApp.app.spaceID);

        if (terrian == null)
            terrian = Instantiate(terrianPrefab) as UnityEngine.GameObject;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
