// NOTE: Put in `Assets/Editor` folder
using UnityEditor;
using UnityEngine;

public class BulkBuild : EditorWindow
{
    private bool
        m_BuildWin86    = false,
        m_BuildWin64    = false,
        m_BuildMacOS    = false,
        m_BuildLinux    = false,
        m_BuildAndroid  = false,
        m_BuildiOS      = false,
        m_BuildWebGL    = false;

    [MenuItem("File/Bulk Build")]
    static void Init() => GetWindow<BulkBuild>().Show();

	private void OnGUI()
	{
		GUILayout.Label("Platforms");

        // Desktop
        m_BuildWin86    = EditorGUILayout.Toggle("Windows x86", m_BuildWin86);
        m_BuildWin64    = EditorGUILayout.Toggle("Windows x64", m_BuildWin64);

        m_BuildMacOS    = EditorGUILayout.Toggle("Mac OS", m_BuildMacOS);

        m_BuildLinux    = EditorGUILayout.Toggle("Linux x64", m_BuildLinux);

        // Mobile
        m_BuildiOS      = EditorGUILayout.Toggle("iOS", m_BuildiOS);
        m_BuildAndroid  = EditorGUILayout.Toggle("Android", m_BuildAndroid);

        // Web
        m_BuildWebGL    = EditorGUILayout.Toggle("Web GL", m_BuildWebGL);

        if(GUILayout.Button("Build"))
            StartBulkBuild();
	}

    private void StartBulkBuild()
	{
        BuildTarget currentBuildTarget = EditorUserBuildSettings.activeBuildTarget;
        BuildTargetGroup currentBuildTargetGroup = EditorUserBuildSettings.selectedBuildTargetGroup;

        EditorBuildSettingsScene[] scenes = EditorBuildSettings.scenes;

        // Desktop
        if(m_BuildMacOS) BuildPipeline.BuildPlayer(scenes, "./Builds/Mac OS/", BuildTarget.StandaloneOSX, BuildOptions.None);
        if(m_BuildLinux) BuildPipeline.BuildPlayer(scenes, "./Builds/Linux/", BuildTarget.StandaloneLinux64, BuildOptions.None);
        if(m_BuildWin86) BuildPipeline.BuildPlayer(scenes, $"./Builds/Windows/x86/{Application.productName}.exe", BuildTarget.StandaloneWindows, BuildOptions.None);
        if(m_BuildWin64) BuildPipeline.BuildPlayer(scenes, $"./Builds/Windows/x64/{Application.productName}.exe", BuildTarget.StandaloneWindows, BuildOptions.None);

        // Mobile
        if(m_BuildiOS) BuildPipeline.BuildPlayer(scenes, "./Builds/iOS/", BuildTarget.iOS, BuildOptions.None);
        if(m_BuildAndroid) BuildPipeline.BuildPlayer(scenes, $"./Builds/{Application.productName}.apk", BuildTarget.Android, BuildOptions.None);

        // Web
        if(m_BuildWebGL) BuildPipeline.BuildPlayer(scenes, "./Builds/Web GL", BuildTarget.WebGL, BuildOptions.None);

        // Switch back to the platform that was selected before building others
        EditorUserBuildSettings.SwitchActiveBuildTarget(currentBuildTargetGroup, currentBuildTarget);
	}
}