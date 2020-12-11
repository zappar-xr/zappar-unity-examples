using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class BuildScript : EditorWindow {

  [MenuItem ("Window/Zappar - Test Exporter")]
  private static void ShowWindow () {
    BuildScript window = GetWindow<BuildScript> ();
    window.titleContent = new GUIContent ("Zappar Test Exporter");
    window.Show ();
  }
  private void OnGUI () {
    if (GUILayout.Button ("Build Android")) Android ();
    if (GUILayout.Button ("Build iOS")) iOS ();
    if (GUILayout.Button ("Build WebGL")) WebGL ();
    if (GUILayout.Button ("Build StandaloneOSX")) StandaloneOSX ();
    if (GUILayout.Button ("Build StandaloneWindows")) StandaloneWindows ();
    if (GUILayout.Button ("Add scenes to build")) AddScenesToBuild ();
  }

  static void Android () {
    BuildPipeline.BuildPlayer (GetScenes (), "./android-dist.apk", BuildTarget.Android, BuildOptions.None);
  }
  static void iOS () {
    BuildPipeline.BuildPlayer (GetScenes (), "./ios-dist", BuildTarget.iOS, BuildOptions.None);
  }
  static void WebGL () {
    BuildPipeline.BuildPlayer (GetScenes (), "./webgl-dist", BuildTarget.WebGL, BuildOptions.None);
  }
  static void StandaloneWindows () {
    BuildPipeline.BuildPlayer (GetScenes (), "./windows-dist/build.exe", BuildTarget.StandaloneWindows, BuildOptions.None);
  }

  static void StandaloneOSX () {
    BuildPipeline.BuildPlayer (GetScenes (), "./osx-dist.app", BuildTarget.StandaloneOSX, BuildOptions.None);
  }

  static string[] GetScenes () {
    return EditorBuildSettings.scenes.Where (s => s.enabled).Select (s => s.path).ToArray ();
  }

  static void AddScenesToBuild () {
    List<EditorBuildSettingsScene> editorBuildSettingsScenes = new List<EditorBuildSettingsScene> ();
    List<string> SceneList = new List<string> ();
    string MainFolder = "Assets/Scenes";

    DirectoryInfo d = new DirectoryInfo (@MainFolder);
    FileInfo[] Files = d.GetFiles ("*.unity"); //Getting unity files
    // Reverse so Menu is #1
    foreach (FileInfo file in Files.Reverse ()) {
      Debug.Log ("file name:" + file.Name);
      SceneList.Add (file.Name);
    }

    int i = 0;

    for (i = 0; i < SceneList.Count; i++) {
      string scenePath = MainFolder + "/" + SceneList[i];
      Debug.Log ("i = " + i);
      Debug.Log ("scene path:" + scenePath);
      editorBuildSettingsScenes.Add (new EditorBuildSettingsScene (scenePath, true));

    }

    EditorBuildSettings.scenes = editorBuildSettingsScenes.ToArray ();
  }

}