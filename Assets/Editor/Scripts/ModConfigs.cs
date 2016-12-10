using UnityEngine;
using System.Collections;
using Newtonsoft.Json;
using System.Collections.Generic;

#if UNITY_EDITOR
[UnityEditor.InitializeOnLoad]
#endif
[CreateAssetMenu(fileName = "ModConfigs", menuName = "Create ModConfigs List")]
public sealed class ModConfigs : ScriptableObject
{
    public ModConfig activeMod;
    public ModConfig[] configs;

    public static string ID
    {
        get { return Instance.Active.ID; }
        set { Instance.Active.ID = value; }
    }

    public static string Title
    {
        get { return Instance.Active.Title; }
        set { Instance.Active.Title = value; }
    }

    public static string Version
    {
        get { return Instance.Active.Version; }
        set { Instance.Active.Version = value; }
    }

    public static string OutputFolder
    {
        get { return Instance.Active.OutputFolder; }
        set { Instance.Active.OutputFolder = value; }
    }

    public static string BundleName
    {
        get { return Instance.Active.BundleName; }
        set { Instance.Active.BundleName = value; }
    }

    public static WorkshopItem WorkshopConfig
    {
        get { return Instance.Active.WorkshopConfig; }
        set { Instance.Active.WorkshopConfig = value; }
    }

    private static ModConfigs instance;
    public static ModConfigs Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Resources.Load<ModConfigs>("ModConfigs");
            }
            return instance;
        }

        set
        {
            instance = value;
        }
    }

    public ModConfig Active
    {
        get { return activeMod; }
    }
}