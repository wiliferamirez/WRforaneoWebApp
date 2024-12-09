using System.Text.Json;
using System.Net.Http;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace foraneoAppMaui
{
    public partial class CategoriesPage : ContentPage
    {
        private readonly HttpClient _httpClient;
        private ObservableCollection<Category> _categories;

        public CategoriesPage(HttpClient httpClient)
        {
            InitializeComponent();
            _httpClient = httpClient;
            _categories = new ObservableCollection<Category>();
            CategoriesList.ItemsSource = _categories;

            LoadCategories();
        }

        private async void LoadCategories()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://localhost:7019/api/categories");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<ApiResponse<Category>>(json);
                    _categories.Clear();
                    foreach (var category in result.Data)
                    {
                        _categories.Add(category);
                    }
                }
                else
                {
                    await DisplayAlert("Error", "Failed to load categories.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async void OnEditClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var categoryId = (int)button.CommandParameter;

//            await Navigation.PushAsync(new EditCategory(_httpClient, categoryId));
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var categoryId = (int)button.CommandParameter;

            var confirm = await DisplayAlert("Confirm Delete", "Are you sure you want to delete this category?", "Yes", "No");
            if (confirm)
            {
                try
                {
                    var response = await _httpClient.DeleteAsync($"https://localhost:7019/api/categories/{categoryId}");
                    if (response.IsSuccessStatusCode)
                    {
                        var category = _categories.FirstOrDefault(c => c.categoryId == categoryId);
                        if (category != null)
                        {
                            _categories.Remove(category);
                        }
                    }
                    else
                    {
                        await DisplayAlert("Error", "Failed to delete category.", "OK");
                    }
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", ex.Message, "OK");
                }
            }
        }
    }

    public class Category
    {
        public int categoryId { get; set; }
        public string categoryName { get; set; }
        public int order { get; set; }
    }

    public class ApiResponse<T>
    {
        public List<T> Data { get; set; }
    }
}
