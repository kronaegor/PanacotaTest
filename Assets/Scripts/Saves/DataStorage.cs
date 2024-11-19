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
            file.Create().Dispose();
            OnSavesEmpty?.Invoke();
            return;
        }
        if (File.ReadAllText(_path) == string.Empty)
        {
            OnSavesEmpty?.Invoke();
            return;
        }
        using (var streamReader = new StreamReader(_path))
        {
            _data = JsonUtility.FromJson<SerializedDictionary<string, string>>(streamReader.ReadLine());
        }
        
        OnGameLoading?.Invoke();
    }
    private void CollectInformathion(string key, string value)
    {
        _path = Path.Combine(Application.persistentDataPath, "SavePlayerData.txt");
        if (_data.ContainsKey(key) != true)
        {
            _data.Add(key, value);
        }
        else
        {
            _data[key] = value;
        }
        using (var streamWriter = new StreamWriter(_path, false))
        {
            streamWriter.Write(JsonUtility.ToJson(_data));
        }
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
