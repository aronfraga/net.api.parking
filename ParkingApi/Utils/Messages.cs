namespace ParkingApi.Utils {
	public class Messages {

		public const string CREATED        = "created succesfully!";
		public const string UPDATED        = "updated succesfully!";
		public const string DELETED        = "deleted succesfully!";

		public const string NO_MATCH       = "no matches found, check the id number";

		public const string USER_NO_ID     = "The user id must be required and must be an integer";
		public const string USER_NO_EMAIL  = "The email must be required and must be a string";
		public const string USER_NO_PASS   = "The password must be required and must be a string";
		public const string USER_NO_FIRNA  = "The firstname must be required and must be a string";
		public const string USER_NO_LASTNA = "The lastname must be required and must be a string";
		public const string USER_NO_EXIST  = "The user does not exist check id and try again";
		public const string USER_EXIST     = "The email is already in the database";
		

		public const string VEHI_NO_PLATE  = "The plate must be required and must be a string";
		public const string VEHI_EXIST     = "The plate is already in the database";
		public const string VEHI_NO_EXIST  = "The vehicle does not exist check id and try again";
		public const string VEHI_NO_ID     = "The vehicle id must be required and must be an integer";
	}
}
