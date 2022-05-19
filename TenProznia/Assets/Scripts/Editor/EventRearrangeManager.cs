#if UNITY_EDITOR

using UnityEditor;
using UnityEngine.Events;
using UnityEditorInternal;

[CustomPropertyDrawer(typeof(UnityEventBase), true)]
public class BaseCustomUnityEventDrawer : UnityEventDrawer {
    protected override void SetupReorderableList(ReorderableList list) {
        base.SetupReorderableList(list);

        list.draggable = true;
    }
}

#endif