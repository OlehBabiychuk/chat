using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chat.Models
{
    public class AccountViewModel
    {
        public class ExternalLoginConfirmationViewModel
        {
         
            public string Email { get; set; }
        }

        public class ExternalLoginListViewModel
        {
            public string ReturnUrl { get; set; }
        }

        public class SendCodeViewModel
        {
            public string SelectedProvider { get; set; }
            public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
            public string ReturnUrl { get; set; }
            public bool RememberMe { get; set; }
        }

        public class VerifyCodeViewModel
        {
         
            public string Provider { get; set; }

       
            public string Code { get; set; }
            public string ReturnUrl { get; set; }


            public bool RememberBrowser { get; set; }

            public bool RememberMe { get; set; }
        }

        public class ForgotViewModel
        {

            public string Email { get; set; }
        }

        public class LoginViewModel
        {
            
            public string Email { get; set; }

         
            public string Password { get; set; }

         
            public bool RememberMe { get; set; }
        }

        public class RegisterViewModel
        {
       
         
     
            public string Email { get; set; }

            

            public string Password { get; set; }


            public string ConfirmPassword { get; set; }
        }

        public class ResetPasswordViewModel
        {
          
            public string Email { get; set; }

        
            public string Password { get; set; }

         
            public string ConfirmPassword { get; set; }

            public string Code { get; set; }
        }

        public class ForgotPasswordViewModel
        {
       
            public string Email { get; set; }
        }
    }
}