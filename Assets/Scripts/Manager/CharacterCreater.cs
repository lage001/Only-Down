using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCreater : SingletonBase<CharacterCreater>
{

    public GameObject Dude_prefab;
    public GameObject Frog_prefab;
    public GameObject Man_prefab;
    public GameObject Guy_prefab;

    public Dictionary<int, GameObject> dic = new Dictionary<int, GameObject>();
    protected override void Awake()
    {
        base.Awake();
        dic.Add(0, Dude_prefab);
        dic.Add(1, Frog_prefab);
        dic.Add(2, Man_prefab);
        dic.Add(3, Guy_prefab);
    }



}
