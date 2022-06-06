using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace localization_demo.Models;

public class Language
{
    public Language(string identifier, string name)
    {
        Identifier = identifier;
        Name = name;
    }

    public string Identifier { get; set; }
    public string Name { get; set; }

    public override string ToString()
    {
        return Name;
    }
}
