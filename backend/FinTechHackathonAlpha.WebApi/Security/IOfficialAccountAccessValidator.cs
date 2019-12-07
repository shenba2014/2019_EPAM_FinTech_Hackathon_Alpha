namespace FinTechHackathonAlpha.WebApi.Security
{
	public interface IOfficialAccountAccessValidator
	{
		bool IsValid(string signature, string timestamp, string nonce, string echostr);
	}
}