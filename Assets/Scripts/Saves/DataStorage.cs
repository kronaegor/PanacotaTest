using AYellowpaper.SerializedCollections;
using System;
using System.IO;
using UnityEngine;

public class DataStorage : MonoBehaviour
{
    private SerializedDictionary<string, string> _data = new();
    private string _path;
    public event Action OnGameLoading;
    public event Action OnSavesEmpty;
    private void Start()
    {
        _path = Path.Combine(Application.persistentDataPath, "SavePlayerData.txt");
        if (!File.Exists(_path))
        {
            FileInfo file = new(_path);
            file.Create();
            OnSavesEmpty?.Invoke();
            return;
        }
        if (File.ReadAllText(_path) == string.Empty)
        {
            OnSavesEmpty?.Invoke();
            return;
        }
        _data = JsonUtility.FromJson<SerializedDictionary<string, string>>(File.ReadAllText(_path));
        OnGameLoading?.Invoke();
    }
    private void CollectInformathion(string key, string value)
    {
        if (_data.ContainsKey(key) != true)
        {
            _data.Add(key, value);
        }
        else
        {
            _data[key] = value;
        }
        File.WriteAllText(_path, string.Empty);
        File.WriteAllText(_path, JsonUtility.ToJson(_data));
    }
    public void SaveInfo(object data, string key)
    {
        string item = JsonUtility.ToJson(data);
        CollectInformathion(key, item);
    }
    public T LoadInormathion<T>(string key)
    {
        string item = _data[key];
        return JsonUtility.FromJson<T>(item);
    }
}
