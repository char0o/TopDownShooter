using System.Collections;

namespace TopDownShooter.Components;

public class Animations : IEnumerable<Animation>
{
    public List<Animation> Values { get; private set; } = new List<Animation>();

    public void Add(Animation animation)
    {
        Values.Add(animation);
    }

    public Animation? GetByName(string name)
    {
        return Values.FirstOrDefault(a => a.AnimationName == name);
    }

    public IEnumerator<Animation> GetEnumerator()
    {
        return Values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}