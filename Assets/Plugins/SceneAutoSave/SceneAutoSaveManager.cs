using UnityEngine;
using UnityEditor;
using System;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

/// <summary>
/// Manages the automatic saving of the currently edited scene.
/// </summary>
[InitializeOnLoad]
public class SceneAutoSaveManager
{
    private static bool autoSaveScene = true;
    private static bool showMessage = true;
    private static int autoSaveInterval;
    private static DateTime lastSaveTime = DateTime.Now;

    static SceneAutoSaveManager()
    {
        LoadPrefs();
        EditorApplication.playModeStateChanged += OnChangePlayModeState;
        EditorApplication.update += Update;
    }

    private static void Update()
    {
        if (autoSaveScene)
        {
            if (DateTime.Now >= (lastSaveTime.AddMinutes(autoSaveInterval)))
            {
                SaveScene();
            }
        }
    }

    private static void LoadPrefs()
    {
        autoSaveScene = EditorPrefs.GetBool(SceneAutoSavePreference.AUTO_SAVE_SCENE, true);
        showMessage = EditorPrefs.GetBool(SceneAutoSavePreference.SHOW_MESSAGE, true);
        autoSaveInterval = EditorPrefs.GetInt(SceneAutoSavePreference.AUTO_SAVE_INTERVAL, 2);

        string dateAsString = EditorPrefs.GetString(SceneAutoSavePreference.LAST_SAVE_TIME, DateTime.Now.ToString());
        DateTime.TryParse(dateAsString, out lastSaveTime);
    }

    private static void OnChangePlayModeState(PlayModeStateChange state)
    {
        Scene activeScene = SceneManager.GetActiveScene();

        if (!EditorApplication.isPlayingOrWillChangePlaymode || EditorApplication.isPlaying)
        {
            return;
        }

        Debug.Log("Autosaving scene before entering Play Mode: " + activeScene.name);
        SaveScene();
    }

    private static void SaveScene()
    {
        Scene activeScene = SceneManager.GetActiveScene();

        if (!activeScene.isDirty)
        {
            return;
        }

        EditorSceneManager.SaveScene(activeScene);
        AssetDatabase.SaveAssets();
        lastSaveTime = DateTime.Now;

        if (showMessage)
        {
            Debug.Log("Saved: " + activeScene.name + " on " + lastSaveTime);
        }
    }
}
