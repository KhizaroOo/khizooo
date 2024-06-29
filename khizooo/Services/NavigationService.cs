using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace khizooo.Services
{
    public class NavigationService : IDisposable
    {
        private readonly NavigationManager _navigationManager;

        public NavigationService(NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
            _navigationManager.LocationChanged += OnLocationChanged;
        }

        private void OnLocationChanged(object? sender, LocationChangedEventArgs e)
        {
            // Perform the refresh or any action you need
            // You can call StateHasChanged on a specific component or trigger any update
        }

        public void Dispose()
        {
            _navigationManager.LocationChanged -= OnLocationChanged;
        }
    }


}

