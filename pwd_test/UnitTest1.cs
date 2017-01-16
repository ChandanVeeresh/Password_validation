using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pwd_validator;
namespace pwd_test
{
    [TestClass]
    public class UnitTest1
    {


        public password_validator p = new password_validator(); 

        //Internal class methods
        [TestMethod]
        public void PasswordLength_moreThan8_returnstrue_INTERNAL()
        {

            Assert.AreEqual(true, p.Verify_pwd("chandanavc","Internal"), " password is not Ok");
        }
        [TestMethod,ExpectedException(typeof(Password_invalidate_Exception))]
        public void PasswordLength_LessThan8_ThrowsException_Internal() {
            Assert.AreEqual(true, p.Verify_pwd("chanda", "Internal"), " password is not Ok");
        }


        //External class Methods

        [TestMethod]
        public void PasswordMatches_Atleast3Conditions_ReturnsTrue_EXTERNAL()
        {

            Assert.AreEqual(true, p.Verify_pwd("Chandanavc", "External"), " password is not Ok");
        }

        [TestMethod, ExpectedException(typeof(Password_invalidate_Exception))]
        public void IncorrectPassword_FailsMoreThan2Conditions_ThrowsException_EXTERNAL()
        {
            Assert.AreEqual(true, p.Verify_pwd("$$$$$$", "External"), " password is not Ok");
        }

        [TestMethod, ExpectedException(typeof(Password_invalidate_Exception))]
        public void EmptyPassword_ThrowsException_EXTERNAL()
        {

            p.Verify_pwd("","External");

        }
        [TestMethod, ExpectedException(typeof(Password_invalidate_Exception))]
        public void PassingLowerCasePWd_CheckingPWDContainsAtleastOneUpperCase_ThrowsException_External()
        {

            p.Verify_pwd("ca","External");

        }
        [TestMethod, ExpectedException(typeof(Password_invalidate_Exception))]
        public void PassingUpperCasePWd_CheckingPWDContainsAtleastOneLowerCase_ThrowsException_External()
        {

            p.Verify_pwd("ABC","External");

        }
        [TestMethod, ExpectedException(typeof(Password_invalidate_Exception))]
        public void CheckingPwdContainsAtleastOneNumbers_ThorwsException_EXTERNAL()
        {
            p.Verify_pwd("ab","External");
        }
        [TestMethod, ExpectedException(typeof(Password_invalidate_Exception))]
        public void CheckingPasswordLengthIsGreaterThan8_ThrowsException_External()
        { 
            p.Verify_pwd("$$$","External");
        }
        [TestMethod]
        public void CheckingIfPasswordMatchesAllConditions_ReturnsTrue_External() {
            p.Verify_pwd("ChandanAV8", "External");

        }

    }
}
