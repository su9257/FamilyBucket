using UnityEngine;

public class MethodInjection : MonoBehaviour
{
    void Start()
    {
        var people = new People();

        people.Eat(new Hamburger());

        people.Eat(new Dumplings());
    }

}

public class People
{
    public void Eat(IFood food)
    {
        Debug.Log($"吃：{food.ToContent()}");
    }
}

public interface IFood
{
    string ToContent();
}

public class Hamburger : IFood
{
    public string ToContent()
    {
        return "汉堡";
    }
}
public class Dumplings : IFood
{
    public string ToContent()
    {
        return "饺子";
    }
}