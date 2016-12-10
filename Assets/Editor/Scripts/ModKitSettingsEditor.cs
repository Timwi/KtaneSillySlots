using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ModConfig))]
public class ModKitSettingsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        EditorGUILayout.Separator();
        EditorGUILayout.BeginHorizontal();

        ModConfig mc = (ModConfig)this.target;
        
        GUIContent idLabel = new GUIContent("Mod ID", "Identifier for the mod. Affects assembly name and output name.");
        GUI.changed = false;
        mc.ID = EditorGUILayout.TextField(idLabel, mc.ID);
        SetDirtyOnGUIChange();
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Separator();
        EditorGUILayout.BeginHorizontal();
        GUIContent titleLabel = new GUIContent("Mod Title", "Name of the mod as it appears in game.");
        GUI.changed = false;
        mc.Title = EditorGUILayout.TextField(titleLabel, mc.Title);
        SetDirtyOnGUIChange();
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Separator();
        EditorGUILayout.BeginHorizontal();
        GUIContent versionLabel = new GUIContent("Mod Version", "Current version of the mod.");
        GUI.changed = false;
        mc.Version = EditorGUILayout.TextField(versionLabel, mc.Version);
        SetDirtyOnGUIChange();
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Separator();
        EditorGUILayout.BeginHorizontal();
        GUIContent bundleNameLabel = new GUIContent("Bundle Name", "Name of the bundle tag to select assets to bundle.");
        GUI.changed = false;
        mc.BundleName = EditorGUILayout.TextField(bundleNameLabel, mc.BundleName);
        SetDirtyOnGUIChange();
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Separator();
        EditorGUILayout.BeginHorizontal();
        GUIContent workshopItemLabel = new GUIContent("Workshop Item", "Workshop settings.");
        GUI.changed = false;
        mc.WorkshopConfig = (WorkshopItem)EditorGUILayout.ObjectField(workshopItemLabel, mc.WorkshopConfig, typeof(WorkshopItem), false);
        SetDirtyOnGUIChange();
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Separator();
        EditorGUILayout.BeginHorizontal();
        GUIContent outputFolderLabel = new GUIContent("Mod Output Folder", "Folder relative to the project where the built mod bundle will be placed.");
        GUI.changed = false;
        mc.OutputFolder = EditorGUILayout.TextField(outputFolderLabel, mc.OutputFolder);
        SetDirtyOnGUIChange();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.HelpBox("This folder will be cleaned with each build.", MessageType.Warning);

        GUI.enabled = true;
    }

    private void SetDirtyOnGUIChange()
    {
        if (GUI.changed)
        {
            ModConfig mc = (ModConfig)this.target;
            EditorUtility.SetDirty(mc);
            GUI.changed = false;
        }
    }
}
