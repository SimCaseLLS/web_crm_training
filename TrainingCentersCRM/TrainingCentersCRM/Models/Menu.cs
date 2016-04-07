namespace TrainingCentersCRM.Models
{

using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
public partial class Menu
{

    public int Id { get; set; }

    [Display(Name="Название")]
    public string Title { get; set; }

    [Display(Name = "Описание")]
    public string Description { get; set; }

    [Display(Name = "Ссылка")]
    public string Link { get; set; }

    [Display(Name = "Внешняя ссылка")]
    public bool NotBindInTrainingCenter { get; set; }

    [Display(Name = "URL")]
    public string IdTrainingCenter { get; set; }

    [Display(Name = "Родительский Id")]
    public int Parent_Id { get; set; }

    [Display(Name = "Номер с списке")]
    public int Ord_Id { get; set; }

}

}
