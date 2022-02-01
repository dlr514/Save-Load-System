    public void Save()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Save save = new Save();
        save.playerPosition = player.transform.position;
        save.goFasterBoots = goFasterBoots;
        save.lanternOil = lanternOil;
        save.blueCrystal = blueCrystal;
        save.key = key;
        save.scene = SceneManager.GetActiveScene();
        save.sceneName = scene.name;
        string jsonData = JsonUtility.ToJson(save);
        Debug.Log("JSON: " + jsonData);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", jsonData.ToString());
        Debug.Log("saved");
    }

    public void Load()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Save save = new Save();
        string jsonFileLocation = Application.persistentDataPath + "/savefile.json";
        string jsonData = File.ReadAllText(jsonFileLocation);
        save = JsonUtility.FromJson<Save>(jsonData);
        goFasterBoots = save.goFasterBoots;
        lanternOil = save.lanternOil;
        blueCrystal = save.blueCrystal;
        key = save.key;
        player.SetActive(false);
        player.transform.position = save.playerPosition;
        player.SetActive(true);
        Debug.Log("done");
        Debug.Log(player.transform.position);
        Debug.Log(save.playerPosition);
    }