﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Button : UI_Base
{
    enum Buttons
    {
        PointButton
    }

    enum Texts
    {
        PointText,
        ScoreText
    }

    enum GameObjects
    {
        TestObject
    }

    void Start()
    {
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<GameObject>(typeof(GameObjects));

        Get<Text>((int)Texts.ScoreText).text = "BindText";

        Debug.Log(Get<GameObject>((int)GameObjects.TestObject).name);
    }

    void Update()
    {

    }
}
