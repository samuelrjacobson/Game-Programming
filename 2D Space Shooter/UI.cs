using UnityEngine;
using UnityEngine.UIElements;

// Did not use this script
public class UI : MonoBehaviour
{
    private void OnEnable(){
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Label textBox = root.Q<Label>("uiText");
        textBox.text = "c";
    }
}
