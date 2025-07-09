using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class GunImporter : AssetPostprocessor
{
    // 定义JSON⽂件的存放路径，这⾥我们放在Resources⽂件夹的根⽬录
    private static readonly string _jsonFilePath = Path.Combine(Application.dataPath, "Resources/Prefab/Weapon", "gun_list.json");
    // 当任何资源被导⼊、删除或移动后，此⽅法会被调⽤
    static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
    {
        bool needsUpdate = false;
        GunList gunList = LoadGunList();
        // 检查新导⼊的资源
        foreach (string path in importedAssets)
        {
            // 检查⽂件是否为子弹物体，并且是否在Resources⽂件夹下
            if (IsPrefabFile(path) && path.Contains("Resources/Prefab/Weapon/Gun"))
            {
                string resourcePath = GetResourcePath(path);
                // 避免重复添加
                if (gunList.guns.All(gun => gun.Path != resourcePath))
                {
                    GunType newGun = new GunType
                    {
                        Name = Path.GetFileNameWithoutExtension(path),
                        Path = resourcePath
                    };
                    gunList.guns.Add(newGun);
                    needsUpdate = true;
                    Debug.Log($"检测到新枪械物体: {newGun.Name}，已添加到JSON列表。");
                }
            }
        }
        // (可选) 检查被删除的资源，如果需要的话也可以从JSON中移除
        foreach (string path in deletedAssets)
        {
            if (IsPrefabFile(path) && path.Contains("Resources/Prefab/Weapon/Gun"))
            {
                string resourcePath = GetResourcePath(path);
                int removedCount = gunList.guns.RemoveAll(gun => gun.Path == resourcePath);
                if (removedCount > 0)
                {
                    needsUpdate = true;
                    Debug.Log($"检测到枪械物体被删除: {path}，已从JSON列表中移除。");
                }
            }
        }
        // 如果有任何更新，则保存回JSON⽂件
        if (needsUpdate)
        {
            SaveGunList(gunList);
        }
    }
    // 从JSON⽂件加载⾳频列表
    private static GunList LoadGunList()
    {
        if (File.Exists(_jsonFilePath))
        {
            string json = File.ReadAllText(_jsonFilePath);
            return JsonUtility.FromJson<GunList>(json) ?? new GunList();
        }
        return new GunList();
    }
    // 将⾳频列表保存到JSON⽂件
    private static void SaveGunList(GunList list)
    {
        string json = JsonUtility.ToJson(list, true); // true表⽰格式化输出，⽅便查看
        File.WriteAllText(_jsonFilePath, json);
        AssetDatabase.Refresh(); // 刷新资源数据库，让Unity编辑器知道⽂件已更改
        Debug.Log($"gun_list.json ⽂件已成功更新！");
    }
    // 判断⽂件是否为⾳频格式
    private static bool IsPrefabFile(string path)
    {
        string extension = Path.GetExtension(path).ToLower();
        return extension == ".prefab";
    }
    // 将完整的资源路径 (Assets/Resources/Music/song.mp3) 转换为Resources.Load所需的相对路径
    private static string GetResourcePath(string assetPath)
    {
        string path = assetPath.Substring(assetPath.IndexOf("/Resources/") +
        "/Resources/".Length);
        path = path.Substring(0, path.LastIndexOf('.'));
        return path;
    }
}