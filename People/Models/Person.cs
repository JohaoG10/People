using SQLite;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace People.Models;

[Table("people")]
public class Person
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [MaxLength(250), Unique]
    public string Name { get; set; }
}