using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities;

public class Cast
{
    public int id { get; set; }
    public string name { get; set; }
    public string ProfilePath { get; set; }
    public string TmdbUrl { get; set; }
    
}