namespace TrainingCentersCRM.Models
{

using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
public partial class Menu
{

    public int Id { get; set; }

    [Display(Name="��������")]
    public string Title { get; set; }

    [Display(Name = "��������")]
    public string Description { get; set; }

    [Display(Name = "������")]
    public string Link { get; set; }

    [Display(Name = "������� ������")]
    public bool NotBindInTrainingCenter { get; set; }

    [Display(Name = "URL")]
    public string IdTrainingCenter { get; set; }

    [Display(Name = "������������ Id")]
    public int Parent_Id { get; set; }

    [Display(Name = "����� � ������")]
    public int Ord_Id { get; set; }

}

}
