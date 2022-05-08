using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    int _order = 10;

    Stack<UI_Popup> _popupStack = new Stack<UI_Popup>();
    UI_Scene _sceneUI = null;

    public GameObject Root
    {
        get
        {
            GameObject root = GameObject.Find("@UI_Root");
            if (root == null)
                root = new GameObject("@UI_Root");

            return root;
        }
    }

    public void SetCanvas(GameObject go, bool sort = true)
    {
        Canvas canvas = Util.GetOrAddComponent<Canvas>(go);
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.overrideSorting = true;

        if (sort)
        {
            canvas.sortingOrder = _order;
            _order++;
        }
        else
        {
            canvas.sortingOrder = 0;
        }
    }

    public T MakeSubItem<T>(string name = null, Transform parent = null) where T : UI_Base
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        if (parent == null)
            parent = Root.transform;

        GameObject go = Managers.Resource.Instantiate($"UI/SubItem/{name}", parent);

#if UNITY_EDITOR
        Util.Log($"MakeSubItem::{go.name}");
#endif

        return Util.GetOrAddComponent<T>(go);
    }

    public T ShowPopupUI<T>(string name = null) where T : UI_Popup
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Managers.Resource.Instantiate($"UI/Popup/{name}", Root.transform);
        T popup = Util.GetOrAddComponent<T>(go);
        _popupStack.Push(popup);


#if UNITY_EDITOR
        Debug.Log($"ShowPopupUI::{popup.name}");
#endif

        return popup;
    }

    public T ShowSceneUI<T>(string name = null) where T : UI_Scene
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Managers.Resource.Instantiate($"UI/Scene/{name}", Root.transform);
        T sceneUI = Util.GetOrAddComponent<T>(go);
        _sceneUI = sceneUI;

#if UNITY_EDITOR
        Util.Log($"ShowPopupUI::{sceneUI.name}");
#endif

        return sceneUI;
    }

    public void ClosePopupUI(UI_Popup popup)
    {
        if (_popupStack.Count == 0)
            return;

        if(_popupStack.Peek() != popup)
        {
            Debug.Log($"Failed ClosePopupUI::{popup.name}");
            return;
        }

        ClosePopupUI();
    }

    public void ClosePopupUI()
    {
        if (_popupStack.Count == 0)
            return;

        UI_Popup popup = _popupStack.Pop();
        Managers.Resource.Destroy(popup.gameObject);

#if UNITY_EDITOR
        Debug.Log($"ClosePopupUI::{popup.name}");
#endif

        popup = null;
        _order--;
    }

    public void CloseAllPopupUI()
    {
        while(_popupStack.Count > 0)
        {
            ClosePopupUI();
        }
    }
}
