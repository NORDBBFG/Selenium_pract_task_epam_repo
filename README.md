# Practical Task: Implementing BDD with Selenium WebDriver and SpecFlow

For this practical task, you should proceed to work with **Selenium WebDriver** along with **SpecFlow** and any SpecFlow runner, and refactor the solution created in the Page Object module.  
The main objective of this task is to gain practical experience in writing automated tests using the **Behavioral Driven Development (BDD)** methodology.  
You will adapt an existing codebase, originally developed by you using the **Page Object model**, to incorporate BDD practices using Selenium WebDriver and SpecFlow.

---

## Task #1: Implement an Automated Test using SpecFlow BDD Framework

### Precondition:
- Execute the test case manually before creating the automated test.
- Make the test **parameterized**.

### Test Case #1: Validate Navigation to Services Section
1. Navigate to [https://www.epam.com/](https://www.epam.com/).
2. Locate and click on the **"Services"** link in the main navigation menu.
3. From the dropdown, select a specific service category:  
   - **“Generative AI”** or  
   - **“Responsible AI”** (parameterize the category selection).
4. Validate that the page contains the correct title.
5. Validate that the section **‘Our Related Expertise’** is displayed on the page.

---

## Task #2: Enhance Existing Page Object Solution with BDD Approach

This task requires you to organize your project with a clear and logical folder structure and to implement required classes for a fully functioning BDD test suite.

### Precondition:
1. Make sure you have the following installed:
   - **Visual Studio** (or a similar IDE),
   - **Selenium WebDriver**,  
   - **SpecFlow**,  
   - A compatible **SpecFlow runner**.
2. Before proceeding with the BDD implementation:
   - Execute the existing tests under the Page Object model structure.
   - Ensure that all tests are passing, as this serves as your base functionality upon which you will build the BDD solution.

### Task Description:

#### 1. Folder Structure Set-Up:
- Create a structured folder hierarchy in your project to segregate different components:
  - **Features**: For `.feature` files.
  - **Step Definitions**: For binding the BDD steps to the underlying code.
  - **Page Objects**: For encapsulating page-specific logic.
- Ensure the folder structure reflects a logical and modular test architecture.

#### 2. Class Incorporation:
- Add necessary classes to the respective project folders, including:
  - New **Page Objects**.
  - **Step Definition** files.
- Ensure all classes:
  - Are correctly named.
  - Reside in appropriate folders based on their functionality.

#### 3. BDD Feature File Development:
- Within your **Features** folder, create a `.feature` file describing your test scenario using the BDD syntax:
  - **Given**, **When**, **Then**.
- Clearly outline:
  - Preconditions,
  - Actions,
  - Expected outcomes for the tests.

#### 4. Page Objects Refactoring:
- Adapt your **Page Object** classes to align with BDD steps:
  - Ensure modularity.
  - Avoid direct test assertions within Page Object classes.

---
