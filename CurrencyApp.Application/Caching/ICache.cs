namespace CurrencyApp.Application.Caching;

public interface ICache
{
	void PutItem(string key, object value);

	void PutItem(string key, object value, double timeoutInMinutes);

	Task PutItemAsync(string key, object value);

	Task PutItemAsync(string key, object value, double timeoutInMinutes);

	T GetItem<T>(string key);

	Task<T> GetItemAsync<T>(string key);
}
