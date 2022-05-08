using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inven_Item : UI_Base
{
    enum GameObjects
    {
        Image_ItemIcon,
        Text_ItemName
    }

    string _name;

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        Bind<GameObject>(typeof(GameObjects));

        GetGameObject((int)GameObjects.Text_ItemName).GetComponent<Text>().text = _name;
        Util.Log($"Init::{gameObject.name}");

        GetGameObject((int)GameObjects.Image_ItemIcon).BindEvent((PointerEventData) => { Util.Log($"Clicked Item! {_name}"); });
    }

    public void SetInfo(string name)
    {
        _name = name;
        Util.Log(name);
    }
}
