using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace Rehber.Areas.Admin.ViewModels
{
    public class UsersIndex
    {
       

    }

    public class RoleCheckBox
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool isChecked { get; set; }
    }
    public class UsersNew
    {
       
        [Required, MaxLength(128)]
        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, MaxLength(256)]
        public string Isim { get; set; }
        [Required, MaxLength(128)]
        public string Soyisim { get; set; }
        [Required, MaxLength(11)]
        public string Telefon { get; set; }
        [Required, MaxLength(128)]
        public string Departman { get; set; }
        [Required, MaxLength(128)]
        public string Rol { get; set; }
       
       
    }
    public class UsersEdit
    {
        [Required, MaxLength(128)]
        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, MaxLength(256)]
        public string Isim { get; set; }
        [Required, MaxLength(128)]
        public string Soyisim { get; set; }
        [Required, MaxLength(128)]
        public string Telefon { get; set; }
        [Required, MaxLength(128)]
        public string Departman { get; set; }
        [Required, MaxLength(128)]
        public string Rol { get; set; }
    }
    public class UsersResetPassword
    {
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

}