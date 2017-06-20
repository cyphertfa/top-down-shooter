using UnityEngine;
using UnityEditor;
using System.IO;
using System.Linq;
using System.Text;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class GenerateRooms : ScriptableObject
{
    private static string PATH = "Assets/Rooms";
    private static string SCENE_RGX = "*.unity";
    private static string PREFAB_RGX = "*.prefab";
    private static string GEN_FOLDER = "Assets/Rooms/Generated";

    [MenuItem("Tools/GenerateRooms")]
    static void DoIt()
    {
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        Scene initialScene = SceneManager.GetActiveScene();

        InitializeAssetFolder();

        DirectoryInfo dir = new DirectoryInfo(PATH);
        FileInfo[] info = dir.GetFiles(SCENE_RGX);
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(string.Format("Buidling in \"{0}\".", GEN_FOLDER));

        foreach (FileInfo f in info)
        {
            sb.AppendLine(f.Name);
            Scene scene = EditorSceneManager.OpenScene(f.FullName);
            foreach(GameObject go in scene.GetRootGameObjects())
            {
                Room room = go.GetComponent<Room>();
                if (room != null)
                {
                    //Bake the navmesh for this scene
                    BakeNavMeshes baker = go.GetComponent<BakeNavMeshes>();
                    if (baker != null)
                    {
                        baker.BakeNavMesh();
                    }
                    else
                    {
                        sb.AppendLine(string.Format("Warning: expected BakeNavMesh behaviour on {0} in scene {1}", go, f.Name));
                    }

                    //Generate a prefab from the scene
                    PrefabUtility.CreatePrefab(GEN_FOLDER + "/" + Path.GetFileNameWithoutExtension(f.Name)+ ".prefab", go);

                    //One Room object per scene!
                    break;
                }
            }
            EditorSceneManager.SaveScene(scene);
        }
        sb.Append("Done!");
        EditorUtility.DisplayDialog("Scenes", sb.ToString(), "Ok");
    }


    static void InitializeAssetFolder()
    {

        if(AssetDatabase.IsValidFolder(GEN_FOLDER) == false)
        {
            AssetDatabase.CreateFolder(PATH, "Generated");
        }
        else
        {
            DirectoryInfo dir = new DirectoryInfo(GEN_FOLDER);
            FileInfo[] info = dir.GetFiles(PREFAB_RGX);
            foreach (FileInfo f in info)
            {
                AssetDatabase.DeleteAsset(GEN_FOLDER +"/"+ f.Name);
            }
        }
        
    }
}