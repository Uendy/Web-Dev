using System.Collections.Generic;
public class Vlogger
{
    public string Name { get; set; }
    public HashSet<string> Following { get; set; }
    public HashSet<string> Followers { get; set; }
}