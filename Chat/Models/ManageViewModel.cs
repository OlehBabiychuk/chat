using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace Chat.Models
{
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool BrowserRemembered { get; set; }
    }

    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }

    public class FactorViewModel
    {
        public string Purpose { get; set; }
    }

    public class SetPasswordViewModel
    {
       
        public string NewPassword { get; set; }

        
        public string ConfirmPassword { get; set; }
    }

    public class ChangePasswordViewModel
    {
        
        public string OldPassword { get; set; }

        
        public string NewPassword { get; set; }

       
        public string ConfirmPassword { get; set; }
    }

    public class AddPhoneNumberViewModel
    {
        public string Number { get; set; }
    }

    public class VerifyPhoneNumberViewModel
    {
      
        public string Code { get; set; }

       
        public string PhoneNumber { get; set; }
    }

    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }
}