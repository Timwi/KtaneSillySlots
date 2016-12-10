using UnityEngine;
using System.Collections;
using Newtonsoft.Json;
using System.Collections.Generic;

#if UNITY_EDITOR
[UnityEditor.InitializeOnLoad]
#endif
[CreateAssetMenu(fileName = "MODNAMEConfig", menuName = "Create ModConfig")]
public sealed class ModConfig : ScriptableObject
{
    [SerializeField]
    public string ID = "";
    [SerializeField]
    public string Title = "";
    [SerializeField]
    public string Version = "";
    [SerializeField]
    public string OutputFolder = "build";
    [SerializeField]
    public string BundleName = "mod.bundle";
    [SerializeField]
    public WorkshopItem WorkshopConfig;

    public string ToJson()
    {
        Dictionary<string, object> dict = new Dictionary<string, object>();
        dict.Add("id", ID);
        dict.Add("title", Title);
        dict.Add("version", Version);
        dict.Add("bundleName", BundleName);
        dict.Add("workshopItem", WorkshopConfig.GetInstanceID());
        return JsonConvert.SerializeObject(dict); ;
    }
}