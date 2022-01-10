using Newtonsoft.Json;

namespace AnnuaireBloc4API
{
	public class DbError
	{
		[JsonProperty("errors")]
		//public DbErrorMessage Errors { get; set; }
		public string[] Errors = new string[1];

		[JsonProperty("title")]
		private string Title { get; set; }

		[JsonProperty("status")]
		private long _status = 400;


		public class DbErrorMessage
		{
			[JsonProperty("name")]
			public string[] Name { get; set; }

			public DbErrorMessage(string name)
			{
				Name = new string[] { name};
			}
		}

		public DbError(string title, string errorMessage)
		{
			Title = title;
			//Errors = new DbErrorMessage(errorMessage);
			Errors[0] = errorMessage;
		}
	}
}