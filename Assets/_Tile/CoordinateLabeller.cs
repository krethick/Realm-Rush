using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

[ExecuteAlways] 
public class CoordinateLabeller : MonoBehaviour
{
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int(); // Initialise the coordinates
    void Awake() // It is called even before start
    {
        label = GetComponent<TextMeshPro>(); // Getting the Text mesh pro component from the child object (Text)
        DisplayCoordinates(); // This will show in the output as well/in game scene
    }
    void Update()
    {
        if(!Application.isPlaying)
        {
          DisplayCoordinates();
          UpdateObjectName();
        }
    }

    void DisplayCoordinates()
    {
        // include the x position
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x); 

        // We are including z because we are working on the 2D x,z plane 
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z); 
        label.text = coordinates.x + "," + coordinates.y;
    }

    void UpdateObjectName()
    {
        // Change the Parent Object names
        transform.parent.name = coordinates.ToString();
    }
}
