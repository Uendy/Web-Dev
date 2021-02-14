public class Pokemon
{
    public string Name { get; set; }
    public int HP { get; set; }
    public string Element { get; set; }

    public Pokemon(string name, int hp, string element)
    {
        this.Name = name;
        this.HP = hp;
        this.Element = element;
    }
}