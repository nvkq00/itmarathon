using Microsoft.Playwright;
using System.Threading.Tasks;

namespace SecretNick.TestAutomation.Tests.Ui.Pages
{
    public class SaintNickPage
    {
        private readonly IPage _page;
        
        private ILocator Header => _page.Locator("h1, h2, .header, [class*='header']");
        private ILocator MainContent => _page.Locator("main, .content, .container, [class*='main']");
        private ILocator Body => _page.Locator("body");

        public SaintNickPage(IPage page)
        {
            _page = page;
        }

        public async Task NavigateToHomepage()
        {
            await _page.GotoAsync("https://saintnick.netlify.app");
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        }

        public async Task<bool> IsHeaderVisible()
        {
            return await Header.First.IsVisibleAsync();
        }

        public async Task<bool> IsContentLoaded()
        {
            return await MainContent.First.IsVisibleAsync();
        }

        public async Task<bool> IsPageLoaded()
        {
            return await Body.IsVisibleAsync();
        }

        public async Task<string> GetPageTitle()
        {
            return await _page.TitleAsync();
        }

        public string GetCurrentUrl()
        {
            return _page.Url;
        }

        public async Task<bool> CheckPageContainsText(string text)
        {
            var pageContent = await _page.TextContentAsync("body");
            return pageContent?.Contains(text) ?? false;
        }
    }
}