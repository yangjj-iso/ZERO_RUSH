using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic;
using System.Linq;
public class AudioImporter : AssetPostprocessor
{
    // 定义JSON⽂件的存放路径，这⾥我们放在Resources⽂件夹的根⽬录
    private static readonly string jsonFilePath = Path.Combine(Application.dataPath, "Resources/Audio", "audio_list.json");
    // 当任何资源被导⼊、删除或移动后，此⽅法会被调⽤
    static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
    {
        bool needsUpdate = false;
        AudioTypeList audioTypeList = LoadAudioList();
        // 检查新导⼊的资源
        foreach (string path in importedAssets)
        {
            // 检查⽂件是否为⾳频⽂件，并且是否在Resources⽂件夹下
            if (IsAudioFile(path) && path.Contains("/Resources/Audio"))
            {
                string resourcePath = GetResourcePath(path);
                if(audioTypeList.audios.Count == 0)
                {
                    AudioType newAudio = new AudioType(Path.GetFileNameWithoutExtension(path), resourcePath);
                    audioTypeList.audios.Add(newAudio);
                    needsUpdate = true;
                    Debug.Log($"检测到新⾳频⽂件: {newAudio.Name}，已添加到JSON列表。");
                }
                // 避免重复添加
                if (audioTypeList.audios.All(audio => audio.Path != resourcePath))
                {
                    AudioType newAudio = new AudioType(Path.GetFileNameWithoutExtension(path), resourcePath);
                    audioTypeList.audios.Add(newAudio);
                    needsUpdate = true;
                    Debug.Log($"检测到新⾳频⽂件: {newAudio.Name}，已添加到JSON列表。");
                }
            }
        }
        // (可选) 检查被删除的资源，如果需要的话也可以从JSON中移除
        foreach (string path in deletedAssets)
        {
            if (IsAudioFile(path) && path.Contains("/Resources/Audio"))
            {
                string resourcePath = GetResourcePath(path);
                int removedCount = audioTypeList.audios.RemoveAll(audio => audio.Path == resourcePath);
                if (removedCount > 0)
                {
                    needsUpdate = true;
                    Debug.Log($"检测到⾳频⽂件被删除: {path}，已从JSON列表中移除。");
                }
            }
        }
        // 如果有任何更新，则保存回JSON⽂件
        if (needsUpdate)
        {
            SaveAudioList(audioTypeList);
        }
    }
    // 从JSON⽂件加载⾳频列表
    private static AudioTypeList LoadAudioList()
    {
        if (File.Exists(jsonFilePath))
        {
            string json = File.ReadAllText(jsonFilePath);
            return JsonUtility.FromJson<AudioTypeList>(json) ?? new AudioTypeList();
        }
        return new AudioTypeList();
    }
    // 将⾳频列表保存到JSON⽂件
    private static void SaveAudioList(AudioTypeList list)
    {
        string json = JsonUtility.ToJson(list, true); // true表⽰格式化输出，⽅便查看
        File.WriteAllText(jsonFilePath, json);
        AssetDatabase.Refresh(); // 刷新资源数据库，让Unity编辑器知道⽂件已更改
        Debug.Log($"audio_list.json ⽂件已成功更新！");
    }
    // 判断⽂件是否为⾳频格式
    private static bool IsAudioFile(string path)
    {
        string extension = Path.GetExtension(path).ToLower();
        return extension == ".mp3" || extension == ".ogg" || extension == ".wav" || extension == ".aif"
        || extension == ".aiff";
    }
    // 将完整的资源路径 (Assets/Resources/Music/song.mp3) 转换为Resources.Load所需的相对路径 (Music/song)
    private static string GetResourcePath(string assetPath)
    {
        string path = assetPath.Substring(assetPath.IndexOf("/Resources/") +
        "/Resources/".Length);
        path = path.Substring(0, path.LastIndexOf('.'));
        return path;
    }
}