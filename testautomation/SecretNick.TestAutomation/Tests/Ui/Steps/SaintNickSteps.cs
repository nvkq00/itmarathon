using Reqnroll;
using Microsoft.Playwright;
using SecretNick.TestAutomation.Tests.Ui.Pages;
using System.Threading.Tasks;

using Shouldly;

namespace SecretNick.TestAutomation.Tests.Ui.Steps
{
    [Binding]
    public class SaintNickSteps
    {
        private readonly IPage _page;
        private readonly SaintNickPage _saintNickPage;

        public SaintNickSteps(IPage page)
        {
            _page = page;
            _saintNickPage = new SaintNickPage(page);
        }

        [Given(@"I navigate to Saint Nick website")]
        public async Task GivenINavigateToSaintNickWebsite()
        {
            await _saintNickPage.NavigateToHomepage();
        }

        [Then(@"I should see the main header")]
        public async Task ThenIShouldSeeTheMainHeader()
        {
            var isVisible = await _saintNickPage.IsHeaderVisible();
            isVisible.ShouldBeTrue("Main header should be visible");
        }

        [Then(@"the page should have correct title")]
        public async Task ThenThePageShouldHaveCorrectTitle()
        {
            var title = await _saintNickPage.GetPageTitle();
            title.ShouldNotBeNullOrEmpty("Page title should not be empty");
            title.ShouldNotContain("Error");
        }

        [Then(@"the main content should be loaded")]
        public async Task ThenTheMainContentShouldBeLoaded()
        {
            var isLoaded = await _saintNickPage.IsContentLoaded();
            isLoaded.ShouldBeTrue("Main content should be loaded");
        }

        [Then(@"the website should be accessible")]
        public async Task ThenTheWebsiteShouldBeAccessible()
        {
            var isLoaded = await _saintNickPage.IsPageLoaded();
            isLoaded.ShouldBeTrue("Website should be accessible and loaded");
        }

        [Then(@"I should see text ""(.*)"" on the page")]
        public async Task ThenIShouldSeeTextOnThePage(string expectedText)
        {
            var containsText = await _saintNickPage.CheckPageContainsText(expectedText);
            containsText.ShouldBeTrue($"Page should contain text: {expectedText}");
        }
    }
}