using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inven : UI_Scene
{
    enum GameObjects
    {
        GridPanel
    }

    void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        Bind<GameObject>(typeof(GameObjects));

        GameObject gridPanel = GetGameObject((int)GameObjects.GridPanel);
        foreach (Transform child in gridPanel.transform)
            Managers.Resource.Destroy(child.gameObject);

        for(int i = 0; i < 8; i++)
        {
            UI_Inven_Item invenItem = Managers.UI.MakeSubItem<UI_Inven_Item>(parent: gridPanel.transform);
            invenItem.SetInfo($"집행검{i}번");

        }
    }
}
