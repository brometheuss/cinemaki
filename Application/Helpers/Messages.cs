using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Helpers
{
    public class Messages
    {
        #region Common

        public const string CREATE_SUCCESS = "Entry successfully added.";
        public const string CREATE_ERROR = "Oops. Something went wrong, try again.";
        public const string EDIT_SUCCESS = "Your edit was successful.";
        public const string EDIT_ERROR = "Something went wrong, try again.";
        public const string DELETE_SUCCESS = "Entry successfully deleted.";
        public const string DELETE_ERROR = "An error has occurred, try again.";

        #endregion

        #region User

        public const string UPDATE_PASSWORD_DIFFERENT = "New password and Confirm new password fields must be identical";
        public const string UPDATE_PASSWORD_OLD_NOT_CORRECT = "Your current password is incorrect.";

        #endregion
    }
}
