using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace Whatsup.Controllers
{
    public class PasswordHashing
    {
        // Create the variables...
        // Remember: This password is just being shown to show the actual text being passed, 
        // In real applications you shouldn't show the password to the User.
        var password = "";
        var hashed = "";
        var sha256 = "";
        var sha1 = "";

        var salt = "";

        var hashedPassword = "";
        var verify = false;
    
        // If the request is a POST request, then
        if (IsPost)
        {
           // Get the password
           password = Request.Form["password"];
        
           // Run the functions on the code, 
           hashed = Crypto.Hash(password, "MD5");
           sha256 = Crypto.SHA256(password);
           sha1 = Crypto.SHA1(password);

           salt = Crypto.GenerateSalt();

           hashedPassword = Crypto.HashPassword(password);

           // First parameter is the previously hashed string using a Salt
           verify = Crypto.VerifyHashedPassword("{hash_password_here}", password);
    }
}