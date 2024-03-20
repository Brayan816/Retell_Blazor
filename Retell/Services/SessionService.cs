using Blazored.LocalStorage;
using Newtonsoft.Json;
using Retell.Commons;

namespace Retell.Services
{
    public interface ISessionService
    {
        Task SetSessionValue(string key, dynamic value);
        Task<string> GetSessionValue(string key);
        Task<T> GetSessionObject<T>(string key);
        Task DeleteSessionValue(string key);

    }
    public class SessionService : ISessionService
    {
        private ILocalStorageService _storage;
        public SessionService(ILocalStorageService storage)
        {
            _storage = storage;
        }
        public async Task SetSessionValue(string key, dynamic value)
        {
            if (key is null)
                throw new ArgumentException("El parametro no puede ser nulo", nameof(key));
            string stringValue;
            if(value is int || value is double || value is float || value is bool || value is long || value is byte || value is decimal || value is string)
                stringValue = value.ToString();
            else
                stringValue = JsonConvert.SerializeObject(value);

            string keyencrypt = Security.Encrypt(key);
            string valueEncrpt = Security.Decrypt(stringValue);

            await _storage.SetItemAsStringAsync(keyencrypt, valueEncrpt);
        }

        public async Task<string?> GetSessionValue(string key)
        {
            if (key is null)
                throw new ArgumentException("El parámetro no puede ser nulo", nameof(key));

            try
            {
                bool containsKey = await _storage.ContainKeyAsync(Security.Encrypt(key));
                if (!containsKey)
                    return "";

                string stringEncrypt = await _storage.GetItemAsStringAsync(Security.Encrypt(key));

                var stringValue = Security.Decrypt(stringEncrypt);

                return stringValue ?? "";
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<T?> GetSessionObject<T>(string key)
        {
            if (key is null)
                throw new ArgumentException("El parámetro no puede ser nulo", nameof(key));

            try
            {
                bool containsKey = await _storage.ContainKeyAsync(Security.Encrypt(key));

                if (!containsKey)
                    return default;

                string stringEncrypt = await _storage.GetItemAsStringAsync(Security.Encrypt(key));

                var stringValue = Security.Decrypt(stringEncrypt);

                T? response = JsonConvert.DeserializeObject<T>(stringValue);

                return response;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }
        public async Task DeleteSessionValue(string key)
        {
            if (key is null)
                throw new ArgumentException("El parámetro no puede ser nulo", nameof(key));

            try
            {
                await _storage.RemoveItemAsync(Security.Encrypt(key));
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }
    }
}
