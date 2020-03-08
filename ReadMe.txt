Installation Steps:

This solution has been made using Dotnet Core 3.0, it can be downloaded by cloning the following url & taking pull so that most recent changes also get downloaded.

Now after building this solution, just start the project & it will start running.

How to run code & tests
The tests have been written using xunit & FakeItEasy, once after the solution is built, the tests will automatically get discovered and you will be able to see
them on TestExplorer screen, just click on Run All and all tests will run.

The code can run by opening the solution in VS 2017 or higher building & pressing f5.

Where to find code
The code is inside ProductsImport folder & tests are written  in ProductsImport.Tests

You view the same by using the ProductsImport.sln file

No it was not my first time writing unit tests as in my current project, the definition of done for a story includes

Unit Test cases and the coverage to be 100 percent otherwise the build fails on the CI server, so no stories are merged untill unit tests are complete.

I have written tests in NUnit & Moq as well as Xunit & FakeItEasy. We have also used BDDfy to write functional tests.


If I had more time I would have added more unit tests better exception handling, refactored more & made the application more configurable so that changes could be 
made at runtime easily avoiding recompiling the code.