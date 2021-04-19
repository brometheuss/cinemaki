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
        public const string INPUT_ERROR = "Please check your input.";

        #endregion

        #region User

        public const string UPDATE_PASSWORD_DIFFERENT = "New password and Confirm new password fields must be identical";
        public const string UPDATE_PASSWORD_OLD_NOT_CORRECT = "Your current password is incorrect.";
        public const string USER_CREATE_SUCCESS = "User has been successfully added.";
        public const string USER_CREATE_ERROR = "There has been an error while trying to add user.";
        public const string USER_EDIT_SUCCESS = "User successfully updated.";
        public const string USER_EDIT_ERROR = "There has been an error while trying to update user.";
        public const string USER_DELETE_SUCCESS = "User successfully deleted.";
        public const string USER_DELETE_ERROR = "There has been an error while trying to delete user."; 

        #endregion
    }
}
