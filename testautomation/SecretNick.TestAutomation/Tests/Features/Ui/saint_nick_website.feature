Feature: Saint Nick Website
  As a visitor
  I want to ensure saintnick.netlify.app works correctly
  So that I can trust the website functionality

  @ui @saintnick @smoke
  Scenario: Homepage loads successfully
    Given I navigate to Saint Nick website
    Then I should see the main header
    And the page should have correct title
    And the main content should be loaded
    And the website should be accessible

  @ui @saintnick
  Scenario: Check basic content on homepage
    Given I navigate to Saint Nick website
    Then I should see text "Secret" on the page
    And I should see text "Nick" on the page