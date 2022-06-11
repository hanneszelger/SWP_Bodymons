using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class MuscleUI : MonoBehaviour
{
    public List<GameObject> goList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        var list = new Dictionary<string, double>()
        {
            {"Chest", PlayerBodymon.player.Muscles.Chest},
            {"Lat",PlayerBodymon.player.Muscles.Lat},
            {"Quads", PlayerBodymon.player.Muscles.Quads },
            {"Abdominals", PlayerBodymon.player.Muscles.Abdominals},
            {"Biceps", PlayerBodymon.player.Muscles.biceps}
        };

        foreach(var item in list)
        {
            GameObject goName = Resources.Load<GameObject>("Prefabs/TextTemplate");
            goName.GetComponent<Text>().text = item.Key;
            GameObject displayedName = GameObject.Instantiate(goName, gameObject.transform);

            GameObject goTemp = Resources.Load<GameObject>("Prefabs/TextTemplate");
            goTemp.GetComponent<Text>().text = item.Value.ToString();
            GameObject displayedValue = GameObject.Instantiate(goTemp, gameObject.transform);
            displayedValue.name = item.Key;

            goList.Add(displayedValue);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject go in goList)
        {
            string temp = string.Format("{0:F1}", PlayerBodymon.player.Muscles.GetType().GetProperty(go.name).GetValue(PlayerBodymon.player.Muscles, null));

            go.GetComponent<Text>().text = temp;
        }
    }
}
