using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Cutscene", menuName = "DataTable/Create Cutscene")]
public class DataCutscene : ScriptableObject
{
    public Sprite imageCutscene;
    [TextAreaAttribute]
    public string textCutscene;

}



