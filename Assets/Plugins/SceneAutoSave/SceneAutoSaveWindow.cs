using UnityEngine;
using UnityEditor;
using System;
using UnityEngine.SceneManagement;

/// <summary>
/// Window in the editor which configures the parameters of the scene autosave manager. 
/// </summary>
public class SceneAutoSaveWindow : EditorWindow
{
    private bool autoSaveScene = true;
    private bool showMessage = true;
    private int autoSaveInterval;
    private DateTime lastSaveTime = DateTime.Now;

    private string projectPath;

    void OnEnable()
    {
        projectPath = Application.dataPath;

        autoSaveScene = EditorPrefs.GetBool(SceneAutoSavePreference.AUTO_SAVE_SCENE, true);
        showMessage = EditorPrefs.GetBool(SceneAutoSavePreference.SHOW_MESSAGE, true);
        autoSaveInterval = EditorPrefs.GetInt(SceneAutoSavePreference.AUTO_SAVE_INTERVAL, 2);

        string dateAsString = EditorPrefs.GetString(SceneAutoSavePreference.LAST_SAVE_TIME, DateTime.Now.ToString());
        DateTime.TryParse(dateAsString, out lastSaveTime);
    }

    [MenuItem("Window/Scene Autosave")]
    static void Init()
    {
        SceneAutoSaveWindow saveWindow = (SceneAutoSaveWindow)GetWindow(typeof(SceneAutoSaveWindow));
        saveWindow.Show();
    }

    void OnGUI()
    {
        GUILayout.Label("Info: ", EditorStyles.boldLabel);
        EditorGUILayout.LabelField("Saving to: ", projectPath);
        EditorGUILayout.LabelField("Saving scene: ", SceneManager.GetActiveScene().name);
        GUILayout.Label("Options: ", EditorStyles.boldLabel);
        autoSaveScene = EditorGUILayout.BeginToggleGroup("Autosave", autoSaveScene);
        autoSaveInterval = EditorGUILayout.IntSlider("Interval (minutes)", autoSaveInterval, 1, 10);

        EditorGUILayout.EndToggleGroup();
        showMessage = EditorGUILayout.BeginToggleGroup("Show Message", showMessage);
        EditorGUILayout.EndToggleGroup();

        SavePrefs();
    }

    private void SavePrefs()
    {
        EditorPrefs.SetBool(SceneAutoSavePreference.AUTO_SAVE_SCENE, autoSaveScene);
        EditorPrefs.SetBool(SceneAutoSavePreference.SHOW_MESSAGE, showMessage);
        EditorPrefs.SetInt(SceneAutoSavePreference.AUTO_SAVE_INTERVAL, autoSaveInterval);
        EditorPrefs.SetString(SceneAutoSavePreference.LAST_SAVE_TIME, lastSaveTime.ToString());
    }
}