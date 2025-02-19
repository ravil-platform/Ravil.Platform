using System.Text.Json;
using ViewModels.AdminPanel.Job;

namespace Application.Services.NehsanApi
{
    public class NeshanApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public NeshanApiService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["Neshan:ApiKey"];
        }

        public async Task<LocationDataViewModel?> GetReverseGeocodeAsync(string latitude, string longitude)
        {
            string url = $"https://api.neshan.org/v5/reverse?lat={latitude}&lng={longitude}";
            if (!_httpClient.DefaultRequestHeaders.Contains("Api-Key"))
            {
                _httpClient.DefaultRequestHeaders.Add("Api-Key", _apiKey);
            }
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true, // بی‌تفاوت به حروف بزرگ و کوچک
                        AllowTrailingCommas = true // پشتیبانی از کاماهای اضافی در JSON
                    };

                    LocationDataViewModel? locationDataViewModel = System.Text.Json.JsonSerializer.Deserialize<LocationDataViewModel>(jsonResponse, options);

                    return locationDataViewModel;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        #region ( GetCityState )
        
        public async Task<CityBase?> GetCityState(string city, string state, string neighbourhood, IUnitOfWork unitOfWork)
        {
            if (!string.IsNullOrWhiteSpace(city))
            {
                state = string.IsNullOrWhiteSpace(state) ? "البرز" : state;
                string stateName = state.Contains("استان") ? state.Replace("استان", "").Trim() : state;

                var stateBase = await unitOfWork.StateBaseRepository.TableNoTracking.Where(a => EF.Functions.Like(a.Name, $"%{state}%") 
                    || EF.Functions.Like(a.Name, $"%{stateName}%")).FirstOrDefaultAsync();

                if (!string.IsNullOrWhiteSpace(neighbourhood))
                {
                    neighbourhood = neighbourhood.Trim();
                    var checkNeighbourhoodExist = await unitOfWork.CityBaseRepository.TableNoTracking.AnyAsync(a => a.Name.Equals(neighbourhood));
                    if (checkNeighbourhoodExist)
                    {
                        city = neighbourhood;
                    }
                }

                if (stateBase != null)
                {
                    var cityBase = await unitOfWork.CityBaseRepository.TableNoTracking.Include(a => a.City)
                        .FirstOrDefaultAsync(a => a.Name.Equals(city) && a.StateId.Equals(stateBase.Id));

                    return cityBase;
                }
            }
            return null;
        }

        #endregion
    }
}
