using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pwd_validator
{
    public class Password_invalidate_Exception : System.Exception {
        public Password_invalidate_Exception(string s) : base(s) {
        }

    }
    public class password_validator

    {

        public  bool Verify_pwd(string password, string usertype) {

            if (usertype == "Internal")
            {
                
                var obj = Activator.CreateInstance(null,"Pwd_validator.Internal");
                var t = (Internal)obj.Unwrap();
                return t.Verify(password);
                
            }
            else {
                var obj = Activator.CreateInstance(null, "Pwd_validator.External");
                var t = (External)obj.Unwrap();
                bool s = t.Verify(password);
                return s;
            }

        }
    }

    public class Internal : password_validator {
        public static bool Validate_length(string s) {
            if (s.Length > 8) {
                return true;
            }
            throw (new Password_invalidate_Exception("Password length should be more than 8"));
        }

        public  bool Verify(string s) {

            if (Validate_length(s)) {
                return true;
            }
            throw new Password_invalidate_Exception("Password length must be greater than 8");
        }

    }

    public class External : password_validator {

        public static bool IsNull(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return true;
            }

            return false;
        }
        public static bool Atleast_one_upper_case(string s)
        {
            if (s.Any(character => Char.IsUpper(character)))
            {
                return true;
            }

            return false;
        }
        public static bool Atleast_one_lower_case(string s)
        {
            if (s.Any(character => Char.IsLower(character)))
            {
                return true;
            }

            return false;
        }
        public static bool Atleast_one_number(string s)
        {
            if (s.Any(character => Char.IsNumber(character)))
            {
                return true;
            }

            return false;
        }
        public static bool verify_length(string s)
        {
            if (s.Length > 8)
            {
                return true;
            }

            return false;
        }



        public  bool Verify(string s)
        {

            string exception = "";

            //checking if pasword is empty or not
            if (IsNull(s))
            {
                throw new Password_invalidate_Exception("Password should not be null");
            }

            //checking for atleast one upper case letter
            if (!Atleast_one_upper_case(s))
            {
                throw new Password_invalidate_Exception("Password should Contain atleast one upper case letter");
            }

            int failcount = 0;

            //checking for length is greater than 8 or not
            if (!verify_length(s))
            {
                failcount += 1;
                exception += "Password should be more than 8 characters";
            }

            //checking for  atleast one Lower case letter

            if (!Atleast_one_lower_case(s))
            {
                failcount += 1;
                exception += "Password should have one lowercase letter at least";
            }

            //verifying atleast one number
            if (!Atleast_one_number(s))
            {
                failcount += 1;
                exception += " Password should have one number at least";
            }

            //checking for atleast 3 conditions are true or not
            if ((5 - failcount) >= 3)
            {
                return true;
            }
            else
            {

                throw new Password_invalidate_Exception(exception);
            }
        }

    }
}
