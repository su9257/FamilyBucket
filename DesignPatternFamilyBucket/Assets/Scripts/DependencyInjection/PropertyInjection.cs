using UnityEngine;

public class PropertyInjection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var game = new Game();

        game.Platform = new PC_Platform();
        game.Play();

        game.Platform = new Mobile_Platform();
        game.Play();
    }

}

public class Game
{
    public IPlatform Platform { get; set; }
    public void Play()
    {
        var tempStr = $"游戏运行在：{Platform.ToContent()} 平台";
        Debug.Log(tempStr);
    }
}


public interface IPlatform
{
    string ToContent();
}


public class PC_Platform : IPlatform
{
    public string ToContent()
    {
        return "PC";
    }
}

public class Mobile_Platform : IPlatform
{
    public string ToContent()
    {
        return "Mobile";
    }
}
