using System.ComponentModel.DataAnnotations;

namespace TicTacToe.Extensions
{
    public static class StringEmailValidExtension
    {
        public static bool IsEmailValid(this string email)
        {
            if (email != null)
            {
                var emailAddress = new EmailAddressAttribute();
                return emailAddress.IsValid(email);
            }
            return false;
        }
    }
}
