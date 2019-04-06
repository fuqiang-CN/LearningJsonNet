using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LearningJsonNet
{
  public class Student
  {
    public long Id { get; set; }
    public string Name { get; set; }
    public List<string> Classes { get; set; }
  }
}