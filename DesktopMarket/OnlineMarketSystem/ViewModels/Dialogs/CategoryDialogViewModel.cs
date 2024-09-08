using MvvmHelpers.Commands;
using OnlineMarketSystem.Models;
using OnlineMarketSystem.Services;
using System.Windows.Input;

namespace OnlineMarketSystem.ViewModels;

public class CategoryDialogViewModel
{
    private readonly CategoriesService _categoriesService;

    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }

    public ICommand SaveCommand { get; }

    public CategoryDialogViewModel()
    {
        SaveCommand = new Command(OnSave);

        _categoriesService = new();
    }

    private void OnSave()
    {
        var category = new Category()
        {
            Name = this.Name,
            Description = this.Description,
            CreatedAt = DateTime.Now
        };

        _categoriesService.Create(category);    
    }
}
