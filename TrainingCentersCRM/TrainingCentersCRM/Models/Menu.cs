namespace TrainingCentersCRM.Models
{

using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
public partial class Menu
{

    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string Link { get; set; }

    [Display(Name = "¬нешн€€ ссылка")]
    public bool NotBindInTrainingCenter { get; set; }
    
    public string IdTrainingCenter { get; set; }

    public int Parent_Id { get; set; }

    public int Ord_Id { get; set; }

}

}
