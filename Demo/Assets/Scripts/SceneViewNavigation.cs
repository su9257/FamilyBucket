using UnityEngine;
using UnityEditor;

public class SceneViewNavigation : MonoBehaviour
{
    [MenuItem("Navigation/Top View")]
    static void TopView()
    {
        var camera = GameObject.Find("Main Camera").GetComponent<Camera>();
       
        SceneView.lastActiveSceneView.rotation = Quaternion.Euler(camera.transform.eulerAngles.x, camera.transform.eulerAngles.y, camera.transform.eulerAngles.z);
        SceneView.lastActiveSceneView.pivot = new Vector3(camera.transform.position.x, camera.transform.position.y, camera.transform.position.z);
        SceneView.lastActiveSceneView.size = camera.orthographicSize; // unit
        SceneView.lastActiveSceneView.orthographic = true; // or false
        Debug.Log(SceneView.lastActiveSceneView.camera.orthographicSize);
    }
}