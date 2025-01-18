using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelEjemploJF.Models;

public class JFMarvelCharacterc
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Thumbnail Thumbnail { get; set; }



    public string ImageUrl => $"{Thumbnail.Path}.{Thumbnail.Extension}";

}

public class Thumbnail
{
    public string Path { get; set; }
    public string Extension { get; set; }
}

public class MarvelApiResponse
{
    public DataWrapper Data { get; set; }
}

public class DataWrapper
{
    public List<JFMarvelCharacterc> Results { get; set; }
}
