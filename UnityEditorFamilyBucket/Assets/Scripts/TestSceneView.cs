using UnityEditor;
using UnityEngine;

public class TestSceneView : MonoBehaviour
{
    // Start is called before the first frame update
    [TextArea(3,10)]
    private string str = "";
    void Start()
    {

       var tool = Tools.current;
        //var view = SceneView.currentDrawingSceneView;
        //if (view != null)
        //{
        //    view.pivot = YOUR_GAME_OBJECT.transform.position;
        //}
    }


    public void Test_0()
    {
        var view = UnityEditor.SceneView.lastActiveSceneView;
        if (view != null)
        {
            Vector3 rotationVector3 = new Vector3(0f, 30f, 0f);

            Quaternion rotation = Quaternion.Euler(rotationVector3);
            var target = new GameObject();
            target.transform.position = new Vector3(-2.567259f, 1.450094f, -1.167638f);
            target.transform.localEulerAngles = new Vector3(38.675f, -34.721f, 0);
            view.AlignViewToObject(target.transform);
            Debug.Log($"view:{ view.camera.transform.position}");
            //GameObject.DestroyImmediate(target);
        }
    }

    public GameObject modificationPrefab;

    public void Test_1()
    {
        //
        PropertyModification[] info = PrefabUtility.GetPropertyModifications(modificationPrefab);
        for (int i = 0; i < info.Length; i++)
        {
            if (PrefabUtility.IsDefaultOverride(info[i])==false)
            {
                Debug.Log(info[i].value);
            }
            Debug.Log("********:"+info[i].value);
            Debug.Log(PrefabUtility.IsDefaultOverride(info[i]));
        }
        Debug.Log(info.Length);
    }
}
