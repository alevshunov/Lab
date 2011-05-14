namespace Example.Queries.Results
{
	public class Message
	{
		public Message(int id, string text)
		{
			Id = id;
			Text = text;
		}

		public int Id { get; set; }
		public string Text { get; set; }
	}
}