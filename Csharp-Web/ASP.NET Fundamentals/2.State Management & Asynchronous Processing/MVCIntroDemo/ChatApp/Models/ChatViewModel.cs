namespace ChatApp.Models
{
	public class ChatViewModel
	{
		public MessageViewModel CurrenMessage { get; set; } = null!;
		public List<MessageViewModel> Messages { get; set; } = null!;
	}
}
