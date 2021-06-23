using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bifrost_Website
{
    public class ProfileModel : PageModel
    {

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Name { get; set; }

        public void OnGet()
        {
            var user_id = new Byte[100];
            if (!HttpContext.Session.TryGetValue("user_id", out user_id))
            {
                Response.Redirect("Login");
            }
            Api_call api = new Api_call();
        }
    }
}
