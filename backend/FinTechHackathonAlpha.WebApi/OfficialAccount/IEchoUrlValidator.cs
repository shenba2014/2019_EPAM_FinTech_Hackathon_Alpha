namespace FinTechHackathonAlpha.WebApi.OfficialAccount
{
	public interface IEchoUrlValidator
	{
		bool IsValid(string signature, string timestamp, string nonce, string echostr);
	}
}