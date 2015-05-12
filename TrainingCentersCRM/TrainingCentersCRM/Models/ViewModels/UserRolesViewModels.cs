using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TrainingCentersCRM.Models
{
    public class SelectionRoleEditorViewModel
    {
        public string Name { get; set; }
        public bool Selected { get; set; }
    }

    public class SelectionUserEditorViewModel
    {
        public string UserName { get; set; }
        public string Id { get; set; }
        public List<SelectionRoleEditorViewModel> Roles { get; set; }

        public SelectionUserEditorViewModel()
        {
            this.Roles = new List<SelectionRoleEditorViewModel>();
        }
    }

    public class SelectionUsersRolesViewModel
    {
        public List<SelectionUserEditorViewModel> Users { get; set; }

        public SelectionUsersRolesViewModel()
        {
            this.Users = new List<SelectionUserEditorViewModel>();
        }
    }
}