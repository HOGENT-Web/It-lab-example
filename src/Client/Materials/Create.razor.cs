using System;
using System.Threading.Tasks;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Shared.Materials;

namespace Client.Materials
{
	public partial class Create
	{
		private MaterialDto.Create model = new();

		[Inject] public IMaterialService MaterialService { get; set; }
		[Inject] public NavigationManager NavigationManager { get; set; }
		[Inject] public IToastService Notifier { get; set; }

		private async Task SubmitForm()
		{
			await MaterialService.CreateAsync(model);
			NavigationManager.NavigateTo("/");
			Notifier.ShowSuccess("Material was added!");
		}
    }
}

