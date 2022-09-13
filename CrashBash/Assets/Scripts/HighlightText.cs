using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
 
public class HighlightText : MonoBehaviour
{
    private float tiempo = 0;
    private ColorBlock colors;
    public Selectable AnySelectable;
    private PropertyInfo _selectableStateInfo = null;
 
    private void Awake()
    {
        colors = GetComponent<Button> ().colors;
         _selectableStateInfo = typeof(Selectable).GetProperty("currentSelectionState", BindingFlags.NonPublic | BindingFlags.Instance);
    }
 
    private void Update()
    {
        if ((int)_selectableStateInfo.GetValue(AnySelectable) == 3)  //Highlighted Selection State
        {
            if(tiempo < 0.4f)
            {
                colors.colorMultiplier = 3;
                GetComponent<Button> ().colors = colors;
            }
            else if(tiempo < 0.8f)
            {
                colors.colorMultiplier = 1;
                GetComponent<Button> ().colors = colors;
            }
            else
            {
                tiempo = 0f;
            }
            tiempo += Time.deltaTime;
           // Debug.Log(tiempo);
           // Debug.Log(_selectableStateInfo.GetValue(AnySelectable));
        }
        else
        {
            colors.colorMultiplier = 1;
            GetComponent<Button> ().colors = colors;
        }
        
    }

}